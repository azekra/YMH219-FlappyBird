using System.Drawing;

namespace YMH219_FlappyBird;

public class Bird
{
    public float X { get; private set; }
    public float Y { get; private set; }

    public float Width => 40;
    public float Height => 30;

    private float velocityY;

    private const float Gravity = 1450f;
    private const float JumpStrength = -500f;

    public RectangleF Bounds => new(X, Y, Width, Height);

    public Bird(float x, float y)
    {
        X = x;
        Y = y;
    }

    public void Jump()
    {
        velocityY = JumpStrength;
    }

    public void Update(float deltaTime)
    {
        velocityY += Gravity * deltaTime;
        Y += velocityY * deltaTime;
    }

    public void Reset(float x, float y)
    {
        X = x;
        Y = y;
        velocityY = 0;
    }

    public void Draw(Graphics g)
    {
        g.FillEllipse(Brushes.Gold, Bounds);

        g.FillEllipse(Brushes.White, X + 25, Y + 6, 8, 8);
        g.FillEllipse(Brushes.Black, X + 29, Y + 8, 3, 3);

        PointF[] beak =
        {
            new(X + 38, Y + 14),
            new(X + 49, Y + 19),
            new(X + 38, Y + 23)
        };

        g.FillPolygon(Brushes.OrangeRed, beak);
    }
}