using SFML.Graphics;
using SFML.System;

namespace CathTheSquare
{
    public class BonusCircle : FigureCircle
    {
        private static Color Color = new Color(Color.Green);
        private static float RadiusStep = 5;

        public BonusCircle(Vector2f position, float movementSpeed, IntRect movementBounds) :
            base(position, movementSpeed, movementBounds)
        {
            circleShape.FillColor = Color;
        }

        protected override void OnClick()
        {
            IsActive = false;
        }

        protected override void OnReachedTarget()
        {
            if (circleShape.Radius < RadiusStep * 2) {Game.Scores = 5; IsActive = false; return; }
            else circleShape.Radius -= RadiusStep;
        }
    }
}