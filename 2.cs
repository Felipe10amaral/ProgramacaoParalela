/* Considere uma matriz M de ordem 4 de números inteiros gerados aleatoriamente de 0 até 29. Faça um
algoritmo para gerar esta matriz e imprimir na tela se ela é ou não uma Matriz Ortogonal.
Crie e utilize quatro funções: uma para gerar a matriz M, outra para calcular a sua Matriz Transposta
(MT
), outra calcular a multiplicação M × MT
e a quarta para retornar se a matriz M é Ortogonal ou não. A
impressão desta informação tem que ser na função main.
Obs.: Se uma matriz quadrada M é uma matriz ortogonal, então M × MT = I, onde MT
é a Matriz
Transposta de M e I a Matriz Identidade. */

using System;

class Program
{
    const int LINE = 4;
    const int COLUMN = 4;

    public static int[,] generateMatriz() {
        int[,] matriz = new int[LINE, COLUMN];
        int i,j;
        Random random = new Random();
        
        for(i=0; i<LINE; i++) {
            for(j=0; j<COLUMN; j++) {
                matriz[i,j] = random.Next(0,30);
            }
        }

        return matriz;
    }

    public static void printMatriz(int[,] matriz)
    {
        int i,j; 
        
        for(i=0; i<LINE; i++)
        {
            for(j=0; j<COLUMN; j++)
            {
              Console.Write(matriz[i, j] + "\t");
            }
          Console.WriteLine();
        }
    }

    public static int[,] calculateMatrizTransposta(int[,] matriz) {
        int[,] matrizTransposta = new int[LINE, COLUMN];
        int i,j;

        for(i=0; i<LINE; i++) {
            for(j=0; j<COLUMN; j++) {
                matrizTransposta[i,j] = matriz[j,i];
            }
        }

        return matrizTransposta;
    }

    public static int[,] multiplyMatriz(int[,] matriz1, int [,] matriz2) {
        int[,] resultMatriz = new int[LINE, COLUMN];
        int i,j,k, sum=0;

        for(i=0; i<LINE; i++) {
            for(j=0; j<COLUMN; j++) {
                sum = 0;
                for(k=0; k<COLUMN; k++) {
                    sum += matriz1[i,k] * matriz2[k,j];
                }
                resultMatriz[i,j] = sum;
            }
        }

        return resultMatriz;
    }

    public static int verifyMatrizOrtogonal(int [,] matriz) {
        int i,j;

        int[,] matrizTransposta = calculateMatrizTransposta(matriz);
        int[,] resultMatriz = multiplyMatriz(matriz, matrizTransposta);

        for(i=0; i<LINE; i++) {
            for(j=0; j<COLUMN; j++) {
                if( i == j && resultMatriz[i,j] != 1){
                    return 0;
                }
                if( i != j && resultMatriz[i,j] != 0){
                    return 0;
                }
            }
        }

        return 1;
    }

    public static void Main(string[] args)
    {
        int[,] matriz;
        int verifyIfMatrizIsOrtogonal;

        matriz = generateMatriz();

        Console.WriteLine("Matriz 1");
        printMatriz(matriz);
        Console.WriteLine("\n");
        
        Console.WriteLine("Matriz Transposta");
        matriz = calculateMatrizTransposta(matriz);
        printMatriz(matriz);

        verifyIfMatrizIsOrtogonal = verifyMatrizOrtogonal(matriz);
        if(verifyIfMatrizIsOrtogonal == 1) {
            Console.WriteLine("A matriz é ortogonal \n");
        }
        else {
            Console.WriteLine("A matriz não é ortogonal \n");
        }

       // bool ehOrtogonal = VerificarMatrizOrtogonal(matriz);

       /* if (ehOrtogonal)
            Console.WriteLine("A matriz é ortogonal.");
        else
            Console.WriteLine("A matriz não é ortogonal."); */
    } 
}


/*   
    Matriz transposta dá-se quando mudamos a posição das linhas e das colunas de uma matriz. 
    A notação utilizada para matriz transposta de A é At.

    uma matriz é ortogonal se sua matriz inversa coincide com sua matriz transposta
*/