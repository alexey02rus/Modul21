using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {

        const int n1 = 10;
        const int n2 = 10;
        const string check = "NoCl";
        static int[,] Path()
        {
            Random random = new Random();
            int[,] path = new int[n1, n2];
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    path[i, j] = random.Next(0, 50);
                }
            }
            return path;
        }
        static string[,] PathCheck()
        {
            string[,] pathCheck = new string[n1, n2];
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    pathCheck[i, j] = check;
                }
            }
            return pathCheck;
        }
        static string[,] pathCheck = PathCheck();

        static void Main(string[] args)
        {
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    Console.Write("{0,4}", Path()[i,j]);
                }
                Console.WriteLine();
            }
            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    Console.Write("{0,5}", PathCheck()[i, j]);
                }
                Console.WriteLine();
            }

            ThreadStart threadStart = new ThreadStart(Gardner1);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner2();

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    Console.Write("{0,4}",pathCheck[i,j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
        static void Gardner1()
        {
            for (int i = 0; i < n1; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < n2; j++)
                    {
                        if (pathCheck[i, j] == check)
                        {
                            pathCheck[i, j] = "G1";
                            Thread.Sleep(Path()[i, j]);
                        }
                    }
                }
                else
                {
                    for (int j = n2-1; j >= 0; j--)
                    {
                        if (pathCheck[i, j] == check)
                        {
                            pathCheck[i, j] = "G1";
                            Thread.Sleep(Path()[i, j]);
                        }
                    }
                }
            }
        }
        static void Gardner2()
        {
            for (int j = n2-1; j >= 0; j--)
            {
                if (j % 2 == 0)
                {
                    for (int i = 0; i < n1; i++)
                    {
                        if (pathCheck[i, j] == check)
                        {
                            pathCheck[i, j] = "G2";
                            Thread.Sleep(Path()[i, j]);
                        }
                    }
                }
                else
                {
                    for (int i = n1-1; i >= 0; i--)
                    {
                        if (pathCheck[i, j] == check)
                        {
                            pathCheck[i, j] = "G2";
                            Thread.Sleep(Path()[i, j]);
                        }
                    }
                }
            }
        }
    }
}
