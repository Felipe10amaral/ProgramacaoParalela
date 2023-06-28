// Felipe Amaral, Ana Carolina, Bruno Manhães e Raphael Pereira

using System;

public class Program
{
   const int TAMANHO = 20;
   const int MAX_PAR = 10;

   public static void gerarVetor(int[] vetor) {
    
    int i, numeroAux;
    string aux;
    
    Console.WriteLine("Entre com 10  numeros pares \n");
    for(i=0; i<MAX_PAR; i++) {

        do {
          Console.Write($"Entre com {i + 1}º numero par: " );  
          aux = Console.ReadLine();
          numeroAux = int.Parse(aux);
        } while (numeroAux % 2 != 0);
        vetor[i] = numeroAux;
    }

    for(i=10; i<TAMANHO; i++) {

        do {
          Console.Write($"Entre com {i - 9}º numero impar: " );  
          aux = Console.ReadLine();
          numeroAux = int.Parse(aux);
        } while( numeroAux % 2 == 0);
        vetor[i] = numeroAux;
    }

   }

   public static void orgazinarVetor(int[] vetor) {
    int i,j=0;

    for(i=0; i<TAMANHO; i++) {
        if(vetor[i] % 2 != 0) {
            vetor[i] = vetor[j+1];
        }
        
    }
   }

   public static void imprimirVetor(int[] vetor)
    {
        foreach (int numero in vetor)
            Console.Write(numero + " ");
        Console.WriteLine();
    }

   public static void Main()
    {
	   int[] vetor = new int[TAMANHO];

       gerarVetor(vetor);
       Console.WriteLine("vetor sem organizar");
       imprimirVetor(vetor);
       Console.WriteLine("vetor organizado");
       orgazinarVetor(vetor);
       imprimirVetor(vetor);

    }

    
}