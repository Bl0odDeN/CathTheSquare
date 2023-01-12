using SFML.Graphics;
using SFML.System;

namespace CathTheSquare
{
    public class FigureCircle
    {
        private float defaultRadius = 50;

        public bool IsActive = true;

        protected CircleShape circleShape;
        protected float moveSpeed;
        protected Vector2f moveTarget;
        protected IntRect moveBounds;

        public FigureCircle(Vector2f position, float moveSpeed, IntRect moveBounds)
        {
            circleShape = new CircleShape(defaultRadius);
            circleShape.Position = position;

            this.moveSpeed = moveSpeed;
            this.moveBounds = moveBounds;

            UpdateMoveTarget();
        }

        public void Move()
        {
            circleShape.Position = Mathf.MoveTowards(circleShape.Position, moveTarget, moveSpeed);
            if (circleShape.Position == moveTarget) { OnReachedTarget(); UpdateMoveTarget(); }
        }
        public void Draw(RenderWindow win)
        {
            if (IsActive == false) return;
            win.Draw(circleShape);
        }
        public void CheckMousePosition(Vector2i mousePos)
        {
            if (IsActive == false) return;

            if (mousePos.X > circleShape.Position.X && mousePos.X < circleShape.Position.X + circleShape.Radius * 2 &&
                mousePos.Y > circleShape.Position.Y && mousePos.Y < circleShape.Position.Y + circleShape.Radius * 2)
                OnClick();
        }
        protected void UpdateMoveTarget()
        {
            moveTarget.X = RandMathf.LockedRand(moveBounds.Left, moveBounds.Left + moveBounds.Width);
            moveTarget.Y = RandMathf.LockedRand(moveBounds.Top, moveBounds.Top + moveBounds.Height);
        }

        protected virtual void OnClick() { }
        protected virtual void OnReachedTarget() { }
    }
}
