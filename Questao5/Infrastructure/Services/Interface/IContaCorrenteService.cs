using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Services
{
    public interface IContaCorrenteService
    {
        Task<Domain.Enumerators.EnuTipoDeConta> RetornarStatus(int numeroConta);
        Task<SaldoResponse> RetornarStatusComObjetoContaCorrente(int numeroConta);
        Task<Domain.Enumerators.EnuTipoDeConta> RetornarStatus(int numeroConta, decimal valor, string operacao);
        Task<Domain.Enumerators.EnuTipoDeConta> RetornarStatus(int numeroConta, decimal valor);
    }
}
