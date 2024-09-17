using System.Globalization;
using Entities;
using Services;

Console.WriteLine("Inisira com os dados do aluguel");


Console.WriteLine("Modelo do veículo: ");
string modelo = Console.ReadLine();

Console.WriteLine("Data e Hora de retirada (dd/mm/yyyy HH:mm): ");
DateTime dataInicio = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

Console.WriteLine("Data e Hora de devolução (dd/mm/yyyy HH:mm): ");
DateTime dataFim = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

Console.WriteLine("Informe o preço por hora: ");
double precoPorHora = double.Parse(Console.ReadLine());

Console.WriteLine("Informe o preço por dia: ");
double precoPorDia = double.Parse(Console.ReadLine());

AluguelCarro aluguel = new AluguelCarro(dataInicio, dataFim, new Veiculo(modelo));

AluguelService aluguelService = new AluguelService(precoPorDia, precoPorHora, new BrasilImpostoService());

aluguelService.ProcessaFatura(aluguel);
Console.WriteLine("FATURA: ");
Console.WriteLine(aluguel.Fatura);


