using System;

public class Program {
    public static void Main(string[] args) {
      const int n = 4;
      const int m = 5;
      int i,j;
      int[,] matriz;

      matriz = generateMatriz(n, m);

      for(i=0; i<n; i++) {
        for(j=0; j<m; j++){
            Console.Write(matriz[i,j] + " \t");
        }
        Console.WriteLine(); // pular linha
      }


    }

     public static int[,] generateMatriz(int line, int column) {
        int i, j;
        Random random = new Random();

        int[,] matriz = new int[line, column] ;

        for(i=0; i < line; i++){
            for(j=0; j<column; ++j) {
                matriz[i,j] = random.Next(1,21);
            }
        }

        return matriz;
    }
}

// \t em uma string, ele insere um espaço horizontal equivalente a um ou mais caracteres de tabulação

/* Random é uma classe que esta dentro da biblioteca de System
   Next é uma função estática que retorna valores entre os intervalos. Ex int(0 (valor incluso) ,10 (valor exclusivo))
*/
