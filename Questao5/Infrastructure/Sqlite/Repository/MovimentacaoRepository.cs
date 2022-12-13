using Dapper;
using Questao5.Domain.Entities;
using Microsoft.Data.Sqlite;
namespace Questao5.Infrastructure.Sqlite
{
    public class MovimentacaoRepository : DatabaseBootstrap, IMovimentacaoRepository
    {
        public MovimentacaoRepository(DatabaseConfig databaseConfig) : base(databaseConfig)
        {
        }

        public async Task LancarMovimentacao(Movimento movimento)
        {

            
            string sql = "insert into movimento(idmovimento,idcontacorrente,datamovimento,tipomovimento,valor) VALUES(@IdMovimento,@IdContaCorrente,@DtMovimento,@TipoMmovimento,@Valor);";
            try
            {
                movimento.IdMovimento = Guid.NewGuid().ToString();
                var @params = new { IdMovimento = movimento.IdMovimento, IdContaCorrente = movimento.IdContaCorrente, DtMovimento  = movimento.DtMovimento, TipoMmovimento = movimento.TipoMovimento, Valor = movimento.Valor };
                using var connection = new SqliteConnection(base.databaseConfig.Name);
                await connection.ExecuteAsync(sql, @params);
            }
            catch (Exception ex)
            {


                throw ex;
            }
                
        }

        public async Task<decimal> RetornarSaldo(int numeroConta, string tipoMovimento)
        {
            string sql = "SELECT COALESCE(SUM(valor),0) FROM movimento WHERE tipomovimento=@tipomovimento and idcontacorrente=@idcontacorrente";
            try
            {
                using var connection = new SqliteConnection(base.databaseConfig.Name);
                var valor =  await connection.QuerySingleOrDefaultAsync<decimal>(sql, new { tipomovimento = tipoMovimento, idcontacorrente=numeroConta});
                return valor;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return 0;
        }

    }
}
