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
        int[] x = new int[LINHA];
        int i;

        Thread t1 = new Thread(() => CalcularSistema(matriz, x, b));
        Thread t2 = new Thread(() => CalcularSomatorio(matriz, x));

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        for (i = 0; i < LINHA; i++)
        {
            Console.WriteLine($"X{i}: {x[i]}");
        }

        Console.WriteLine("Terminado \n");
    }

    public static void CalcularSistema(int[,] matriz, int[] x, int[] b)
    {
        int i;
        for (i = 0; i < LINHA; i++)
        {
            semaforoSistema.Wait(); // Aguarda permissão para cálculos
            x[i] = (b[i] - x[i]) / matriz[i, i]; // Usa x[i] como somatório
            semaforoSomatorio.Release(); // Libera a thread t2 para o próximo cálculo
        }
    }

    public static void CalcularSomatorio(int[,] matriz, int[] x)
    {
        int i,j;
        for (i = 0; i < LINHA; i++)
        {
            int tempSomatorio = 0;
            for (j = 0; j < i; j++)
            {
                tempSomatorio += (matriz[i, j] * x[j]);
            }
            x[i] = tempSomatorio;
            semaforoSistema.Release(); // Libera o semáforo para o cálculo da próxima linha
            if (i < LINHA - 1)
            {
                semaforoSomatorio.Wait(); // Aguarda a thread t1 calcular x[i+1]
            }
        }
    }
}
