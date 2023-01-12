using SFML.Graphics;
using SFML.System;

namespace CathTheSquare
{
    public class EnemySquare : FigureSquare
    {
        private static Color color = new Color(230, 50, 50);
        private static float MaxMoveSpeed = 3;
        private static float MoveStepAdd = 0.05f;
        private static float MaxSize = 150;
        private static float SizeStep = 10;

        public EnemySquare(Vector2f position, float moveSpeed, IntRect moveBounds) :
            base(position, moveSpeed, moveBounds)
        {
            rectangleShape.FillColor = color;
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
            if (Game.Check == true) rectangleShape.Size = new Vector2f(SizeStep, SizeStep);
            if (moveSpeed < MaxMoveSpeed) { moveSpeed += MoveStepAdd; }
            if (rectangleShape.Size.X < MaxSize) { rectangleShape.Size += new Vector2f(SizeStep, SizeStep); }
        }
    }
}