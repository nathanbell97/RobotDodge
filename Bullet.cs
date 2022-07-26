using System;
using SplashKitSDK;
using System.Collections.Generic;

public class Bullet
{
    public Bitmap _bulletbitmap;
    private Vector2D Velocity { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
    public bool bulletcollision;
    private double degrees { get; set; }
    public bool bulletoffscreen 
    {
        get
        {
            return ( X < -_bulletbitmap.Width || X > SplashKit.ScreenWidth() || Y < -_bulletbitmap.Height || Y > SplashKit.ScreenHeight() );
        }
    }
    public Bullet(Player player)
    {
        if (SplashKit.MouseX() >= player.X + (player.Width / 2))
        {
            _bulletbitmap = new Bitmap("Bullet.png", "Bullet.png");
            X = player.X + player.Width;
            Y = player.Y + (player.Height / 4);

            double angleX = SplashKit.MouseX() - player.X;
            double angleY = SplashKit.MouseY() - player.Y;
            double angle = Math.Atan2(angleY, angleX);
            degrees = angle * 180 / Math.PI;
        }

        if (SplashKit.MouseX() < player.X + (player.Width / 2))
        {
            _bulletbitmap = new Bitmap("Bulletflip.png", "Bulletflip.png");
            X = player.X - player.Width;
            Y = player.Y + (player.Height / 4);

            double angleX = player.X - SplashKit.MouseX();
            double angleY =  player.Y - SplashKit.MouseY();
            double angle = Math.Atan2(angleY, angleX);
            degrees = angle * 180 / Math.PI;
        }



        Point2D fromPlayer = new Point2D()
        {
            X = this.X,
            Y = this.Y
        };

        Point2D toMouse = new Point2D()
        {
            X = SplashKit.MouseX(),
            Y = SplashKit.MouseY()
        };
        const int SPEED = 7;


        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPlayer, toMouse));
        Velocity = SplashKit.VectorMultiply(dir, SPEED);

        
        // player.hasFired = false;
    }
    

    public bool CollidedWith(Robot other)
    {
        return _bulletbitmap.CircleCollision(X, Y, other.CollisionCircle);
    }

    public void Update()
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }

    public void Draw()
    {
        _bulletbitmap.Draw(X, Y, SplashKit.OptionRotateBmp(degrees));
    }




}