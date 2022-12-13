using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Infrastructure.Services;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Application.Handlers
{
    public class CreateMovimentoHandler: IRequestHandler<CreateMovimentoRequest,CreateMovimentoResponse>
    {

        private readonly IMovimentacaoService movimentacaoService;
        private readonly IContaCorrenteService contaCorrenteService;
        public CreateMovimentoHandler(IMovimentacaoService movimentacaoService,
                                      IContaCorrenteService contaCorrenteService)
        {

            this.movimentacaoService = movimentacaoService;
            this.contaCorrenteService = contaCorrenteService;
        }
        public async Task<CreateMovimentoResponse> Handle(CreateMovimentoRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var status = await contaCorrenteService.RetornarStatus(request.NumeroContaCorrente);

                if (status !=  Domain.Enumerators.EnuTipoDeConta.VALID)
                    throw new Exception(status.ToString());

               var IdMovimento = await movimentacaoService.LancarMovimentacao(request);

                var result = new CreateMovimentoResponse
                {
                    IdMovimento = IdMovimento
                };
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }


       
    }
}
