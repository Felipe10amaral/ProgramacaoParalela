// Felipe Amaral, Ana Carolina, Bruno Manhães e Raphael Pereira

using System;

public class Program
{
   const int TAMANHO_VETOR = 20;
   const int MAX_PAR = 10;

   public static void gerarVetor(int[] vetor) {
    
    int i, numeroAux;
    string aux; // o método ReadLine devolve uma string
    
    Console.WriteLine("Entre com 10  numeros pares \n");
    for(i=0; i<MAX_PAR; i++) {

        do { //menu pegando so valores pares
          Console.Write($"Entre com {i + 1}º numero par: " );  
          aux = Console.ReadLine();
          numeroAux = int.Parse(aux); // converte uma string em um inteiro
        } while (numeroAux % 2 != 0);
        vetor[i] = numeroAux;
    }

    for(i=10; i<TAMANHO_VETOR; i++) {

        do { //menu pegando so valores impares
          Console.Write($"Entre com {i - 9}º numero impar: " );  
          aux = Console.ReadLine();
          numeroAux = int.Parse(aux);
        } while( numeroAux % 2 == 0);
        vetor[i] = numeroAux;
    }

   }

   public static void orgazinarVetor(int[] vetor) {
    int i, j ,auxiliar;

    for(i=0; i<TAMANHO_VETOR; i++) {  //percorrer vetor todo
        for(j=0; j<TAMANHO_VETOR - 1; j++){ 
            if(vetor[j] % 2 == 0 && vetor[j + 1] % 2 != 0) {  //verificando se o numero é par e se o proximo é impar
                auxiliar = vetor[j];  // trocas de posição
                vetor[j] = vetor[j + 1]; // trocando o proximo
                vetor[j + 1] = auxiliar;
            }
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
	   int[] vetor = new int[TAMANHO_VETOR];

       gerarVetor(vetor);
       Console.WriteLine("vetor sem organizar");
       imprimirVetor(vetor);
       Console.WriteLine("vetor organizado");
       orgazinarVetor(vetor);
       imprimirVetor(vetor);

    }

    
}