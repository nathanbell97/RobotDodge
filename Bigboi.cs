using System;
using SplashKitSDK;

// public class Spooky : Robot
// {


//     public Spooky(Window gamewindow, Player player) : base(gamewindow, player)
//     {

//     }


//     public override void Draw()
//     {
//         double leftX = X + 17;
//         double rightX = X + 35;
//         double eyeY = Y + 15;
//         double mouthY = Y + 30;
//         double antennaYup = Y - 15;
//         double anteenaYdown = Y;
//         SplashKit.FillRectangle(Color.Chocolate, X, Y, Width, Height);
//         SplashKit.FillCircle(MainColor, leftX, eyeY, 5);
//         SplashKit.FillCircle(MainColor, rightX, eyeY, 5);
//         SplashKit.FillRectangle(MainColor, leftX - 5, mouthY, 25, 10);
//         SplashKit.FillRectangle(MainColor, leftX, mouthY + 2, 21, 6);
//         SplashKit.DrawLine(MainColor, leftX, antennaYup, leftX + 5, anteenaYdown);
//         SplashKit.DrawLine(MainColor, rightX, antennaYup, rightX - 5, anteenaYdown);
//     }
// }