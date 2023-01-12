using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CathTheSquare
{
    public class BonusSquare : FigureSquare
    {
        private static Color color = new Color(Color.Green);
        private static float SizeStep = 5;
        public BonusSquare(Vector2f position, float moveSpeed, IntRect moveBounds) :
            base(position, moveSpeed, moveBounds)
        {
            rectangleShape.FillColor = color;
        }
        protected override void OnClick()
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                IsActive = false;
            }
        }
        protected override void OnReachedTarget()
        {
            if (rectangleShape.Size.X < SizeStep * 2) { Game.Scores = 5; IsActive = false; return; }
            else rectangleShape.Size -= new Vector2f(SizeStep, SizeStep);
        }
    }
}
