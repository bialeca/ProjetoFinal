using ProjetoElevador1.Model;
using System;

namespace ProjetoElevador1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Elevador elevador = new();

            Console.WriteLine("SEJA BEM VINDO AO EDIFÍCIO DA FELICIDADE");
          
            ConsoleKeyInfo Operador;
            Console.WriteLine("    Oi, tudo bem? Me conta, quantos andares o edifício tem ?");

            int novosAndares = int.Parse(Console.ReadLine());

            Console.WriteLine("    Agora me fala, quantas pessoas cabem no elevador?");

            int novaCapacidade = int.Parse(Console.ReadLine());
            Console.Clear();

            elevador.AndaresDoPredio = novosAndares;
            elevador.Capacidade = novaCapacidade;
            do
            {

                ImprimeStatusMenu(elevador);
                //NA LINHA ABAIXO O PROGRAMA IRÁ CAPTURAR A TECLA PARA REALIZAR UM COMANDO 
                Operador = Console.ReadKey();
                Console.Clear();
                Console.WriteLine("");
                //NO SWITCH A BAIXO O PROGRAMA IRÁ IDENTIFICAR A TECLA PRESSIONADA E DIRECIONAR A SUA DEVIDA FUNÇÃO
                switch (Operador.Key)
                {
                    //SUBINDO OS ANDARES
                    case ConsoleKey.UpArrow:

                        if (elevador.OndeEsta() < elevador.AndaresDoPredio)
                        {


                            Console.WriteLine("ELEVADOR SUBINDO ");
                            elevador.Subir();
                        }
                        else
                        {
                            //SE NAO TIVER MAIS COMO SUBIR ELE AVISA QUE ESTÁ NA COBERTURA
                            Console.WriteLine("NÃO DÁ MAIS PRA SUBIR, ESTAMOS NA COBERTURA");

                        }

                        break;


                    //DESCENDO OS ANDARES
                    case ConsoleKey.DownArrow:


                        if (elevador.OndeEsta() == 0)
                        {
                            Console.WriteLine(" NÃO DÁ MAIS PRA DESCER, ESTAMOS NO TÉRREO");
                        }
                        else 
                        { 
                            Console.WriteLine("DESCENDO UM ANDAR");
                            elevador.Descer();
                        }
                        break;

                    //PESSOAS ENTRANDO NO ELEVADOR
                    case ConsoleKey.E:

                        //SO PODERÁ ENTRAR PESSOAS SE TIVER VAGAS E FOR MAIOR QUE 0
                        if (elevador.QuantasVagas() > 0)
                        {

                            Console.WriteLine("ENTRANDO UMA PESSOA NO ELEVADOR");
                            elevador.Entrar("PESSOA", 1);
                        }
                        else
                        {
                            //INFORMA CAPACIDADE MAXIMA
                            Console.WriteLine("A " + elevador.Vagas() + "ª PESSOA ENTROU, O ELEVADOR ESTÁ CHEIO");
                        }

                        break;



                    case ConsoleKey.S:

                        if (elevador.Vagas() > 0)
                        {
                            //SAÍDA DE PESSOAS

                            Console.WriteLine("SAINDO UMA PESSOA DO ELEVADOR");
                            elevador.Sair();
                        }
                        else 
                        {
                            //QUANDO TIVER 0 PESSOAS NO ELEVADOR ELE AVISA
                            Console.WriteLine("NÃO TEM MAIS NINGUEM PRA SAIR, O ELEVADOR JÁ ESTÁ VAZIO");
                        }
                        break;

                }
            } while (Operador.Key != ConsoleKey.Escape);


        }

        //Parte onde o cliente vê e status do elevador e digita suas opções
        static void ImprimeStatusMenu(Elevador elevador)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("*****************************PAINEL DO ELEVADOR:********************************");
            Console.WriteLine("     O Edifício Felicidade tem " + elevador.AndaresDoPredio + " andares.");
            Console.WriteLine("     Você está no " + elevador.AndarAtual + "º andar.");
            Console.WriteLine("     A capacidade máxima do elevador é de " + elevador.Capacidade + " pessoas.");
            Console.WriteLine("     Atualmente tem " + elevador.Vagas() + " pessoas no elevador.");
            Console.WriteLine("********************************************************************************");

            Console.WriteLine();

            Console.WriteLine("*****************************PAINEL DE CONTROLE:********************************");
            Console.WriteLine("     Para as pessoas entrarem no elevador digite            E  ");
            Console.WriteLine("     Para as pessoas sairem do elevador digite              S   ");
            Console.WriteLine("     Para subir um andar aperte                             Seta para Cima");
            Console.WriteLine("     Para descer um andar aperte                            Seta para baixo");
            Console.WriteLine("     Para desligar o Elevador aperte                        ESC");
            Console.WriteLine("********************************************************************************");
            Console.WriteLine();
            Console.WriteLine("         O que deseja fazer:");
        }
    }
}