using MediatR;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Commands.Requests
{
    public class CreateMovimentoRequest : IRequest<CreateMovimentoResponse>
    {
        public int NumeroContaCorrente { get; set; }

        public decimal Valor { get; set; }

        public string TipoOperacao { get; set; }

        public DateTime DtLancamento { get; set; }


    }
}
