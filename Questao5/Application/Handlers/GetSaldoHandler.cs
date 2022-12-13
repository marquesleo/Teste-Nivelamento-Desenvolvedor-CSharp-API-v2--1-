using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure.Services;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers
{
    public class GetSaldoHandler : IRequestHandler<SaldoRequest, SaldoResponse>
    {
        private readonly IMovimentacaoService movimentacaoService;
        private readonly IContaCorrenteService contaCorrenteService;
        public GetSaldoHandler(IMovimentacaoService movimentacaoService,
                                      IContaCorrenteService contaCorrenteService)
        {

            this.movimentacaoService = movimentacaoService;
            this.contaCorrenteService = contaCorrenteService;
        }
        public async Task<SaldoResponse> Handle(SaldoRequest request, CancellationToken cancellationToken)
        {
            try
            { 

               var status = await  contaCorrenteService.RetornarStatus(request.Numero);

                if (status != Domain.Enumerators.EnuTipoDeConta.VALID)
                    throw new Exception(status.ToString());

                var Saldo = await movimentacaoService.RetornarSaldo(request.Numero);
                var SaldoResponse = await contaCorrenteService.RetornarStatusComObjetoContaCorrente(request.Numero);

                if (SaldoResponse.Status != Domain.Enumerators.EnuTipoDeConta.VALID)
                    throw new Exception(SaldoResponse.Status.ToString());
                else
                {
                    SaldoResponse.Saldo = Saldo;
                }
                    
                return SaldoResponse;
               

            }
            catch (Exception ex)
            {

                throw ex;
            }
         
        }
    }

}
