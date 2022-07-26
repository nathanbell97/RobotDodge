using System;
using SplashKitSDK;

public class Program
{
    public static bool Quit { get; set; }
    public static void HandleInput(Player player)
    {
        if (SplashKit.KeyDown(KeyCode.UpKey) || (SplashKit.KeyDown(KeyCode.WKey)))
        {
            player.MoveUp();
        }
        if (SplashKit.KeyDown(KeyCode.DownKey) || (SplashKit.KeyDown(KeyCode.SKey)))
        {
            player.MoveDown();
        }
        if (SplashKit.KeyDown(KeyCode.RightKey) || (SplashKit.KeyDown(KeyCode.DKey)))
        {
            player.MoveRight();
        }
        if (SplashKit.KeyDown(KeyCode.LeftKey) || (SplashKit.KeyDown(KeyCode.AKey)))
        {
            player.MoveLeft();
        }
        if (SplashKit.KeyTyped(KeyCode.EscapeKey))
        {
            Quit = true;
        }
        if (SplashKit.MouseClicked(MouseButton.LeftButton) || SplashKit.KeyTyped(KeyCode.SpaceKey))
        {
            // player.shoot = true;
            // player.hasFired = true;
            player.Shoot();
        }
    }
    public static void Endgame(PlayerLives playerLives, RobotDodge rbd)
    {
        if (!playerLives.Alive() || Quit == true)
        {
            Console.WriteLine("Game Over!");
            Console.WriteLine($"Final Score: {Convert.ToString(rbd.Score)}");
        }
    }
    public static void Main()
    {
        Window w = new Window("Robot Dodge", 1200, 800);
        Player plr = new Player(w);
        PlayerLives plrlives = new PlayerLives(w);
        RobotDodge rbd = new RobotDodge(w, plr, plrlives);
        Timer timer = new Timer("Timer");
        // Bullet bullet = null;
        // bullet.bulletoffscreen = true;
        timer.Start();
        while ((Quit == false) && (!w.CloseRequested) && plrlives.Alive())
        {
            SplashKit.ProcessEvents();

            rbd.RandomRobot(w);
            rbd.Collision();
            rbd.Update(timer);
            rbd.Draw(w);
            rbd.PrintScore(w, timer);
            plr.StayOnWindow(w);

            HandleInput(plr);




            w.Refresh(60);
        }
        Endgame(plrlives, rbd);
    }
}