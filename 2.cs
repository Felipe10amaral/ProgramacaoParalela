// Felipe Amaral, Ana Carolina, Bruno Manhães e Raphael Pereira

using System;

class Program
{
    const int LINHA = 4;
    const int COLUNA = 4;

    public static int[,] gerarMatriz() {
        int[,] matriz = new int[LINHA, COLUNA];
        int i,j;
        Random random = new Random(); // instanciando o objeto random para gerar valores aleatorios
        
        for(i=0; i<LINHA; i++) {
            for(j=0; j<COLUNA; j++) {
                matriz[i,j] = random.Next(0,30); //gerando valores aleatorios onde o 0 é incluso e o 30 é excluso (0 a 29)
            }
        }

        return matriz;
    }

    public static void printMatriz(int[,] matriz) // função para imprimir a matriz
    {
        int i,j; 
        
        for(i=0; i<LINHA; i++)
        {
            for(j=0; j<COLUNA; j++)
            {
              Console.Write(matriz[i, j] + "\t"); // \t é o como se fosse a tecla tab no teclado (tabulação)
            }
          Console.WriteLine(); // metodo para pular linha (para imprimir na tela)
        }
    }

    public static int[,] calcularMatrizTransposta(int[,] matriz) {
        int[,] matrizTransposta = new int[LINHA, COLUNA];
        int i,j;

        for(i=0; i<LINHA; i++) { // percorrendo a matriz
            for(j=0; j<COLUNA; j++) {
                matrizTransposta[i,j] = matriz[j,i]; // transformando a linha da matriz em uma coluna 
            }
        }

        return matrizTransposta;
    }

    public static int[,] multiplicarMatriz(int[,] matriz1, int [,] matriz2) {
        int[,] resultMatriz = new int[LINHA, COLUNA];
        int i,j,k, sum=0;

        for(i=0; i<LINHA; i++) { //percorrendo a matriz para realizar a multiplicacao
            for(j=0; j<COLUNA; j++) {
                sum = 0;            // zerando o contador a cada loop
                for(k=0; k<COLUNA; k++) { // loop para realizar as operações entre as duas matrizes 
                    sum += matriz1[i,k] * matriz2[k,j]; // multiplicando a coluna da matriz 1 com a linha da matriz 2
                }
                resultMatriz[i,j] = sum;  // atualizando os valores da nova matriz
            }
        }

        return resultMatriz;
    }

    public static int verifyMatrizOrtogonal(int [,] matriz) {
        int i,j;

        int[,] matrizTransposta = calcularMatrizTransposta(matriz);
        int[,] resultMatriz = multiplicarMatriz(matriz, matrizTransposta);

        for(i=0; i<LINHA; i++) {
            for(j=0; j<COLUNA; j++) {
                if( i == j && resultMatriz[i,j] != 1){ // verifica se a diagonal da matriz for difente de 1 (matriz identidade possui a diagonal 1)
                    return 0; // retorna 0 se não for ortogonal (a condição acima esta testando erro, se não atender a condição ja se sabe que não é ortogonal)
                }
                if( i != j && resultMatriz[i,j] != 0){  //verifica se os outros elementos são diferentes de 0 ( se houver qualquer numero ja não é ortogonal)
                    return 0;
                }
            }
        }

        return 1; // retorna 1 se for ortogonal
    }

    public static void Main(string[] args)
    {
        int[,] matriz;
        int verifyIfMatrizIsOrtogonal;

        matriz = gerarMatriz();

        Console.WriteLine("Matriz 1");
        printMatriz(matriz);
        Console.WriteLine("\n");
        
        Console.WriteLine("Matriz Transposta");
        matriz = calcularMatrizTransposta(matriz);
        printMatriz(matriz);

        verifyIfMatrizIsOrtogonal = verifyMatrizOrtogonal(matriz);
        if(verifyIfMatrizIsOrtogonal == 1) {
            Console.WriteLine("A matriz é ortogonal \n");
        }
        else {
            Console.WriteLine("A matriz não é ortogonal \n");
        }

    } 
}


/*   
    Matriz transposta dá-se quando mudamos a posição das linhas e das colunas de uma matriz. 
    A notação utilizada para matriz transposta de A é At.

    uma matriz é ortogonal se sua matriz inversa coincide com sua matriz transposta


     matriz inversa  é um tipo de matriz quadrada, ou seja, que possui o mesmo número de 
     linhas (m) e colunas (n). Ela ocorre quando o produto de duas matrizes resulta numa matriz identidade 
     de mesma ordem (mesmo número de linhas e colunas).
*/