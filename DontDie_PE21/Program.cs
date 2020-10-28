using System;

namespace DontDie_PE21
{
    class Program
    {
        static bool[,] neighborGraph = new bool[,]
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

        static int[][] neighborList = new int[][]
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


        static int[,] costGraph = new int[,]
        {//            A   B   C   D   E   F   G   H
        /* A (0) */ {  0, -1, -1, -1, -1, -1, -1, -1 },
        /* B (1) */ {  2, -1,  2,  3, -1, -1, -1, -1 },
        /* C (2) */ { -1,  2, -1,  5, -1, -1, -1, -1 },
        /* D (3) */ { -1,  3, -1, -1, -1, -1, -1, -1 },
        /* E (4) */ { -1, -1, -1,  2, -1, -1, -1, -1 },
        /* F (5) */ { -1, -1, -1,  4,  3, -1, -1, -1 },
        /* G (6) */ { -1, -1, -1, -1, -1,  1, -1, -1 },
        /* H (7) */ { -1, -1, 20, -1, -1, -1,  2, -1 }
        };
        static int[][] costList = new int[][]
        {
            new int[] { 0, 2 },
            new int[] { 2, 3 },
            new int[] { 2, 20 },
            new int[] { 3, 5, 2, 4 },
            new int[] { 3 },
            new int[] { 1 },
            new int[] { 2 },
            null
        };


        static string[,] directionGraph = new string[,]
        {//              A       B         C        D         E       F       G     H
        /* A (0) */ {   null,    null,    null,    null,    null,   null,    null, null},
        /* B (1) */ {"South",    null, "North",  "West",    null,   null,    null, null},
        /* C (2) */ {   null, "South",    null, "South",    null,   null,    null, null},
        /* D (3) */ {   null,  "East",    null,    null,    null,   null,    null, null},
        /* E (4) */ {   null,    null,    null, "North",    null,   null,    null, null},
        /* F (5) */ {   null,    null,    null,  "East", "South",   null,    null, null},
        /* G (6) */ {   null,    null,    null,    null,    null, "East",    null, null},
        /* H (7) */ {   null,    null,  "East",    null,    null,   null, "South", null}
        };
        static string[][] directionList = new string[][]
        {
            new string[] { "South" },
            new string[] { "South", "East" },
            new string[] { "North", "East" },
            new string[] { "West", "South", "North", "East" },
            new string[] { "South" },
            new string[] { "East" },
            new string[] { "South" },
            null
        };
        static void Main(string[] args)
        {
        }
    }
}