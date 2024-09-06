using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_da_Velha
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] matriz = new string[3, 3];
            string turno = "X";

            List<string> indexNumeros = new List<string> { };

            int index = 1;

            int tentativas = 1;

            ImprimirTituloDoJogo();

            index = AlimentarMatriz(matriz, indexNumeros, index);

            ImprimirMatriz(matriz);

            EscolherJogada(turno);

            string jogada = Console.ReadLine();

            Console.Clear();

            //Começa o jogo.
            while (tentativas < 9)
            {
                ImprimirTituloDoJogo();

                SubstituirValorRespectivaCasa(matriz, turno, indexNumeros, jogada);

                ImprimirMatriz(matriz);

                CondicaoVitoriaDiagonais(matriz, turno);

                CondicaoVitoriaLinhas(matriz, turno);

                CondicaoVitoriaColunas(matriz, turno);

                turno = VerificacaoTurnoAtual(turno);

                Console.WriteLine();

                EscolherJogada(turno);
                jogada = Console.ReadLine();

                while (!indexNumeros.Contains(jogada))
                {
                    Console.WriteLine();

                    Console.Write("Jogada Inválida, tente de novo: ");
                    jogada = Console.ReadLine();
                }

                tentativas++;

                Console.Clear();
            }
            if (tentativas == 9)
            {
                ImprimirTituloDoJogo();

                ImprimirMatriz(matriz);

                MensagemEmpate();
            }

            Console.ReadLine();
        }
        private static void ImprimirTituloDoJogo()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("   JOGO DA VELHA ");
            Console.WriteLine("--------------------");
        }
         private static int AlimentarMatriz(string[,] matriz, List<string> indexNumeros, int index)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                //Substiruir o valor na sua respectiva casa.
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = index.ToString();
                    indexNumeros.Add(index.ToString());
                    index++;
                }
            }

            return index;
        }
        private static void ImprimirMatriz(string[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($" [{matriz[i, j]}] ");
                }
                Console.WriteLine();
            }
        }
        private static void MensagemGanhador(string turno)
        {
            Console.WriteLine("\n------------");
            Console.WriteLine("Fim de Jogo!");
            Console.WriteLine("------------");
            Console.WriteLine($"\nParabéns!! o ganhador é [{turno}]");
        }
        private static void MensagemEmpate()
        {
            Console.WriteLine("\n------------");
            Console.WriteLine("Fim de Jogo!");
            Console.WriteLine("------------");
            Console.WriteLine($"\nO jogo deu Empate!. ");
        }
         private static void EscolherJogada(string turno)
        {
            Console.WriteLine($"\nVocê quer jogar [{turno}] em qual posição? ");
        }
         private static void SubstituirValorRespectivaCasa(string[,] matriz, string turno, List<string> indexNumeros, string jogada)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == jogada && indexNumeros.Contains(jogada))
                    {
                        matriz[i, j] = turno;
                        indexNumeros.Remove(jogada);
                    }
                }
            }
        }
         private static void CondicaoVitoriaDiagonais(string[,] matriz, string turno)
        {
            if (matriz[0, 0] == matriz[1, 1] && matriz[1, 1] == matriz[2, 2] ||
                matriz[0, 2] == matriz[1, 1] && matriz[1, 1] == matriz[2, 0])
            {
                MensagemGanhador(turno);
            }
        }
         private static void CondicaoVitoriaLinhas(string[,] matriz, string turno)
        {
            if (matriz[0, 0] == matriz[0, 1] && matriz[0, 1] == matriz[0, 2] ||
                                matriz[1, 0] == matriz[1, 1] && matriz[1, 1] == matriz[1, 2] ||
                                matriz[2, 0] == matriz[2, 1] && matriz[2, 1] == matriz[2, 2])
            {
                MensagemGanhador(turno);
            }
        }
         private static void CondicaoVitoriaColunas(string[,] matriz, string turno)
        {
            if (matriz[0, 0] == matriz[1, 0] && matriz[1, 0] == matriz[2, 0] ||
                                matriz[0, 1] == matriz[1, 1] && matriz[1, 1] == matriz[2, 1] ||
                                matriz[0, 2] == matriz[1, 2] && matriz[1, 2] == matriz[2, 2])
            {
                MensagemGanhador(turno);
            }
        }
        private static string VerificacaoTurnoAtual(string turno)
        {
            if (turno == "X")
            {
                turno = "O";
            }
            else
            {
                turno = "X";
            }

            return turno;
        }
    }
}
