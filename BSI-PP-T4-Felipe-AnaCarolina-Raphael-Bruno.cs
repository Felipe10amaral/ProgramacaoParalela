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

        Thread t1 = new Thread(() => calcularSistema(matriz, x, b));
       // Thread t2 = new Thread(() => calcularSomatorio(matriz, x));

        t1.Start();
        //t2.Start();

        t1.Join();
        //t2.Join();

         for (int i = 0; i < LINHA; i++)
        {
            Console.WriteLine($"X{i}: {x[i]}");
        }


        Console.WriteLine("Terminado \n");
    }

    public static void calcularSistema(int[,] matriz, int[] x, int[] b)
    {
        int somatorio = 0;
        for (int i = 0; i < LINHA; i++)
        {
            
            
            for (int j = 0; j < i; j++)
            {
                somatorio = somatorio + (matriz[i, j] * x[j]);
            }
            x[i] = (b[i] - somatorio) / matriz[i, i];
            somatorio = 0;
        }
    }



    
}