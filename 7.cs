/* Considere um vetor com 50 números inteiros gerados aleatoriamente de 1 até 100. Faça um algoritmo
recursivo para imprimir o maior valor deste vetor.
Crie e utilize uma função para preencher o vetor e uma função recursiva para encontrar o maior valor do
vetor. Esta informação tem que ser impressa na função main.
Obs. 1: Não é permitido utilizar qualquer estrutura de dados auxiliar;
Obs. 2: Não é permitido utilizar qualquer estrutura de repetição na função recursiva.

*/

using System;

class Program
{
    const int SIZE = 50;

    static void PreencherVetor(int[] vetor, int index)
    {
        if (index == SIZE)
            return;

        Random random = new Random();
        vetor[index] = random.Next(1, 101);

        PreencherVetor(vetor, index + 1);
    }

    static int EncontrarMaior(int[] vetor, int index, int maior)
    {
        if (index == SIZE)
            return maior;

        if (vetor[index] > maior)
            maior = vetor[index];

        return EncontrarMaior(vetor, index + 1, maior);
    }

    static void Main(string[] args)
    {
        int[] vetor = new int[SIZE];
        PreencherVetor(vetor, 0);

        Console.Write("Valores do vetor: ");
        foreach (int num in vetor)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();

        int maiorValor = EncontrarMaior(vetor, 0, 0);

        Console.WriteLine("Maior valor: " + maiorValor);
    }
}