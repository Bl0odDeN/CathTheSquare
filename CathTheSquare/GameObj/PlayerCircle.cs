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
    public class PlayerCircle : FigureCircle
    {
        private static Color Color = new Color(50, 50, 50);
        private static float SizeStep = 5;
        private static float MinSize = 15;
        private static float MaxMoveSpeed = 6;
        private static float MoveStep = 0.02f;


        public PlayerCircle(Vector2f position, float movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)
        {
            circleShape.FillColor = Color;
        }

        protected override void OnClick()
        {
            Game.Scores++;
            Game.Check = false;

            circleShape.Radius -= SizeStep;
            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true && moveSpeed < MaxMoveSpeed) { moveSpeed += MoveStep; }
            if (circleShape.Radius < MinSize) { IsActive = false; return; }

            UpdateMoveTarget();
            circleShape.Position = moveTarget;
        }
    }
}