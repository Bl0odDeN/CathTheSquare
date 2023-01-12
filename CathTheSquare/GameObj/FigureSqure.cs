using SFML.Graphics;
using SFML.System;

namespace CathTheSquare
{
    public class FigureSquare
    {
        public bool IsActive = true;

        protected RectangleShape rectangleShape;
        protected float moveSpeed;
        protected Vector2f moveTarget;
        protected IntRect moveBounds;

        public FigureSquare(Vector2f position, float moveSpeed, IntRect moveBounds)
        {
            rectangleShape = new RectangleShape(new Vector2f(100, 100));
            rectangleShape.Position = position;

            this.moveSpeed = moveSpeed;
            this.moveBounds = moveBounds;

            UpdateMoveTarget();
        }

        public void Move()
        {
            rectangleShape.Position = Mathf.MoveTowards(rectangleShape.Position, moveTarget, moveSpeed);



            if (rectangleShape.Position == moveTarget)
            {
                OnReachedTarget();

                UpdateMoveTarget();
            }
        }

        public void Draw(RenderWindow win)
        {
            if (IsActive == false) return;

            win.Draw(rectangleShape);
        }

        public void CheckMousePosition(Vector2i mousePos)
        {
            if (IsActive == false) return;

            if (mousePos.X > rectangleShape.Position.X && mousePos.X < rectangleShape.Position.X + rectangleShape.Size.X &&
              mousePos.Y > rectangleShape.Position.Y && mousePos.Y < rectangleShape.Position.Y + rectangleShape.Size.Y)

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