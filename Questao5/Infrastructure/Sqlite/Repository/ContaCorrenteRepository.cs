using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Sqlite;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Sqlite
{
    public class ContaCorrenteRepository : DatabaseBootstrap, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(DatabaseConfig databaseConfig) : base(databaseConfig)
        {
        }
            
        public async Task<ContaCorrente> RetornarConta(int numeroConta)
        {
            string sql = "SELECT * FROM contacorrente WHERE numero=@numero";
            try
            {
                using var connection = new SqliteConnection(base.databaseConfig.Name);
                var contaCorrente = await connection.QueryFirstOrDefaultAsync<ContaCorrente>(sql, new { numero = numeroConta });

                return contaCorrente;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
              

        public async Task<EnuTipoDeConta> RetornaStatus(int numeroConta)
        {
            var contaCorrente = await RetornarConta(numeroConta);

            if (contaCorrente != null && contaCorrente.Numero > 0)
            {
                if (contaCorrente.Ativo == 0)
                    return EnuTipoDeConta.INACTIVE_ACCOUNT;
                else
                    return EnuTipoDeConta.VALID;

            } 
            return EnuTipoDeConta.INVALID_ACCOUNT;
        }
    }
}
