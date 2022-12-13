using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {

        private readonly IContaCorrenteRepository contaCorrenteRepository;
        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {          
            this.contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<EnuTipoDeConta> RetornarStatus(int numeroConta)
        {
            return await this.contaCorrenteRepository.RetornaStatus(numeroConta);
        }


        public async Task<EnuTipoDeConta> RetornarStatus(int numeroConta, decimal valor, string operacao)
        {

            if (!(operacao.ToUpper() == "D" || operacao.ToUpper() == "C"))
            {
             return  EnuTipoDeConta.INVALID_TYPE;
            }
               
            return await RetornarStatus(numeroConta, valor);
        
        }

        private SaldoResponse CarregarSaldo(int numeroConta, ContaCorrente contaCorrente, EnuTipoDeConta status)
        {
            return new SaldoResponse()
            {
                Status = status,
                Numero = numeroConta,
                Titular = contaCorrente.Nome,
                Saldo = 0
            };
        }

        public async Task<EnuTipoDeConta> RetornarStatus(int numeroConta, decimal valor)
        {
            if (valor < 0)
                return EnuTipoDeConta.INVALID_VALUE;
           
            return await contaCorrenteRepository.RetornaStatus(numeroConta);
        }

        public async Task<SaldoResponse> RetornarStatusComObjetoContaCorrente(int numeroConta)
        {

            var contaCorrente = await this.contaCorrenteRepository.RetornarConta(numeroConta);

            if (contaCorrente != null)
            {
                var status = await RetornarStatus(numeroConta, 0);
                return CarregarSaldo(numeroConta, contaCorrente, status);
         
            }

            return new SaldoResponse()
            {
                Status =  EnuTipoDeConta.INVALID_ACCOUNT,
                Numero = 0,
                Titular = "",
                Saldo = 0
            };
        }

      
    }
}
