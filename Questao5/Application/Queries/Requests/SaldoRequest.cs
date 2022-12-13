using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public class SaldoRequest : IRequest<SaldoResponse>
    {
        public int Numero {  get; set; }    
    }
}
