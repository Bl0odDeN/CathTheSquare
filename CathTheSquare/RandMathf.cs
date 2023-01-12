using System;

namespace CathTheSquare
{
    internal static class RandMathf
    {
        private static Random r = new Random();
        private static object l = new object();

        public static int LockedRand(int min, int max)
        {
            int result;
            lock (RandMathf.l)
            {
                result = RandMathf.r.Next(min, max);
            }
            return result;
        }
    }
}