// Felipe Amaral, Ana Carolina, Raphael Pereira e Bruno Manhães

using System;
using System.Threading;

public class T2
{
    public static void Main(string[] args){
        
        int numero1, numero2;       
        
        Console.WriteLine("Entre com o primeiro numero ");
        numero1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Entre com o segundo numero ");
        numero2 = int.Parse(Console.ReadLine());

        Thread t1 = new Thread(() => soma(numero1, numero2)); //utilizando função lambda para ficar menos verboso (jeito mais simplificado de disparar uma função)
        Thread t2 = new Thread(() => subtracao(numero1, numero2));
        Thread t3 = new Thread(() => divisao(numero1, numero2));
        Thread t4 = new Thread(() => multiplicacao(numero1, numero2));

        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start(); 
        t1.Join();
        t2.Join();
        t3.Join();
        t4.Join();  
 
    }

    public static void soma(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a + b;
        tempo = random.Next(1, 21);

        Console.WriteLine($"Eu sou a Thread SOMA ({result})  e vou dormir por {tempo} segundos!");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos
        
        Console.WriteLine($"Eu sou a Thread SOMA ({result}). Já se passaram {tempo} segundos, então terminei!");

    }

    public static void subtracao(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a - b;
        tempo = random.Next(1, 21);

        Console.WriteLine($"Eu sou a Thread SUBTRACAO ({result})  e vou dormir por {tempo} segundos!");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos
        
        Console.WriteLine($"Eu sou a Thread SUBTRACAO ({result}). Já se passaram {tempo} segundos, então terminei!");

    } 

    public static void divisao(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a / b;
        tempo = random.Next(1, 21);

        Console.WriteLine($"Eu sou a Thread DIVISAO ({result})  e vou dormir por {tempo} segundos!");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos
        
        Console.WriteLine($"Eu sou a Thread DIVISAO ({result}). Já se passaram {tempo} segundos, então terminei!");

    } 

    public static void multiplicacao(int a, int b) {
        int result, tempo;
        Random random = new Random();
        result = a * b;
        tempo = random.Next(1, 21);

        Console.WriteLine($"Eu sou a Thread MULTIPLICACAO ({result})  e vou dormir por {tempo} segundos!");

        Thread.Sleep(tempo * 1000); // converter o tempo de segundos para milisegundos
        
        Console.WriteLine($"Eu sou a Thread MULTIPLICACAO ({result}). Já se passaram {tempo} segundos, então terminei!");

    } 
}