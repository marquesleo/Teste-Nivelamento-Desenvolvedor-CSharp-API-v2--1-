using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria {


        private int _Numero;
        public int Numero { get
            {
                return _Numero;
            }
        }
        private const double taxa = 3.50;
        public string Titular { get; set; }
        private double DepositoInicial { get; set; }
        private double TotalConta { get; set; }


        private void AtribuirContrutores(int numero,string titular)
        {
            this.TotalConta = 0;
            this._Numero = numero;
            this.Titular = titular;
        }

        public ContaBancaria(int numero, string titular)
        {
            AtribuirContrutores(numero, titular);
        }

        public ContaBancaria(int numero,string titular , double depositoInicial)
        {
            AtribuirContrutores(numero, titular);
            this.TotalConta += depositoInicial;
        }


        public void Deposito(double valor)
        {
            this.DepositoInicial = valor;
            TotalConta += valor;
        }

        public void Saque(double quantia)
        {

            TotalConta -= quantia - taxa;
        }


        public override string ToString()
        {
            return $"Conta: {this.Numero},Titular: {this.Titular}, Saldo:{TotalConta.ToString("c2")}";
        }

    }
}
