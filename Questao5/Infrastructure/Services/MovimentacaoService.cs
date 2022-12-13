using Questao5.Application.Commands.Requests;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Services
{
    public class MovimentacaoService: IMovimentacaoService
    {

        private readonly IMovimentacaoRepository movimentacaoRepository;
        private readonly IContaCorrenteRepository contaCorrenteRepository;
        public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository,
                                      IContaCorrenteRepository contaCorrenteRepository)
        {

            this.movimentacaoRepository = movimentacaoRepository;
            this.contaCorrenteRepository = contaCorrenteRepository;
        }


        public async Task<string> LancarMovimentacao(CreateMovimentoRequest request)
        {
            try
            {
                var movimentacao = new Domain.Entities.Movimento();
                movimentacao.DtMovimento = request.DtLancamento.ToString();
                movimentacao.TipoMovimento = request.TipoOperacao;
                movimentacao.Valor = request.Valor;
                movimentacao.IdContaCorrente = request.NumeroContaCorrente;


                await movimentacaoRepository.LancarMovimentacao(movimentacao);
                return movimentacao.IdMovimento;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<decimal> RetornarSaldo(int numeroConta)
        {
            try
            {
                var debito = await movimentacaoRepository.RetornarSaldo(numeroConta, "D");
                var credito = await movimentacaoRepository.RetornarSaldo(numeroConta, "C");
                return  credito - debito;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
