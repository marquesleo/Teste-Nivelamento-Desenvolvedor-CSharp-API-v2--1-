using Questao5.Application.Commands.Requests;

namespace Questao5.Infrastructure.Services
{
    public interface IMovimentacaoService
    {
        Task<string> LancarMovimentacao(CreateMovimentoRequest request);
        Task<decimal> RetornarSaldo(int numeroConta);
    }
}
