// using System;
// using SplashKitSDK;

// public class Roundy : Robot
// {


//     public Roundy(Window gamewindow, Player player) : base(gamewindow, player)
//     {

//     }


//     public override void Draw()
//     {
//         double leftX = X + 17;
//         double midX = X + 25;
//         double rightX = X + 33;

//         double midY = Y + 25;
//         double eyeY = Y + 20;
//         double mouthY = Y + 35;
//         SplashKit.FillCircle(Color.White, midX, midY, 25);
//         SplashKit.DrawCircle(Color.Gray, midX, midY, 25);
//         SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
//         SplashKit.FillCircle(MainColor, rightX, eyeY, 5);
//         SplashKit.FillEllipse(Color.Gray, X, eyeY, 50, 30);
//         SplashKit.DrawLine(Color.Black, X, mouthY, X + 50, Y + 35);
//     }
// }