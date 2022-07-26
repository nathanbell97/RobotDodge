using System;
using SplashKitSDK;

public abstract class Robot
{
    public double X {get; set;}
    public double Y {get; set;}
    public Circle CollisionCircle
    {
        get; set;
    }

    private Vector2D Velocity {get; set;}
    public Color MainColor
    {
        get { return Color.RandomRGB(200); }
    }

    public int Width
    {
        get {return 50;}
    }
    public int Height
    {
        get {return 50;}
    }

    
    public Robot(Window gamewindow, Player player)
    {
        if (SplashKit.Rnd() < 0.5)
        {
            X = SplashKit.Rnd(gamewindow.Width);
            if (SplashKit.Rnd() < 0.5)
            {
                Y = -Height;
            }
            else{
                Y = gamewindow.Height;
            }
        }
        else{
            Y = SplashKit.Rnd(gamewindow.Height);
            if (SplashKit.Rnd() < 0.5)
            {
                X = -Width;
            }
            else{
                X = gamewindow.Width;
            }
        }
        const int SPEED = 4;

        Point2D fromPT = new Point2D()
        {
            X = this.X, Y = this.Y
        };
        Point2D toPT = new Point2D()
        {
            X = player.X, Y = player.Y
        };

        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPT, toPT));
        Velocity = SplashKit.VectorMultiply(dir, SPEED);
    } 
    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
        CollisionCircle = SplashKit.CircleAt(X + Width / 2, Y + Height / 2, 20);
    }

    public bool IsOffScreen(Window screen)
    {
        while( X < -Width || X > screen.Width || Y < -Height || Y > screen.Height )
        {
            return true;
        }
        return false;
    }

    public abstract void Draw();
}

public class Spooky : Robot
{


    public Spooky(Window gamewindow, Player player) : base(gamewindow, player)
    {

    }


    public override void Draw()
    {
        double leftX = X + 17;
        double rightX = X + 35;
        double eyeY = Y + 15;
        double mouthY = Y + 30;
        double antennaYup = Y - 15;
        double anteenaYdown = Y;
        SplashKit.FillRectangle(Color.Chocolate, X, Y, Width, Height);
        SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
        SplashKit.FillCircle(MainColor, rightX, eyeY, 5);
        SplashKit.FillRectangle(MainColor, leftX - 5, mouthY, 25, 10);
        SplashKit.FillRectangle(MainColor, leftX, mouthY + 2, 21, 6);
        SplashKit.DrawLine(MainColor, leftX, antennaYup, leftX + 5, anteenaYdown);
        SplashKit.DrawLine(MainColor, rightX, antennaYup, rightX - 5, anteenaYdown);
    }
}

public class Roundy : Robot
{


    public Roundy(Window gamewindow, Player player) : base(gamewindow, player)
    {

    }


    public override void Draw()
    {
        double leftX = X + 17;
        double midX = X + 25;
        double rightX = X + 33;

        double midY = Y + 25;
        double eyeY = Y + 20;
        double mouthY = Y + 35;
        SplashKit.FillCircle(Color.White, midX, midY, 25);
        SplashKit.DrawCircle(Color.Gray, midX, midY, 25);
        SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
        SplashKit.FillCircle(MainColor, rightX, eyeY, 5);
        SplashKit.FillEllipse(Color.Gray, X, eyeY, 50, 30);
        SplashKit.DrawLine(Color.Black, X, mouthY, X + 50, Y + 35);
    }
}

public class Boxy : Robot
{


    public Boxy(Window gamewindow, Player player) : base(gamewindow, player)
    {

    }


    public override void Draw()
    {
        double leftX = X + 12;
        double rightX = X + 27;
        double eyeY = Y + 10;
        double mouthY = Y + 30;
        SplashKit.FillRectangle(Color.Gray, X, Y, Width, Height);
        SplashKit.FillRectangle(MainColor, leftX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, rightX, eyeY, 10, 10);
        SplashKit.FillRectangle(MainColor, leftX, mouthY, 25, 10);
        SplashKit.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 6);
        // SplashKit.DrawCircle(Color.DarkRed, CollisionCircle);
    }
}