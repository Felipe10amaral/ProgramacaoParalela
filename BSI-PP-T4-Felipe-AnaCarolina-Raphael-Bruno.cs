using System;
using System.Threading;

public class T4
{
    const int LINHA = 3;
     public static SemaphoreSlim semaforoSoma = new SemaphoreSlim(1);
     public static SemaphoreSlim semaforoSistema = new SemaphoreSlim(0);

    public static void Main(string[] args)
    {
        int[,] matriz = { { 2, 0, 0 }, { 1, 4, 0 }, { 1, 1, 1 } };
        int[] b = { 2, -3, 1 };
        int[] x = new int[LINHA];
        int i;

        Thread t1 = new Thread(() => CalculaSoma(matriz, x, semaforoSoma));
        Thread t2 = new Thread(() => CalculaSistema(matriz, x, b, semaforoSistema));

        // iniciando as threads
        t1.Start();
        t2.Start();

        // aguardando as threads executarem
        t1.Join();
        t2.Join();

        Console.WriteLine("\nSolucao:");
        for (i = 0; i < LINHA; i++)
        {
            Console.WriteLine($"x[{i}] = {x[i]}");
        }
    }

    public static void CalculaSoma(int[,] matriz, int[] x, SemaphoreSlim semaforoSoma)
    {
        int i,j,soma;

        for (i = 0; i < LINHA; i++)
        {
            semaforoSoma.Wait(); //Aguarda o semáforoSoma t1
            soma = 0;
            for (j = 0; j < LINHA; j++)
            {
                soma += matriz[i, j] * x[j];
            }
            x[i] = soma; // Armazena o somatório calculado
            semaforoSistema.Release(); // Libera t2 para calcular o sistema
        }
    }

    public static void CalculaSistema(int[,] matriz, int[] x, int[] b, SemaphoreSlim semaforoSistema)
    {
        int i;
        for (i = 0; i < LINHA; i++)
        {
            semaforoSistema.Wait(); // aguarda o semaforoSistema t2
            x[i] = (b[i] - x[i]) / matriz[i, i]; // Calcula o sistema
            semaforoSoma.Release(); // Libera t1 para calcular o próximo somatório
        }
    }
}
