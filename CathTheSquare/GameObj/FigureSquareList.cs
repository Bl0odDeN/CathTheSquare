using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace CathTheSquare
{
    public class FigureSquareList
    {
        private List<FigureSquare> squareList;
        public bool SquareHasRemoved;
        public FigureSquare FigureSquareDel;

        private int speed = 5;

        public FigureSquareList() { squareList = new List<FigureSquare>(); }
        public void ResetSquare()
        {
            SquareHasRemoved = false;
            FigureSquareDel = null;
            squareList.Clear();
        }
        public void UpdateSquare(RenderWindow win)
        {
            SquareHasRemoved = false;
            FigureSquareDel = null;
            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true)
            {
                for (int i = 0; i < squareList.Count; i++)
                { squareList[i].CheckMousePosition(Mouse.GetPosition(win)); }
            }
            for (int i = 0; i < squareList.Count; i++)
            {
                squareList[i].Move(); squareList[i].Draw(win);

                if (squareList[i].IsActive == false) 
                { 
                    FigureSquareDel = squareList[i]; 
                    squareList.Remove(squareList[i]); 
                    SquareHasRemoved = true; 
                }
            }
        }
        public void SpawnPlayerSquare()
        {
            squareList.Add(new PlayerSquare(new Vector2f(RandMathf.LockedRand(Program.xOy, Program.ScreenWidth), RandMathf.LockedRand(Program.xOy, Program.ScreenHeight)),
                                                         speed, new IntRect(Program.xOy, Program.xOy, Program.ScreenWidth, Program.ScreenHeight)));
        }
        public void SpawnEnemySquare()
        {
            squareList.Add(new EnemySquare(new Vector2f(RandMathf.LockedRand(Program.xOy, Program.ScreenWidth), RandMathf.LockedRand(Program.xOy, Program.ScreenHeight)),
                                                         speed, new IntRect(Program.xOy, Program.xOy, Program.ScreenWidth, Program.ScreenHeight)));
        }
        public void SpawnBonusSquare()
        {
            squareList.Add(new BonusSquare(new Vector2f(RandMathf.LockedRand(Program.xOy, Program.ScreenWidth), RandMathf.LockedRand(Program.xOy, Program.ScreenHeight)),
                                                         speed, new IntRect(Program.xOy, Program.xOy, Program.ScreenWidth, Program.ScreenHeight)));
        }
    }
}