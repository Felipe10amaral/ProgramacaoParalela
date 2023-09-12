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

        Thread t1 = new Thread(() => calcSistema(matriz, x, b));
        Thread t2 = new Thread(() => print(matriz));

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


    public static void print(int[,] matriz) {
        
        semaforoSomatorio.Wait();
        int i,j;
        for(i=0; i<LINHA; i++)
        {
            for(j=0; j<LINHA; j++)
            {
              Console.Write(matriz[i, j] + "\t"); 
            }
          Console.WriteLine(); // metodo para pular linha (para imprimir na tela)
        }
    }

    public static void calcSistema(int[,] matriz, int[] x, int[] b) {
        int i, j;
        
        for (i = 0; i < LINHA; i++)
        {
            int somatorio = 0;
            for (j = 0; j < i; j++)
            {
                somatorio += matriz[i, j] * x[j];
            }
            x[i] = (b[i] - somatorio) / matriz[i, i];
        }
        
        semaforoSomatorio.Release();
        Console.WriteLine("feito \n");
    }

    public static void CalcSomatorio(int[,] matriz, int[] x, int[] b)
    {
       
        int i, j;

        for (i = 0; i < LINHA; i++)
        {
            int somatorio = 0;
            for (j = 0; j < LINHA; j++)
            {
                somatorio += matriz[i, j] * x[j];
            }
            x[i] = (b[i] - somatorio) / matriz[i, i];
        }

        
    }
}