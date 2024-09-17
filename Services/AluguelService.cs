using System;
using Entities;

namespace Services
{
    public class AluguelService
    {
        public double PrecoPorDia { get; private set; }
        public double PrecoPorHora { get; private set; }


        private IImpostoService _impostoService;
        public AluguelService(double precoPorDia, double precoPorHora, IImpostoService impostoService)
        {
            PrecoPorDia = precoPorDia;
            PrecoPorHora = precoPorHora;
            _impostoService = impostoService;
        }

        public void ProcessaFatura(AluguelCarro aluguel)
        {
            if (aluguel == null)
            {
                throw new ArgumentNullException();
            }

            TimeSpan duracao = aluguel.DataFim.Subtract(aluguel.DataInicio);

            double pagamentoBasico = 0.0;
            if(duracao.TotalHours <= 12)
            {
                pagamentoBasico = PrecoPorHora * Math.Ceiling(duracao.TotalHours);
            }
            else
            {
                pagamentoBasico = PrecoPorDia * Math.Ceiling(duracao.TotalDays);
            }

            double imposto = _impostoService.Imposto(pagamentoBasico);

            aluguel.Fatura = new Fatura(pagamentoBasico, imposto);

        }

    }
}
