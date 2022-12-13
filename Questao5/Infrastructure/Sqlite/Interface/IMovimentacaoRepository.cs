namespace Questao5.Infrastructure.Sqlite
{
    public interface IMovimentacaoRepository
    {
        Task LancarMovimentacao(Questao5.Domain.Entities.Movimento movimento);
        Task<decimal> RetornarSaldo(int numeroConta, string tipoMovimento);

    }
}
