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

        // iniciando as threads
        t1.Start();
        t2.Start();

        // aguardando as threads executarem
        t1.Join();
        t2.Join();

        // imprimindo o resultado
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
            int somatorio = CalcularSomatorio(matriz, x, i); // Passa o i como parâmetro
            x[i] = (b[i] - somatorio) / matriz[i, i];
            semaforoSomatorio.Release(); // Libera a thread t2 para o próximo cálculo
        }
    }

    public static int CalcularSomatorio(int[,] matriz, int[] x, int i = 0)
    {
        int j;
        int somatorio = 0;
        for (j = 0; j < i; j++)
        {
            somatorio = somatorio + (matriz[i, j] * x[j]);
        }
        semaforoSistema.Release(); // Libera o semáforo para o cálculo da próxima linha
        return somatorio;
    }
}