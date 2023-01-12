using SFML.Graphics;
using SFML.Window;
using System;

namespace CathTheSquare
{
    internal class Program
    {
        public static int ScreenWidth = 800;
        public static int ScreenHeight = 600;
        public static int xOy = 0;

        static RenderWindow win;
        static void Main()
        {
            win = new RenderWindow(new VideoMode(800, 600), "Square");
            win.SetFramerateLimit(75);
            win.Closed += Window_Closed;
            Game game = new Game();

            while (win.IsOpen == true)
            {
                win.Clear(new Color(230, 230, 230));
                win.DispatchEvents();
                game.Update(win);
                win.Display();
            }
        }
        private static void Window_Closed(object sender, EventArgs e) { win.Close(); }
    }
}