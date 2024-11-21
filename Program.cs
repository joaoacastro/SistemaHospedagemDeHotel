using Models;

var suite = new Suite("Premium", 3, 150.00M);

var hospedes = new List<Pessoa>
{
    new Pessoa("James", "Deane"),
    new Pessoa("Diego", "Higa"),
    new Pessoa("Adam", "LZ"),
    //new Pessoa("Ryan", "Tuerck"),
};

var reserva = new Reserva();
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

Console.WriteLine($"Quantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
reserva.DiasReservados = 10;
Console.WriteLine($"Valor total da diária: {reserva.CalcularValorDiaria():C}");