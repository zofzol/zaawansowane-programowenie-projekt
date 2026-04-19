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

            // mieszu mieszu sla kolumn
            int[] perm = Enumerable.Range(0, n).ToArray();

            for (int i = 0; i < n; i++)
            {
                int j = rand.Next(i, n);
                (perm[i], perm[j]) = (perm[j], perm[i]);
            }

            int[,] shuffled = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    shuffled[i, j] = matrix[i, perm[j]];
                }
            }

            Correct = (int[,])matrix.Clone();//bedzie przechowywachmacierz oryginalna przed wprowadzeniem bledow

            // wprowadzanie błędów
            for (int k = 0; k < errors; k++)
            {
                int i = rand.Next(m);
                int j = rand.Next(n);

                if (shuffled[i, j] == 1)
                {
                    shuffled[i, j] = 0;
                }
                else
                {
                    shuffled[i, j] = 1;
                }
            }

            return shuffled;
        }
    }
}
