using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace CathTheSquare
{
    public class FigureCircleList
    {
        private List<FigureCircle> figureCirclesList;
        public bool CircleHasRemoved;
        public FigureCircle FigureCircleDel;

        private int speed = 5;

        public FigureCircleList() { figureCirclesList = new List<FigureCircle>(); }
        public void ResetCircle()
        {
            CircleHasRemoved = false;
            FigureCircleDel = null;
            figureCirclesList.Clear();
        }
        public void UpdateCircle(RenderWindow win)
        {
            CircleHasRemoved = false;
            FigureCircleDel = null;

            if (Mouse.IsButtonPressed(Mouse.Button.Left) == true) 
            { 
                for (int i = 0; i < figureCirclesList.Count; i++)
                    { figureCirclesList[i].CheckMousePosition(Mouse.GetPosition(win));}
            }

            for (int i = 0; i < figureCirclesList.Count; i++) 
            {
                figureCirclesList[i].Move(); figureCirclesList[i].Draw(win);

                if (figureCirclesList[i].IsActive == false) 
                { 
                    FigureCircleDel = figureCirclesList[i]; 
                    figureCirclesList.Remove(figureCirclesList[i]); 
                    CircleHasRemoved = true; 
                }
            }
        }
        public void SpawnPlayerCircle()
        {
            figureCirclesList.Add(new PlayerCircle(new Vector2f(RandMathf.LockedRand(Program.xOy, Program.ScreenWidth), RandMathf.LockedRand(Program.xOy, Program.ScreenHeight)),
                                                               speed, new IntRect(Program.xOy, Program.xOy, Program.ScreenWidth, Program.ScreenHeight)));
        }
        public void SpawnEnemyCircle()
        {
            figureCirclesList.Add(new EnemyCircle(new Vector2f(RandMathf.LockedRand(Program.xOy, Program.ScreenWidth), RandMathf.LockedRand(Program.xOy, Program.ScreenHeight)),
                                                               speed, new IntRect(Program.xOy, Program.xOy, Program.ScreenWidth, Program.ScreenHeight)));
        }
        public void SpawnBonusCircle()
        {
            figureCirclesList.Add(new BonusCircle(new Vector2f(RandMathf.LockedRand(Program.xOy, Program.ScreenWidth), RandMathf.LockedRand(Program.xOy, Program.ScreenHeight)),
                                                               speed, new IntRect(Program.xOy, Program.xOy, Program.ScreenWidth, Program.ScreenHeight)));
        }
    }
}