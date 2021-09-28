using System;

namespace Rubix
{
    class Cube
    {
        int[,] Faces = new int[9, 12]
        {
            { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
        };

        public int[,] LeftFace = new int[3,2] { { 0, 3 }, { 1, 3}, { 2, 3 } }; 

        public int[,] FrontTop = new int[3,2] { { 5, 3 }, { 5, 4}, { 5, 5 } }; 
        public int[,] FrontMiddle = new int[3,2] { { 4, 3 }, { 4, 4}, { 4, 5 } }; 
        public int[,] FrontBottom = new int[3,2] { { 3, 3 }, { 3, 4}, { 3, 5 } }; 

        public Cube()
        {

        }

        public void Rotate(int[,] points, int rotation)
        {
            /*Faces made up of 2 4 1x3 cords that need to be shifted 
             * e.g Front Inner TopLeftBottomRight
             *     Front Outer TopLeftBottomRight
             * Data needs to be shifted forwarded or backward to next slot 
             * Clock wise forward iteration through loop, anti is backwards
             */
        }

        public void Print()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    Console.Write(Faces[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
