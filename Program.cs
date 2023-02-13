using System;
using System.Threading;

namespace StopWatch
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Método principal que inicia chamando o método "Menu()"
            Menu();
        }

        /*Método "Menu()" é responsável por escrever o menu e outras funcionalidades comentadas abaixo*/
        static void Menu()
        {
            /*Começa limpando o console e escrevendo as opções e instruções do menu*/
            Console.Clear();
            Console.WriteLine("Quanto tempo deseja contar?(EXP: 10s)");
            Console.WriteLine("S = Segundos => 10s = 10 segundos");
            Console.WriteLine("M = Minutos => 1m = 1 minuto");
            Console.WriteLine("0 = Sair");
            
            /*Pega o valor do "ReadLine e salva na váriavel "data" com formatação em minusculo*/
            string data = Console.ReadLine().ToLower();
            /*O valor da variavel "type" é o ultimo caractere da váravel "data"*/
            char type = char.Parse(data.Substring(data.Length - 1, 1));
            /*A váriavel "time" irá pegar o valor númerico digitado pelo usuario na variavel data*/
            int time = int.Parse(data.Substring(0, data.Length - 1));
            /*Valor ao qual a variavel "time" será multipicada*/
            int multiplier = 1;

            /*Se o caractere final for "m"(de minutos) o valor de time será multiplicado por 60*/
            if(type == 'm')
            {
                multiplier = 60;
            }
            /*Se o caractere for 0 o programa será encerrado*/
            if(time == 0)
            {
                System.Environment.Exit(0);
            }
            
            /*Chama o método "PreStart()" multiplicando a várivel "time" pelo multiplicado "multiplier"*/
            PreStart(time * multiplier);
        }

        /*Método com preparação para iniciar a contagem do cronômetro, com intervalos entre as mensagens logo após irá executar o
        método "Start()" com "time" como variavel parametro*/
        static void PreStart(int time)
        {
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go...");
            Thread.Sleep(2500);

            Start(time);
        }

        //Método "Start()" tem como função iniciar a contagem
        static void Start(int time)
        {
            //Variavel do tempo atual
            int currentTime = 0;

            /*Enquanto valor de "currentTime" for diferente da variavel parametro "time" o While irá limpar o console,
            adicionar +1 a variavel "currentTime" e exibir-lá no console, com intervalo de tempo de 1 segundo passado pelo "Thread.Sleep"*/
            while(currentTime != time)
            {
                Console.Clear();
                currentTime++;
                Console.WriteLine(currentTime);
                Thread.Sleep(1000);
            }

            /*Após sair do laço "While" a contagem será limpada e aparecerar a mensagem que o StopWatch está finalizando,
            terá um intervalo de 2.5 segundos e re-executará o método "Menu()"*/
            Console.Clear();
            Console.WriteLine("StopWatch finalizado...");
            Thread.Sleep(2500);
            Menu();
        }
    }
}