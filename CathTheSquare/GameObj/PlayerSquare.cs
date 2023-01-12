using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.Audio;
using SFML.System;
using SFML.Window;

namespace CathTheSquare
{
    public class PlayerSquare : FigureSquare
    {
        private static Color color = new Color(50, 50, 50);
        private static float SizeStep = 5;
        private static float MinSize = 30;
        private static float MaxMoveSpeed = 6;
        private static float MoveStep = 0.02f;

        public PlayerSquare(Vector2f position, float moveSpeed, IntRect moveBounds) :
            base(position, moveSpeed, moveBounds)
        {
            rectangleShape.FillColor = color;
        }
        protected override void OnClick()
        {
            Game.Scores++;
            Game.Check = false;

            rectangleShape.Size -= new Vector2f(SizeStep, SizeStep);
            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true && moveSpeed < MaxMoveSpeed) { moveSpeed += MoveStep; }
            if (rectangleShape.Size.X < MinSize) { IsActive = false; return; }

            UpdateMoveTarget();
            rectangleShape.Position = moveTarget;
        }
    }
}