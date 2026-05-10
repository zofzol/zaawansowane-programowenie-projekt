using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaawansowane_programowenie_projekt
{
    public class InstanceGenerator
    {
        private Random rand = new Random();
        public int[,] Correct { get; private set; }

        public int[,] Generate(int m, int n, int errors)
        {
            //generowanie macierzy idealnej
            int[,] matrix = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                int start = rand.Next(0, n);
                int end = rand.Next(start, n);

                for (int j = start; j <= end; j++)
                {
                    matrix[i, j] = 1;
                }
            }

            Correct = (int[,])matrix.Clone();//bedzie przechowywachmacierz oryginalna przed wprowadzeniem bledow

            // wprowadzanie błędów
            int addedErrors = 0;

            int maxAttempts = errors * 100;
            int attempts = 0;

            while (addedErrors < errors)
            {
                attempts++;
                int row = rand.Next(0, m);
                int col = rand.Next(0, n);

                if (TryAddError(matrix, row, col, n))
                {
                    addedErrors++;
                }
            }


            // mieszu mieszu sla kolumn
            // int[] perm = Enumerable.Range(0, n).ToArray();
            //
            // for (int i = 0; i < n; i++)
            // {
            //     int j = rand.Next(i, n);
            //     (perm[i], perm[j]) = (perm[j], perm[i]);
            // }
            //
            // int[,] shuffled = new int[m, n];
            //
            // for (int i = 0; i < m; i++)
            // {
            //     for (int j = 0; j < n; j++)
            //     {
            //         shuffled[i, j] = matrix[i, perm[j]];
            //     }
            // }
            //
            //return shuffled;
            return matrix;
        }

        private bool TryAddError(int[,] matrix, int row, int col, int maxCols)
        {
            int currentValue = matrix[row, col];

            //sprawdzenie sasiadow
            bool hasLeftNeighbor = col > 0;
            bool hasRightNeighbor = col < maxCols - 1;

            int leftVal = hasLeftNeighbor ? matrix[row, col - 1] : -1;
            int rightVal = hasRightNeighbor ? matrix[row, col + 1] : -1;

            //0-> tylko jesli nie brzegowre
            if (currentValue == 0)
            {
                if (leftVal == 1 || rightVal == 1)
                {
                    return false; 
                }
            }
            // analogicznie dla 1
            else if (currentValue == 1)
            {
                if (leftVal != 1 || rightVal != 1)
                {
                    return false; 
                }
            }

            //zmiana bitu
            matrix[row, col] = 1 - currentValue;
            return true;
        }
    }
}
