using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zaawansowane_programowenie_projekt
{
    public class TabuSearch
    {
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

        private int[] RandomPermutation(int n)
        {
            Random rand = new Random();
            return Enumerable.Range(0, n).OrderBy(x => rand.Next()).ToArray();
        }

        private int[] Swap(int[] perm, int i, int j)
        {
            int[] newPerm = (int[])perm.Clone();
            (newPerm[i], newPerm[j]) = (newPerm[j], newPerm[i]);
            return newPerm;
        }

        public Solution Run(int[,] matrix, int iterations, int tabuLength, int neighborhood, int seed, int maxTime)
        {
            int n = matrix.GetLength(1);
            Random rand = new Random();

            int[] current = RandomPermutation(n); 
            int currentCost = Evaluate(matrix, current);

            int[] bestSolution = (int[])current.Clone();
            int bestCost = currentCost;



            return new Solution
            {
                Permutation = bestSolution,
                Cost = bestCost
            };
        }

    }

   
}
