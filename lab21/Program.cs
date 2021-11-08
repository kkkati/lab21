using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace lab21
{
    class Program
    {
        static int[,] sad;
        static int m;
        static int n;
        static void Main(string[] args)
        {
            m = Convert.ToInt32(Console.ReadLine());
            n = Convert.ToInt32(Console.ReadLine());
            sad = new int[m, n];
            Thread sadov1 = new Thread(sadovnik1);
            Thread sadov2 = new Thread(sadovnik2);
            sadov1.Start();
            sadov2.Start();

            sadov1.Join();
            sadov2.Join();

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(sad[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void sadovnik1()
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (sad [i,j]==0)
                    {
                        sad[i, j] = 1;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        static void sadovnik2()
        {
            for (int i = n-1; i >= 0; i--)
            {
                for (int j = n-1; j >= 0; j--)
                {
                    if (sad[j, i] == 0)
                    {
                        sad[j, i] = 2;
                    }
                    Thread.Sleep(1);
                }
            }
        }
    }

}
