using System;

namespace DontDie_PE21
{
    class Program
    {
        static bool[,] matrixGraph = new bool[,]
        {//            A      B      C      D      E      F      G     H
        /* A (0) */ { true, false, false, false, false, false, false, false },
        /* B (1) */ { true, false, true, true, false, false, false, false },
        /* C (2) */ { false, true, false, true, false, false, false, false },
        /* D (3) */ { false, true, false, false, false, false, false, false },
        /* E (4) */ { false, false, false, true, false, false, false, false },
        /* F (5) */ { false, false, false, true, true, false, false, false },
        /* G (6) */ { false, false, false, false, false, true, false, false },
        /* H (7) */ { false, false, true, false, false, false, true, false }
        };

        static int[][] matrixList = new int[][]
        {
            new int[] { 0, 1 },
            new int[] { 2, 3 },
            new int[] { 1, 7 },
            new int[] { 1, 2, 4, 5 },
            new int[] { 5 },
            new int[] { 6 },
            new int[] { 7 },
            null
        };
        static void Main(string[] args)
        {
        }
    }
}
