using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes {get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
            Hospedes = new List<Pessoa>(); //Inicia a lista
        }

        public void CadastrarSuite(Suite suite)
        {
            if (suite == null)
            {
                throw new ArgumentException("A suiíte não pode ser nula.");
            }
            Suite = suite;
        }
        
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("É necessário cadastrar uma suíte antes de adicionar hóspedes.");
            }
            if (hospedes.Count > Suite.Capacidade)
            {
                throw new InvalidOperationException("O número de hóspedes excede a capacidade da suíte");
            }

            Hospedes = hospedes;
        }


        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("É necessário cadastrar uma suíte para calcular o valor da diária.");
            }

            decimal valorTotal = Suite.ValorDiaria * DiasReservados;

            if (DiasReservados >= 10)
            {
                //aplicar desconto de 10% para acima de 10 dias
                valorTotal *= 0.90m;
            }

            return valorTotal;
        }
    }

}