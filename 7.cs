// Felipe Amaral, Ana Carolina, Bruno Manhães e Raphael Pereira

using System;

class Program
{
    const int TAMANHO = 50;

    public static void PreencherVetor(int[] vetor, int index)
    {
        if (index == TAMANHO)
            return;

        Random random = new Random();
        vetor[index] = random.Next(1, 101); // preenchendo valores de um a 100 aleatoriamente

        PreencherVetor(vetor, index + 1); // chamando a mesma função com novos parametros
    }

    public static int EncontrarMaior(int[] vetor, int index, int maior)
    {
        if (index == TAMANHO) // compara se o valor atual do teste é igual ao tamanho maximo
            return maior;

        if (vetor[index] > maior) // teste para identificar o maior numero dentro do elemento de um vetor
            maior = vetor[index];

        return EncontrarMaior(vetor, index + 1, maior); // retorna o mesmo vetor com o valor o indice atualizado e chamando a mesma função com novos parametros
    }

    static void Main(string[] args)
    {
        int[] vetor = new int[TAMANHO];
        PreencherVetor(vetor, 0);

        int maiorValor = EncontrarMaior(vetor, 0, 0);

        Console.WriteLine("Maior valor: " + maiorValor);
    }
}