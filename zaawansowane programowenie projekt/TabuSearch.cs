using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static zaawansowane_programowenie_projekt.Form1;

namespace zaawansowane_programowenie_projekt
{
    public class TabuSearch
    {
        // private int EvaluateHeuristic(int[,] matrix, int[] permutation)
        // {
        //     int m = matrix.GetLength(0);
        //     int n = matrix.GetLength(1);
        //     int totalScore = 0;
        //
        //     for (int r = 0; r < m; r++)
        //     {
        //         int first = -1;
        //         int last = -1;
        //         int count = 0;
        //
        //         for (int c = 0; c < n; c++)
        //         {
        //             if (matrix[r, permutation[c]] == 1)
        //             {
        //                 if (first == -1) first = c;
        //                 last = c;
        //                 count++;
        //             }
        //         }
        //
        //         if (count > 0)
        //         {
        //             int holes = (last - first + 1) - count;
        //             totalScore += holes;
        //         }
        //     }
        //     return totalScore;
        // }
        //
        private int[] reordered;
        private int[] pref;
        private int Evaluate(int[,] matrix, int[] permutation)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int totalErrors = 0;

            //int[] reordered = new int[n]; //aktualnie badany rzad
            //int[] pref = new int[n]; //ilosc jedynek miedzy poczatkiem wiersza a dana wartoscia

            for (int row = 0; row < m; row++)
            {
                int totalOnesinRow = 0;
                for (int i = 0; i < n; i++)
                {
                    reordered[i] = matrix[row, permutation[i]];
                    totalOnesinRow += reordered[i];
                    pref[i] = totalOnesinRow;
                }

            }

            for (int row = 0; row<m; row++)
            {
                //sumy prefiksowe dla danego wiersz
                int totalOnesinRow = 0;
                for (int i = 0; i<n; i++)
                {
                    reordered[i] = matrix[row, permutation[i]]; //na pierwsza pozycje wiersza reordered trafi odpowiednia wartość z kolumny oryginalnej macierzy
                    totalOnesinRow += reordered[i];//liczy ilosc jedynek w wierszu
                    pref[i] = totalOnesinRow; //ilosc jedynek so far trafia na miejsce w tablicy
                }

                if (totalOnesinRow == 0) continue;//jezeli nie ma 1 w weirszu to go skipujemy

                int minRowError = int.MaxValue; //licznik bledow w wierszu

                for (int start = 0; start < n; start++)
                {
                    for (int end = start; end < n; end++)
                    {
                        int onesInWindow;

                        if (start > 0)
                        {
                            onesInWindow = pref[end] - pref[start - 1];
                        }
                        else
                        {
                            onesInWindow = pref[end];
                        }

                        int windowLength = end - start + 1;

                        int currentErrors =
                            (windowLength - onesInWindow)
                            + (totalOnesinRow - onesInWindow);

                        if (currentErrors < minRowError)
                        {
                            minRowError = currentErrors;
                        }
                    }
                }

                totalErrors += minRowError;
            }

            return totalErrors;
        }

        private int[] RandomPermutation(int n, Random rand)
        {
            int[] perm = Enumerable.Range(0, n).ToArray();

            for (int i = n - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (perm[i], perm[j]) = (perm[j], perm[i]);
            }

            return perm;
        }

        //private int[] Swap(int[] perm, int i, int j)
        //{
        //    int[] newPerm = (int[])perm.Clone();
        //    (newPerm[i], newPerm[j]) = (newPerm[j], newPerm[i]);
        //    return newPerm;
        //}
        private int[] Shift(int[] perm, int from, int to)
        {
            int[] newPerm = (int[])perm.Clone();
            int temp = newPerm[from];

            if (from < to)
            {
                //elementy miedzy from i to przesuwają się o 1 w lewo
                Array.Copy(newPerm, from + 1, newPerm, from, to - from);
            }
            else if (from > to)
            {
                //elementy miedzy to i from przesuwają się o 1 w prawo
                Array.Copy(newPerm, to, newPerm, to + 1, from - to);
            }

            newPerm[to] = temp;
            return newPerm;
        }
        public Solution Run(int[,] matrix, int iterations, int tabuLength, int neighborhood, int seed, int maxStagnation, BackgroundWorker bw)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int n = matrix.GetLength(1);
            Random rand = new Random(seed);

            reordered = new int[n];
            pref = new int[n];

            int[] current = RandomPermutation(n, rand);
            int currentCost = Evaluate(matrix, current);

            int[] bestSolution = (int[])current.Clone();
            int bestCost = currentCost;

            
            // uzycie macierzy kadencji tabuTenure[i, j] przechowuje numer iteracji, do której zamiana i z j jest zakazana
            int[,] tabuTenure = new int[n, n];

            int noImprovementCount = 0; //ucieczka mode
            //int maxStagnation = 50;

            for (int iter = 0; iter < iterations; iter++)
            {
                if (bw.CancellationPending)
                {
                    stopwatch.Stop();
                    return new Solution { Permutation = bestSolution, Cost = bestCost, ExecutionTime = stopwatch.Elapsed };
                }

                int progress = (int)((iter / (double)iterations) * 100);
                bw.ReportProgress(progress, new ProgressData { Iteration = iter, Cost = currentCost });

                int bestAllowedCost = int.MaxValue;
                (int, int) bestMove = (-1, -1);
                int[] nextBestPerm = null;

                //generowanie ograniczonej liczby sasiadow
                for (int k = 0; k < neighborhood; k++)
                {
                    int i = rand.Next(n); // from
                    int j = rand.Next(n); //to
                    if (i == j) continue;

                    int[] candidate = Shift(current, i, j);
                    int candidateCost = Evaluate(matrix, candidate);

                    //sprawdzenie tabu
                    bool isTabu = tabuTenure[i, j] >= iter;

                    //ruch jest zaakceptowyny jezeli nie jest w tabu chyba ze jest ale bije globalny rekord
                    if (!isTabu || candidateCost < bestCost)
                    {
                        if (candidateCost < bestAllowedCost)
                        {
                            bestAllowedCost = candidateCost;
                            bestMove = (i, j);
                            nextBestPerm = candidate;
                        }
                    }
                }

                //najlepszy znalezxiony somsiad
                if (nextBestPerm != null)
                {
                    current = nextBestPerm;
                    currentCost = bestAllowedCost;

                    //dodanie do tabu
                    // tabuTenure[bestMove.Item1, bestMove.Item2] = iter + tabuLength;
                    // tabuTenure[bestMove.Item2, bestMove.Item1] = iter + tabuLength;
                    tabuTenure[bestMove.Item2, bestMove.Item1] = iter + tabuLength;

                    //najlepsze rozwiazanie globalne
                    if (currentCost < bestCost)
                    {
                        bestCost = currentCost;
                        bestSolution = (int[])current.Clone();
                        noImprovementCount = 0;
                    }
                    else
                    {
                        noImprovementCount++; 
                    }

                    if (noImprovementCount >= maxStagnation)
                    {
                        //mieszu miezu 1/3 kolumn 
                        int kicks = Math.Max(3, n / 3);

                        for (int p = 0; p < kicks; p++)
                        {
                            int r1 = rand.Next(n);
                            int r2 = rand.Next(n);
                            current = Shift(current, r1, r2); //przesuniecie elementoe

                            //zapisanie do tabu
                            tabuTenure[r2, r1] = iter + tabuLength;
                        }

                        currentCost = Evaluate(matrix, current); // Przeliczamy koszt po zaburzeniu

                        noImprovementCount = 0; // reset licznika
                    }
                }
            }

            stopwatch.Stop();

            return new Solution
            {
                Permutation = bestSolution,
                Cost = bestCost,
                ExecutionTime = stopwatch.Elapsed
            };
        }
    }
}