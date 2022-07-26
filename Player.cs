using System;
using SplashKitSDK;
using System.Collections.Generic;

public class Player
{
    // Note: This is the top left point of the Player Bitmap
    public double X { get; set; }
    // Note: This is the top left point of the Player Bitmap
    public double Y { get; set; }
    // public bool shoot = false;
    // public bool hasFired = false;
    public Bullet _bullet = null;

    private Bitmap _PlayerBitmap;

    private int speed = 5;


    public int Width
    {
        get
        {
            return _PlayerBitmap.Width;
        }
    }

    public int Height
    {
        get
        {
            return _PlayerBitmap.Height;
        }
    }
    public Player(Window playerwindow)
    {
        _PlayerBitmap = new Bitmap("Player", "Player.png");
        X = (playerwindow.Width - Width) / 2;
        Y = (playerwindow.Height - Height) / 2;
    }
    public void Draw()
    {
        _PlayerBitmap.Draw(X, Y);
    }

    public void StayOnWindow(Window playerwindow)
    {
        const int GAP = 15;
        if (this.X <= GAP)
        {
            this.X = GAP;
        }
        if (this.X >= (playerwindow.Width - (GAP + Width)))
        {
            this.X = playerwindow.Width - (GAP + Width);
        }
        if (this.Y <= GAP)
        {
            this.Y = GAP;
        }
        if (this.Y >= playerwindow.Height - (GAP + Height))
        {
            this.Y = playerwindow.Height - (GAP + Height);
        }
    }
    public void MoveUp()
    {
        Y = Y - speed;
    }
    public void MoveDown()
    {
        Y = Y + speed;
    }
    public void MoveRight()
    {
        X = X + speed;
    }
    public void MoveLeft()
    {
        X = X - speed;
    }

    public void Shoot()
    {
        if ((_bullet is null))
            {
                _bullet = new Bullet(this);
            }
    }

    public bool CollidedWith(Robot other)
    {
        return _PlayerBitmap.CircleCollision(X, Y, other.CollisionCircle);
    }
}

public class PlayerLives
{
    private int _life = 5;
    public int Life
    {
        get
        {
            return _life;
        }
        set
        {
            _life = value;
        }
    }
    private int HeartsX { get; set; }
    private int HeartsY { get; set; }
    private Bitmap _PlayerHearts = new Bitmap($"LifeHearts", "LifeHearts.png");

    public PlayerLives(Window playerwindow)
    {
        this.HeartsX = playerwindow.Width - 45;
        this.HeartsY = 10;
    }
    public void Draw()
    {
        int Offset = 0;
        for (int i = 0; i < Life; i++)
        {
            _PlayerHearts.Draw((HeartsX - Offset), HeartsY);
            Offset += 45;
        }
    }
    public bool Alive()
    {
        if(Life > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}