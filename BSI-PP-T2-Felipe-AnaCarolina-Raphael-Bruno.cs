// Felipe Amaral, Ana Carolina, Raphael Pereira e Bruno Manhães

using System;
using System.Threading;

public class T2
{
    public static void Main(string[] args){
        
        int n1, n2, tempo;
        Random random = new Random();
        
        Console.WriteLine("Entre com o primeiro numero ");
        n1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Entre com o segundo numero ");
        n2 = int.Parse(Console.ReadLine());

        tempo = random.Next(1, 21);

        Console.WriteLine($"n1: {n1}");
        Console.WriteLine($"tempo: {tempo}");
    }
}