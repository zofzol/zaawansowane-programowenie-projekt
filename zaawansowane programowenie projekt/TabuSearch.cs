using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaawansowane_programowenie_projekt
{
    public class TabuSearch
    {
        private int EvaluateHeuristic(int[,] matrix, int[] permutation)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int totalScore = 0;

            for (int r = 0; r < m; r++)
            {
                int first = -1;
                int last = -1;
                int count = 0;

                for (int c = 0; c < n; c++)
                {
                    if (matrix[r, permutation[c]] == 1)
                    {
                        if (first == -1) first = c;
                        last = c;
                        count++;
                    }
                }

                if (count > 0)
                {
                    int holes = (last - first + 1) - count;
                    totalScore += holes;
                }
            }
            return totalScore;
        }
        private int Evaluate(int[,] matrix, int[] permutation) 
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int totalErrors = 0;
            
            int[] reordered = new int[n]; //aktualnie badany rzad
            int[] pref = new int[n]; //ilosc jedynek miedzy poczatkiem wiersza a dana wartoscia

            for (int row=0; row<m; row++)
            {
                //sumy prefiksowe dla danego wiersz
                int totalOnesinRow = 0;
                for(int i=0; i<n; i++)
                {
                    reordered[i] = matrix[row, permutation[i]]; //na pierwsza pozycje wiersza reordered trafi odpowiednia wartość z kolumny oryginalnej macierzy
                    totalOnesinRow += reordered[i];//liczy ilosc jedynek w wierszu
                    pref[i] = totalOnesinRow; //ilosc jedynek so far trafia na miejsce w tablicy
                }

                if (totalOnesinRow == 0) continue;//jezeli nie ma 1 w weirszu to go skipujemy

                int minRowError = int.MaxValue; //licznik bledow w wierszu

                for (int start = 0; start < n; start++)
                {
                    if (reordered[start] == 0) continue; //jezeli to jest 0 to start nie moze byc na tej pozycji
                    if (start > 0 && reordered[start - 1] == 1) continue; //jedynka w ciagu nie bedzie lepsza

                    for (int end = start; end < n; end++)
                    {
                        if (reordered[end] == 0) continue; //jak wyzej
                        if (end < n - 1 && reordered[end + 1] == 1) continue;

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
                        int currentErrors = (windowLength - onesInWindow) + (totalOnesinRow - onesInWindow);//0 w srodku + 1 poza
                        
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

        private int[] Swap(int[] perm, int i, int j)
        {
            int[] newPerm = (int[])perm.Clone();
            (newPerm[i], newPerm[j]) = (newPerm[j], newPerm[i]);
            return newPerm;
        }

        public Solution Run(int[,] matrix, int iterations, int tabuLength, int neighborhood, int seed, int maxTime, BackgroundWorker bw)
        {
            int n = matrix.GetLength(1);
            Random rand = new Random(seed);

            int[] current = RandomPermutation(n, rand); //zmienna przechowujaca aktualny uklad kolumn
            int currentCost = Evaluate(matrix, current);

            int[] bestSolution = (int[])current.Clone();
            int bestCost = currentCost;

            Queue<(int, int)> tabuQueue = new Queue<(int, int)>();//lista indeksow do zmiany

            for (int iter = 0; iter < iterations; iter++)//dla iterations ilosci swapujemy
            {
                int progress = (int)((iter / (double)iterations) * 100);
                bw.ReportProgress(progress);
                int bestMoveCost = int.MaxValue; //najmniejsza wartosc dla danej iteracji
                (int, int) bestMove = (-1, -1); //kolumny do zamiany z najmniejszym bierzacym kosztem
                int[]? nextBestPerm = null; //uklad kolumn po zamianie bestMove

                for (int k = 0; k < neighborhood; k++)
                {
                    int i = rand.Next(n); 
                    int j = rand.Next(n);
                    if (i == j) continue;
                    var move = (Math.Min(i, j), Math.Max(i, j));


                    int[] candidate = Swap(current, i, j);
                    int candidateCost = EvaluateHeuristic(matrix, candidate);
                    bool isTabu = tabuQueue.Contains(move);

                    if (candidateCost < bestMoveCost && (!isTabu || candidateCost < bestCost))
                    {
                        bestMoveCost = candidateCost;
                        bestMove = move;
                        nextBestPerm = candidate;
                    }
                }

                if (nextBestPerm != null)
                {
                    current = nextBestPerm;
                    currentCost = Evaluate(matrix, current);


                    tabuQueue.Enqueue(bestMove);
                    if (tabuQueue.Count > tabuLength) tabuQueue.Dequeue();

                    if (currentCost < bestCost)
                    {
                        bestCost = currentCost;
                        bestSolution = (int[])current.Clone();
                    }
                }
            }

            return new Solution
            {
                Permutation = bestSolution,
                Cost = Evaluate(matrix, bestSolution)
            };
        }

    }

   
}
