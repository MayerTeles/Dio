using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Dio.Bank
{
    class Program
    {
        static List<conta> listContas = new List<conta>();
            
        static void Main(string[] args)
        {
            string OpcaoUsuario;

            do
            {
                OpcaoUsuario = ObterOpcaoUsuario();

                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    
                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;
                    
                    case "X":
                        Console.WriteLine("Saindo do Programa...");
                        break;

                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;

                } 
            } while (OpcaoUsuario.ToUpper() != "X");

            Console.WriteLine("Obrigado por Utilizar nossos Serviços!");
            Thread.Sleep(4000);
        }

        private static void Transferir()
        {
            Console.Write("Favor, Informe o Número da conta de Origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Favor, Informe o Número da conta de Destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Informe o Valor a ser transferido: ");
            double valortransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valortransferencia, listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.Write("Favor, Informe o Número da conta para realizar o Depósito: ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Informe o Valor do Depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indice].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Favor, Informe o Número da conta para realizar o Saque: ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Informe o Valor do Saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indice].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Não há nenhuma conta Cadastrada!");
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                conta conta = listContas[i];
                Console.Write("#{0}: - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.Write("Inserir Nova Conta: ");

            Console.Write("Digite 1 para Pessoa Física e 2 para Júridica: ");
            int EntradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Cliente: ");
            string EntradaNome = (Console.ReadLine());

            Console.Write("Digite o Saldo Inicial: ");
            double EntradaSaldo = double.Parse((Console.ReadLine()));

            Console.Write("Digite o Crédito: ");
            double EntradaCredito = double.Parse((Console.ReadLine()));

            conta NovaConta = new conta((ETipoConta)EntradaTipoConta, EntradaSaldo, EntradaCredito, EntradaNome);

            listContas.Add(NovaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            string OpcaoUsuario;

            Console.WriteLine();
            Console.WriteLine("Dio.Bank ao Seu Dispor!");
            Console.WriteLine("Informe a Opção Desejada: ");

            Console.WriteLine("1 - Listar Contas.");
            Console.WriteLine("2 - Cadastrar Conta.");
            Console.WriteLine("3 - Transferir.");
            Console.WriteLine("4 - Sacar.");
            Console.WriteLine("5 - Depositar.");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair!");

            OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
