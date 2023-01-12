using SFML.Graphics;
using SFML.System;


namespace CathTheSquare
{
    public class EnemyCircle : FigureCircle
    {
        private static Color Color = new Color(230, 50, 50);
        private static float MaxMovementSpeed = 3;
        private static float MovementStep = 0.05f;
        private static float MaxRadius = 100;
        private static float SizeStep = 10;

        public EnemyCircle(Vector2f position, float moveSpeed, IntRect moveBounds) :
            base(position, moveSpeed, moveBounds)
        {
            circleShape.FillColor = Color;
        }

        protected override void OnClick()
        {
            if (Game.Check == true)
            {
                Game.Check = false;
                IsActive = false;
                return;

            }
            Game.IslostGame = true;
        }

        protected override void OnReachedTarget()
        {
            if (Game.Check == true) circleShape.Radius = SizeStep;
            if (moveSpeed <= MaxMovementSpeed) moveSpeed += MovementStep;
            if (circleShape.Radius < MaxRadius) circleShape.Radius += SizeStep;
        }
    }
}
