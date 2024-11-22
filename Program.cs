using Models;

class Program
{
    static void Main()
    {
        Console.WriteLine("Seja bem-vindx ao sistema de Hoteis DZU Hotels");

        var reservas = new List<Reserva>();
        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("\nMenu Principal:");
            Console.WriteLine("1 - Fazer Nova reserva");
            Console.WriteLine("2 - Verificar reservas");
            Console.WriteLine("3 - Sair");

            string? opcaoMenu = Console.ReadLine();

            switch (opcaoMenu)
            {
                case "1":
                    Console.Clear();
                    FazerNovaReserva(reservas);
                    break;

                case "2":
                   // Console.Clear();
                    VerificarReservas(reservas);
                    break;

                case "3":
                    exibirMenu = false;
                    Console.WriteLine("Encerrando o sistema...");
                    Console.WriteLine("\nPressione qualquer tecla para continuar...");
                    Console.ReadKey();
                    Console.Clear();

                    exibirMenu = false;
                    break;

                default:
                    Console.WriteLine("\nOpção Inválida. Tente novamente.");
                    break;
            }
        }
    }

    static void FazerNovaReserva(List<Reserva> reservas)
    {
        string tipoSuite = "";
        int capacidadeSuite = 0;
        decimal valorDiariaSuite = 0;

        Console.WriteLine("\nEscolha a categoria:");
        Console.WriteLine("1 - Standard (Max.: 2 pax)");
        Console.WriteLine("2 - Superior (Max.: 4 pax)");
        Console.WriteLine("3 - Premiere (Max.: 4 pax)");
        Console.WriteLine("4 - Suíte (Max.: 2 pax)");
        Console.WriteLine("5 - Family Room (Max.: 6 pax)");

        string? opcao = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(opcao))
        {
            switch (opcao)
            {
                case "1":
                    Console.Clear();
                    tipoSuite = "Standard";
                    capacidadeSuite = 2;
                    break;

                case "2":
                    Console.Clear();
                    tipoSuite = "Superior";
                    capacidadeSuite = 4;
                    break;

                case "3":
                    Console.Clear();
                    tipoSuite = "Premiere";
                    capacidadeSuite = 4;
                    break;

                case "4":
                    Console.Clear();
                    tipoSuite = "Suite";
                    capacidadeSuite = 2;
                    break;

                case "5":
                    Console.Clear();
                    tipoSuite = "Family Room";
                    capacidadeSuite = 6;
                    break;

                default:
                    Console.Clear();
                    Console.WriteLine("\nOpção inválida.");
                    return;
            }
        }

        Console.WriteLine($"Digite o valor da diária para a categoria {tipoSuite}");
        Console.Write("R$");
        valorDiariaSuite = decimal.Parse(Console.ReadLine());

        var suite = new Suite(tipoSuite, capacidadeSuite, valorDiariaSuite);
        var reserva = new Reserva();
        reserva.CadastrarSuite(suite);

        var hospedes = new List<Pessoa>();

        Console.WriteLine($"\nCadastro de Hóspedes (Capacidade: {capacidadeSuite}):");

        for (int i = 1; i <= capacidadeSuite; i++)
        {
            Console.WriteLine($"\nHóspede {i}: ");
            Console.Write("Nome: ");
            string? nome = Console.ReadLine();

            Console.Write("Sobrenome: ");
            string? sobrenome = Console.ReadLine();

            hospedes.Add(new Pessoa(nome, sobrenome));
        }

        try
        {
            reserva.CadastrarHospedes(hospedes);
        }

        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
            return;
        }

        Console.WriteLine("\nDigite a quantidade de dias reservados: ");
        reserva.DiasReservados = int.Parse(Console.ReadLine());

        reservas.Add(reserva);

        Console.WriteLine($"\nReserva concluída com sucesso!");
        Console.WriteLine($"\nQuantidade de hóspedes: {reserva.ObterQuantidadeHospedes()}");
        Console.WriteLine($"Valor total da diária: {reserva.CalcularValorDiaria():C}");

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }

    static void VerificarReservas(List<Reserva> reservas)
    {
        if (reservas.Count == 0)
        {
            Console.WriteLine("\nNenhuma reserva cadastrada.");
            return;
        }

        Console.WriteLine("\nReservas Cadastradas:");

        foreach (var reserva in reservas)
        {
            Console.WriteLine("\n---- Reserva ----");
            Console.WriteLine($"Categoria: {reserva.Suite.TipoSuite}");
            Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade}");
            Console.WriteLine($"Dias Reservados: {reserva.DiasReservados}");
            Console.WriteLine($"Hóspedes:");

            foreach (var hospede in reserva.Hospedes)
            {
                Console.WriteLine($"- {hospede.Nome} {hospede.Sobrenome}");
            }

            Console.WriteLine($"Valor Total: {reserva.CalcularValorDiaria():C}");
        }
    }
}