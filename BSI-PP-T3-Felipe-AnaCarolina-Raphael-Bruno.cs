// Felipe Amaral, Ana Carolina, Raphael Pereira e Bruno Manhães

using System;
using System.Threading;

public class T2
{
    public delegate void Operacao(int a, int b);

    static SemaphoreSlim semaforo = new SemaphoreSlim(0, 1);

    public static void Main(string[] args){
        
        int numero1, numero2, loop;       
        
        Console.WriteLine("Entre com o primeiro numero ");
        numero1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Entre com o segundo numero ");
        numero2 = int.Parse(Console.ReadLine());

        Console.WriteLine("Entre com o numero de repeticoes ");
        loop = int.Parse(Console.ReadLine());

        Thread t1 = new Thread(() => controleSemaforo(soma, loop, numero1, numero2)); //utilizando função lambda para ficar menos verboso (jeito mais simplificado de disparar uma função)
        Thread t2 = new Thread(() => controleSemaforo(subtracao, loop, numero1, numero2));
        Thread t3 = new Thread(() => controleSemaforo(multiplicacao, loop, numero1, numero2));
        Thread t4 = new Thread(() => controleSemaforo(divisao, loop, numero1, numero2));

       

            // iniciando as threads
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start(); 

            semaforo.Release(4);

            // Aguardando todas as threads terminarem de executar
            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();  

    }

    public static void controleSemaforo(Operacao operacao, int loop, int numero1, int numero2) {
        int i;

        semaforo.Wait();

        for(i=0; i<loop; i++) {
            operacao(numero1, numero2);
        }
        
    }

    public static void soma(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a + b;
        tempo = random.Next(1, 11); // numeros aleatorios de 1 a 10

        semaforo.WaitAsync();

        Console.WriteLine($"Eu sou a Thread SOMA ({result})  e vou dormir por {tempo} segundos!");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos (Sleep: tempo de espera da thread)
        
        Console.WriteLine($"Eu sou a Thread SOMA ({result}). Já se passaram {tempo} segundos, então terminei!");

        semaforo.Release();

    }

    public static void subtracao(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a - b;
        tempo = random.Next(1, 11);  // numeros aleatorios de 1 a 10

        semaforo.Wait();

        Console.WriteLine($"Eu sou a Thread SUBTRACAO ({result})  e vou dormir por {tempo} segundos!");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos (Sleep: tempo de espera da thread)
        
        Console.WriteLine($"Eu sou a Thread SUBTRACAO ({result}). Já se passaram {tempo} segundos, então terminei!");

        semaforo.Release();

    } 

    public static void divisao(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a / b;
        tempo = random.Next(1, 11); // numeros aleatorios de 1 a 10

        semaforo.Wait();

        Console.WriteLine($"Eu sou a Thread DIVISAO ({result})  e vou dormir por {tempo} segundos!");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos (Sleep: tempo de espera da thread)
        
        Console.WriteLine($"Eu sou a Thread DIVISAO ({result}). Já se passaram {tempo} segundos, então terminei!");

        semaforo.Release();
    } 

    public static void multiplicacao(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a * b;
        tempo = random.Next(1, 11); // numeros aleatorios de 1 a 10

        semaforo.Wait();

        Console.WriteLine($"Eu sou a Thread MULTIPLICACAO ({result})  e vou dormir por {tempo} segundos!");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos (Sleep: tempo de espera da thread)
        
        Console.WriteLine($"Eu sou a Thread MULTIPLICACAO ({result}). Já se passaram {tempo} segundos, então terminei!");

        semaforo.Release();
    } 
}