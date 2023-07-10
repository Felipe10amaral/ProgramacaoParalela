// Felipe Amaral, Ana Carolina, Raphael Pereira e Bruno Manhães

using System;
using System.Threading;

public class T1
{
    public static void Main(string[] args)
    {
        Thread t1 = new Thread(mensagem1); // criando a thread 1 (passando por parametro o procedimento que essa thread vai executar)
        
        Thread t2 = new Thread(mensagem2); // criando a thread 12(passando por parametro o procedimento que essa thread vai executar)
        
        
        // iniciando a primeira thread
        t1.Start(); 
        
        Thread.Sleep(5000); // pausando a execucao da thread atual em 5 segundos
        
        t2.Start();
        
        // aguardando as threads terminarem
        t1.Join();
        t2.Join();
        
    }
    
    // procedimento para executar a mensagem
    public static void mensagem1() {
        Console.WriteLine("Programacao Paralela \n");
        
    }
    
    // procedimento para executar a mensagem
    public static void mensagem2() {
        Console.WriteLine("Sistemas de Informacao \n");
        
    }
}