namespace Questao5.Application.Queries.Responses
{
    public class SaldoResponse
    {
        public decimal Saldo { get; set; }  
        public int Numero { get; set; } 
        public string Titular { get; set; }
        public DateTime DtConsulta => DateTime.Now;
        public Domain.Enumerators.EnuTipoDeConta Status { get; set; }   

    }
}
