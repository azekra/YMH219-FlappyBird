using System.Drawing;

namespace YMH219_FlappyBird;

public class Pipe
{
    public const float Width = 75;
    public const float GapHeight = 175;

    public float X { get; private set; }
    public float GapY { get; private set; }

    public bool Passed { get; set; }

    public Pipe(float x, float gapY)
    {
        X = x;
        GapY = gapY;
    }

    public void Update(float speed, float deltaTime)
    {
        X -= speed * deltaTime;
    }

    public RectangleF TopBounds(float groundY)
    {
        return new RectangleF(
            X, 0, Width,
            GapY - GapHeight / 2
        );
    }

    public RectangleF BottomBounds(float groundY)
    {
        float y = GapY + GapHeight / 2;

        return new RectangleF(
            X, y, Width,
            groundY - y
        );
    }

    public bool CollidesWith(RectangleF bird, float groundY)
    {
        return bird.IntersectsWith(TopBounds(groundY)) ||
               bird.IntersectsWith(BottomBounds(groundY));
    }

    public void Draw(Graphics g, float groundY)
    {
        RectangleF top = TopBounds(groundY);
        RectangleF bottom = BottomBounds(groundY);

        using Pen border = new(Color.DarkGreen, 2);

        g.FillRectangle(Brushes.ForestGreen, top);
        g.DrawRectangle(border, top.X, top.Y, top.Width, top.Height);

        g.FillRectangle(Brushes.ForestGreen, bottom);
        g.DrawRectangle(border, bottom.X, bottom.Y,
            bottom.Width, bottom.Height);
    }
}