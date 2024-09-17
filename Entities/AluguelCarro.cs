using System;


namespace Entities
{
    public class AluguelCarro
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Veiculo Veiculo { get; set; }
        public Fatura Fatura { get; set; }

        public AluguelCarro(DateTime dataInicio, DateTime dataFim, Veiculo veiculo)
        {
            DataInicio = dataInicio;
            DataFim = dataFim;
            Veiculo = veiculo;
            Fatura = null;
        }
    }
}
