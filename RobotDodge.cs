using System;
using SplashKitSDK;
using System.Collections.Generic;
public class RobotDodge
{
    private PlayerLives _playerlives;
    private Player _player;
    private Window _gamewindow;
    public int Score;
    private int minimumrobots = 3;

    private List<Robot> _Robots = new List<Robot>();
    // private bool removerobotbool = false;

    public Robot RandomRobot(Window _gamewindow)
    {
        int robotgenerator = SplashKit.Rnd(0, 3);
        if (robotgenerator >= 2)
        {
            return new Boxy(_gamewindow, _player);
        }
        if (robotgenerator < 2 && robotgenerator >= 1)
        {
            return new Spooky(_gamewindow, _player);
        }
        if (robotgenerator < 1)
        {
            return new Roundy(_gamewindow, _player);
        }
        else
        {
            return null;
        }
    }
    public void Update(Timer tmr)
    {
        Robot removerobot = RandomRobot(_gamewindow);
        bool robotoffscreen = false;
        foreach (Robot r in _Robots)
        {
            if (r.IsOffScreen(_gamewindow) || _player.CollidedWith(r))
            {
                robotoffscreen = true;
                removerobot = r;
            }

        }
        if (Convert.ToInt32(tmr.Ticks) % 50 == 0)
        {
            minimumrobots += 1;
            // Console.WriteLine($"{minimumrobots}");
        }
        if (robotoffscreen)
        {
            _Robots.Remove(removerobot);
        }
        if (_Robots.Count < minimumrobots)
        {
            _Robots.Add(RandomRobot(_gamewindow));
        }
        foreach (Robot r in _Robots)
        {
            r.Draw();
            r.Update();
        }
        if (_player._bullet is Bullet)
        {
            _player._bullet.Update();
        }
        BulletInteractions();
    }
    public RobotDodge(Window w, Player p, PlayerLives plrlives)
    {
        _gamewindow = w;
        _player = p;
        _Robots.Add(RandomRobot(_gamewindow));
        _playerlives = plrlives;
    }

    public void BulletInteractions()
    {
        // Robot robotcollision = RandomRobot(_gamewindow);
        if (_player._bullet is Bullet)
        {

            foreach (Robot r in _Robots)
            {
                if (_player._bullet.CollidedWith(r))
                {
                    _player._bullet.bulletcollision = true;
                    // removerobotbool = true;
                    // robotcollision = r;
                    _player._bullet = null;
                    _Robots.Remove(r);
                    return;
                }
                else
                {
                    _player._bullet.bulletcollision = false;
                }
            }
            if (_player._bullet.bulletoffscreen)
            {
                _player._bullet = null;
                // Console.WriteLine("Bullet is offscreen");
            }
        }
    }

    public void Collision()
    {
        foreach (Robot r in _Robots)
        {
            if (_player.CollidedWith(r))
            {
                _playerlives.Life -= 1;
            }
        }
    }
    public void PrintScore(Window _gamewindow, Timer tmr)
    {
        Font font = new Font("Roboto", "Roboto-Regular.ttf");
        Score = Convert.ToInt32(tmr.Ticks / 1000);
        _gamewindow.DrawText($"SCORE: {Convert.ToString(Score)}", Color.Black, font, 11, _gamewindow.Width - 60, 70);
    }

    public void Draw(Window playerwindow)
    {
        playerwindow.Clear(Color.White);
        foreach (Robot r in _Robots)
        {
            r.Draw();
        }
        _player.Draw();
        _playerlives.Draw();

        if (_player._bullet is Bullet)
        {
            _player._bullet.Draw();
        }
    }
}