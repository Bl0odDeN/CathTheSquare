using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace CathTheSquare
{
    public class Game
    {
        public static int Scores;
        public static bool IslostGame;
        public static bool Check;
        private static bool state1 = false;
        private static bool state2 = false;
        private int gamePlay = 0;
        private int MaxScores;

        private FigureSquareList figureSquare;
        private FigureCircleList figureCircles;

        private Font mainFont;
        private Text scoreText;
        private Text loseText;
        private Text MainMenuText;
        private Text pauseText;
        

        public Game()
        {
            mainFont = new Font("arial.ttf");
            figureSquare = new FigureSquareList();
            figureCircles = new FigureCircleList();

            MainMenuText = new Text();
            MainMenuText.Font = mainFont;
            MainMenuText.FillColor = Color.Black;
            MainMenuText.CharacterSize = 36;
            MainMenuText.DisplayedString = "   Main Menu\n" +
                                           "   Squares - 1\n" +
                                           "   Сircles - 2\n\n" +
                                           "Exit game - Esc";
            MainMenuText.Position = new Vector2f(275, 175);

            pauseText = new Text();
            pauseText.Font = mainFont;
            pauseText.FillColor = Color.Black;
            pauseText.CharacterSize = 38;
            pauseText.DisplayedString = "    PAUSE - P\n" +
                                        "Main Menu - M\n" +
                                        "Exit game - Esc";
            pauseText.Position = new Vector2f(265, 225);

            scoreText = new Text();
            scoreText.Font = mainFont;
            scoreText.FillColor = Color.Black;
            scoreText.CharacterSize = 12;
            scoreText.Position = new Vector2f(5, 585);

            loseText = new Text();
            loseText.Font = mainFont;
            loseText.FillColor = Color.Red;
            loseText.DisplayedString = "   GAME OVER\n\n" +
                                       "Restart game - R\n" +
                                       "Exit game - Esc";
            loseText.Position = new Vector2f(275, 210);

            Reset();
        }
        public void Reset()
        {
            Scores = 0;
            IslostGame = false;
            Check = false;
            if (gamePlay == 1) { figureSquare.ResetSquare();
                figureSquare.SpawnPlayerSquare(); figureSquare.SpawnEnemySquare(); }
            if (gamePlay == 2) { figureCircles.ResetCircle(); 
                figureCircles.SpawnPlayerCircle(); figureCircles.SpawnEnemyCircle(); }
        }
        public void Exit(RenderWindow win)
        {
            win.Close();
        }
        public void Update(RenderWindow win)
        {
            if (gamePlay == 0)
            {
                win.Draw(MainMenuText);
               
                if (Keyboard.IsKeyPressed(Keyboard.Key.Num1) == true) 
                {
                    gamePlay = 1;
                    IslostGame = false;
                    state1 = true;
                    figureSquare.SpawnPlayerSquare();
                    figureSquare.SpawnEnemySquare();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Num2) == true)
                {
                    gamePlay = 2;
                    IslostGame = false;
                    state2 = true;
                    figureCircles.SpawnPlayerCircle();
                    figureCircles.SpawnEnemyCircle();
                }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape) == true) { win.Close(); }
            }
            if (IslostGame == true)
            {
                win.Draw(loseText);
                if (Scores > MaxScores) { MaxScores = Scores; }
                if (Keyboard.IsKeyPressed(Keyboard.Key.R) == true) { Reset(); }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape) == true) { win.Close(); }

            }
            if (gamePlay == 3)
            {
                win.Draw(pauseText);
                if (Keyboard.IsKeyPressed(Keyboard.Key.P) == true && state1 == true)
                { gamePlay = 1; System.Threading.Thread.Sleep(100); }
                if (Keyboard.IsKeyPressed(Keyboard.Key.P) == true && state2 == true)
                { gamePlay = 2; System.Threading.Thread.Sleep(100); }
                if (Keyboard.IsKeyPressed(Keyboard.Key.Escape) == true) { win.Close(); }
                if (Keyboard.IsKeyPressed(Keyboard.Key.M) == true) 
                    { gamePlay = 0; figureSquare.ResetSquare(); figureCircles.ResetCircle(); Reset(); }
            }
            if (IslostGame == false)
            {
                if (gamePlay == 1) figureSquare.UpdateSquare(win);
                if (gamePlay == 2) figureCircles.UpdateCircle(win);
                if (Keyboard.IsKeyPressed(Keyboard.Key.P) == true) 
                    { gamePlay = 3; System.Threading.Thread.Sleep(150); }
                if (Scores % 13 == 0 && Scores >= 13)
                {
                    Scores++;

                    if (gamePlay == 1)
                    {
                        figureSquare.SpawnBonusSquare();
                        figureSquare.SpawnPlayerSquare();

                        figureSquare.SpawnEnemySquare();
                    }

                    if (gamePlay == 2)
                    {
                        figureCircles.SpawnBonusCircle();
                        figureCircles.SpawnPlayerCircle();

                        figureCircles.SpawnEnemyCircle();
                    }
                }
                if (figureSquare.SquareHasRemoved == true)
                {
                    if (figureSquare.FigureSquareDel != null)
                    {
                        if (figureSquare.FigureSquareDel is PlayerSquare)
                        {
                            figureSquare.SpawnPlayerSquare();
                            Check = false;
                        }
                        if (figureSquare.FigureSquareDel is BonusSquare)
                        {
                            Check = true;
                        }
                        if (figureSquare.FigureSquareDel is EnemySquare)
                        {
                            figureSquare.SpawnPlayerSquare();
                            Check = false;
                        }
                    }
                }
                if (figureCircles.CircleHasRemoved == true)
                {
                    if (figureCircles.FigureCircleDel != null)
                    {
                        if (figureCircles.FigureCircleDel is PlayerCircle)
                        {
                            figureCircles.SpawnPlayerCircle();
                            Check = false;
                        }

                        if (figureCircles.FigureCircleDel is BonusCircle)
                        {
                            Check = true;
                        }

                        if (figureCircles.FigureCircleDel is EnemyCircle)
                        {
                            figureCircles.SpawnPlayerCircle();
                            Check = false;
                        }
                    }

                }
            }

            scoreText.DisplayedString = $"| Scores: {Scores.ToString()} | Max scores: {MaxScores.ToString()} | Pause-P |";
            win.Draw(scoreText);
        }
    }
}