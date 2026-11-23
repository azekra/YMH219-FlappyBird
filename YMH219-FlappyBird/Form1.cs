using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace YMH219_FlappyBird;

public partial class Form1 : Form
{
    private readonly System.Windows.Forms.Timer gameTimer = new();
    private readonly Stopwatch gameClock = new();
    private readonly Random random = new();

    private readonly List<Pipe> pipes = new();

    private Bird bird = new(150, 250);

    private int score = 0;

    private bool gameStarted = false;
    private bool gameOver = false;

    private const float PipeSpeed = 240f;
    private const float PipeSpacing = 280f;

    private float GroundY => ClientSize.Height - 65;

    public Form1()
    {
        InitializeComponent();

        Text = "Flappy Bird";
        ClientSize = new Size(800, 600);

        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        DoubleBuffered = true;
        KeyPreview = true;

        gameTimer.Interval = 16;
        gameTimer.Tick += GameTimer_Tick;

        KeyDown += Form1_KeyDown;

        ResetGame();
    }

    private float RandomGapY()
    {
        return random.Next(150, (int)GroundY - 150);
    }

    private void ResetGame()
    {
        bird.Reset(150, 250);

        pipes.Clear();

        score = 0;

        float x = ClientSize.Width + 100;

        for (int i = 0; i < 3; i++)
        {
            pipes.Add(new Pipe(x, RandomGapY()));
            x += PipeSpacing;
        }

        gameStarted = false;
        gameOver = false;

        gameTimer.Stop();
        gameClock.Reset();

        Invalidate();
    }

    private void Form1_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            if (!gameStarted)
            {
                if (gameOver)
                    ResetGame();

                gameStarted = true;

                bird.Jump();

                gameClock.Restart();
                gameTimer.Start();
            }
            else
            {
                bird.Jump();
            }

            e.Handled = true;
        }

        if (e.KeyCode == Keys.R && gameOver)
        {
            ResetGame();
        }
    }

    private void GameTimer_Tick(object? sender, EventArgs e)
    {
        if (!gameStarted || gameOver)
            return;

        float deltaTime = (float)gameClock.Elapsed.TotalSeconds;
        gameClock.Restart();
        deltaTime = Math.Min(deltaTime, 0.05f);

        bird.Update(deltaTime);

        foreach (Pipe pipe in pipes)
        {
            pipe.Update(PipeSpeed, deltaTime);
        }

        // Ground and ceiling collision

        if (bird.Y < 0 || bird.Bounds.Bottom >= GroundY)
        {
            EndGame();
            return;
        }

        foreach (Pipe pipe in pipes)
        {
            // Pipe collision

            if (pipe.CollidesWith(bird.Bounds, GroundY))
            {
                EndGame();
                return;
            }

            // Score calculation

            if (!pipe.Passed && pipe.X + Pipe.Width < bird.X)
            {
                pipe.Passed = true;
                score++;
            }
        }

        // Remove pipes outside the screen

        pipes.RemoveAll(p => p.X + Pipe.Width < 0);

        // Create new pipes

        if (pipes.Count < 3)
        {
            float nextX = pipes.Count > 0
                ? pipes.Max(p => p.X) + PipeSpacing
                : ClientSize.Width + 100;

            pipes.Add(new Pipe(nextX, RandomGapY()));
        }

        Invalidate();
    }

    private void EndGame()
    {
        gameOver = true;
        gameStarted = false;

        gameTimer.Stop();
        gameClock.Stop();

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;

        g.SmoothingMode = SmoothingMode.AntiAlias;

        g.Clear(Color.SkyBlue);

        // Clouds

        g.FillEllipse(Brushes.White, 80, 70, 65, 30);
        g.FillEllipse(Brushes.White, 110, 55, 65, 40);

        g.FillEllipse(Brushes.White, 480, 100, 65, 30);
        g.FillEllipse(Brushes.White, 510, 85, 65, 40);

        // Pipes

        foreach (Pipe pipe in pipes)
        {
            pipe.Draw(g, GroundY);
        }

        // Bird

        bird.Draw(g);

        // Ground

        g.FillRectangle(
            Brushes.ForestGreen,
            0, GroundY, ClientSize.Width, 12
        );

        g.FillRectangle(
            Brushes.SandyBrown,
            0, GroundY + 12,
            ClientSize.Width, 60
        );

        // Score

        using Font scoreFont = new("Arial", 24, FontStyle.Bold);

        g.DrawString(
            $"Score: {score}",
            scoreFont,
            Brushes.White,
            20, 20
        );

        // Start and Game Over screens

        if (!gameStarted)
        {
            using Font titleFont = new("Arial", 32, FontStyle.Bold);

            using Font messageFont = new("Arial", 16, FontStyle.Bold);

            string title = gameOver ? "GAME OVER" : "FLAPPY BIRD";

            string message = gameOver
                ? "Press SPACE to Restart"
                : "Press SPACE to Start";

            DrawCenteredText(g, title, titleFont, Brushes.White, 210);

            DrawCenteredText(g, message, messageFont, Brushes.White, 280);
        }
    }

    private void DrawCenteredText(
        Graphics g,
        string text,
        Font font,
        Brush brush,
        float y)
    {
        using StringFormat format = new()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        g.DrawString(
            text,
            font,
            brush,
            new RectangleF(0, y, ClientSize.Width, 55),
            format
        );
    }
}