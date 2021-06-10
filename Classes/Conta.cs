using System;
namespace Dio.Bank

{
    public class conta
    {
        private ETipoConta TipoConta {get; set;}
        private double Saldo {get; set;}
        private double Credito {get; set;}
        private string Nome {get; set;}

        public conta(ETipoConta tipoConta, double Saldo, double Credito, string Nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }

        public bool Sacar(double ValorSaque)
        {
            if (this.Saldo - ValorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }

            else
            {
                this.Saldo -= ValorSaque;
                Console.WriteLine("Saldo Atual da Conta de {0} é de {1}", this.Nome, this.Saldo);
                return true;
            }
        }

        public void Depositar(double ValorDeposito)
        {
            this.Saldo += ValorDeposito;
            Console.WriteLine("Saldo Atual da Conta de {0} é de {1}", this.Nome, this.Saldo);
        }

        public void Transferir(double ValorTransferencia, conta ContaDestino)
        {
            if(this.Sacar(ValorTransferencia))
            {
                ContaDestino.Depositar(ValorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno;
            retorno = "Tipo Conta: "+ this.TipoConta;
            retorno += "|  Nome: " + this.Nome;
            retorno += "|  Saldo: " + this.Saldo;
            retorno += "|  Crédito: " + this.Credito;

            return retorno;
        }
    }
}