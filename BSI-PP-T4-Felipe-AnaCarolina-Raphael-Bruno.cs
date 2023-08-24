using System;
using System.Threading;

class T4
{
    public static SemaphoreSlim semaforoSistema = new SemaphoreSlim(1);
    public static SemaphoreSlim semaforoSomatorio = new SemaphoreSlim(0);
    const int LINHA = 3;

    public static void Main(string[] args)
    {
        int[,] matriz = { { 2, 0, 0 }, { 1, 4, 0 }, { 1, 1, 1 } };
        int[] b = { 2, -3, 1 };
        int[] x = new int[3];

        Thread t1 = new Thread(() => Semaforo(matriz, x, b));
        Thread t2 = new Thread(() => Semaforo(matriz, x, b));

        // Iniciando ambas as threads
        t1.Start();
        t2.Start();

        // Aguarda a t1 e t2 terminarem
        t1.Join();
        t2.Join();

        for (int i = 0; i < x.Length; i++)
        {
            Console.WriteLine($"X{i}: {x[i]}");
        }

        Console.WriteLine("Terminado \n");
    }

    public static void Semaforo(int[,] matriz, int[] x, int[] b)
    {
        semaforoSistema.Wait();
        CalcSistema(matriz, x, b);
        semaforoSistema.Release();

        semaforoSomatorio.Wait();
        CalcSomatorio(matriz, x, b);
        semaforoSomatorio.Release();
    }

    public static void CalcSistema(int[,] matriz, int[] x, int[] b)
    {
        int i, j, somatorio = 0;

        for (i = 0; i < LINHA; i++)
        {
            for (j = 0; j < i; j++)
            {
                somatorio += matriz[i, j] * x[j];
            }
            x[i] = (b[i] - somatorio) / matriz[i, i];
            somatorio = 0;
        }
    }

    public static void CalcSomatorio(int[,] matriz, int[] x, int[] b)
    {
        semaforoSistema.Wait();
        int i, j, somatorio = 0;

        for (i = 0; i < LINHA; i++)
        {
            for (j = 0; j < i; j++)
            {
                somatorio += matriz[i, j] * x[j];
            }
            x[i] = (b[i] - somatorio) / matriz[i, i];
            somatorio = 0;
        }

        semaforoSistema.Release();
    }
}