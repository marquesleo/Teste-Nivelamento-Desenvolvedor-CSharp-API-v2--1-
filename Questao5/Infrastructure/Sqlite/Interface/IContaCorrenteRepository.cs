namespace Questao5.Infrastructure.Sqlite
{
    public interface IContaCorrenteRepository
    {
       Task<Domain.Enumerators.EnuTipoDeConta> RetornaStatus(int numeroConta);
       Task<Domain.Entities.ContaCorrente> RetornarConta(int numeroConta);

    }
}
