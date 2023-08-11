// Felipe Amaral, Ana Carolina, Raphael Pereira e Bruno Manhães

using System;
using System.Threading;

public class T3
{
    
    //semaforoSoma começa com 1 porque ele tem que ser executado primeiro
    public static SemaphoreSlim semaforoSoma = new SemaphoreSlim(1); // Semáforo para sincronizar soma, subtracao, multiplicao e divisao
    
    public static SemaphoreSlim semaforoSubtracao = new SemaphoreSlim(0); // Semáforo para sincronizar soma, subtracao, multiplicao e divisao
    
    public static SemaphoreSlim semaforoMultiplicacao = new SemaphoreSlim(0);
    // Semáforo para sincronizar soma, subtracao, multiplicao e divisao
    
    public static SemaphoreSlim semaforoDivisao = new SemaphoreSlim(0);
    // Semáforo para sincronizar soma, subtracao, multiplicao e divisao

    public static void Main(string[] args)
    {

        int numero1, numero2, loop;

        do {
            Console.WriteLine("Entre com o primeiro numero ");
            numero1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o segundo numero ");
            numero2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o numero de repeticoes");
            loop = int.Parse(Console.ReadLine());
        }
        while (loop <= 0 || numero2 <= 0 );

        Thread t1 = new Thread(() => processarOperacao(numero1, numero2, "soma", loop));
        Thread t2 = new Thread(() => processarOperacao(numero1, numero2, "subtracao", loop));
        
        Thread t3 = new Thread(() => processarOperacao(numero1, numero2, "multiplicacao", loop));
        
        Thread t4 = new Thread(() => processarOperacao(numero1, numero2, "divisao", loop));

        // Iniciando ambas as threads
        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();

        // Aguarda a t1 e t2 terminarem
        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();

        Console.WriteLine("Terminado");
    }

    public static void processarOperacao(int a, int b, string operacao, int loop)
    {
        for (int i = 0; i < loop; i++)
        {
            if (operacao == "soma")
            {
                semaforoSoma.Wait(); // Aguarda o semáforoSoma executar
                soma(a, b);
                semaforoSubtracao.Release(); // Libera o semaforoSubtracao
                
            }

            if (operacao == "subtracao")
            {
                semaforoSubtracao.Wait(); // Aguarda o semáforoSubtracao executar
                subtracao(a, b);
                 // Libera o semáforoMultiplicacao
                semaforoMultiplicacao.Release();
            }
            
            if (operacao == "multiplicacao")
            {
                semaforoMultiplicacao.Wait(); // Aguarda o semáforoMultiplicacao
                multiplicacao(a, b);
                semaforoDivisao.Release(); // Libera o semáforoDivisao
            }
            
            if (operacao == "divisao")
            {
                semaforoDivisao.Wait(); // Aguarda o semáforoDivisao
                divisao(a, b);
                semaforoSoma.Release(); // Libera o semáforoSoma se estiver algum loop
            }
        }
    }

    public static void soma(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a + b;
        tempo = random.Next(1, 11); // numeros aleatorios de 1 a 10
        
       

        Console.WriteLine($"Eu sou a Thread SOMA ({result})  e vou dormir por {tempo} segundos! \n");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos (Sleep: tempo de espera da thread)
        
        Console.WriteLine($"Eu sou a Thread SOMA ({result}). Já se passaram {tempo} segundos, então terminei!\n");
        
       

    }

    public static void subtracao(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a - b;
        tempo = random.Next(1, 11);  // numeros aleatorios de 1 a 20

        Console.WriteLine($"Eu sou a Thread SUBTRACAO ({result})  e vou dormir por {tempo} segundos! \n");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos (Sleep: tempo de espera da thread)
        
        Console.WriteLine($"Eu sou a Thread SUBTRACAO ({result}). Já se passaram {tempo} segundos, então terminei! \n");

    } 
    
    public static void multiplicacao(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a * b;
        tempo = random.Next(1, 11); // numeros aleatorios de 1 a 20

        Console.WriteLine($"Eu sou a Thread MULTIPLICACAO ({result})  e vou dormir por {tempo} segundos! \n");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos (Sleep: tempo de espera da thread)
        
        Console.WriteLine($"Eu sou a Thread MULTIPLICACAO ({result}). Já se passaram {tempo} segundos, então terminei! \n");

    } 
    
    public static void divisao(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a / b;
        tempo = random.Next(1, 11); // numeros aleatorios de 1 a 20

        Console.WriteLine($"Eu sou a Thread DIVISAO ({result})  e vou dormir por {tempo} segundos!\n");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos (Sleep: tempo de espera da thread)
        
        Console.WriteLine($"Eu sou a Thread DIVISAO ({result}). Já se passaram {tempo} segundos, então terminei!\n");

    } 
}
