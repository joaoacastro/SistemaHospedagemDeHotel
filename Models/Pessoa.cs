using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Models
{
    public class Pessoa
    {
        public Pessoa (string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        
        private string _nome;

        public string Nome {
            get => _nome;
            set
            {
                if (value == "")
                {
                    Console.WriteLine("ERROR");
                    throw new ArgumentException("O nome não pode ser vazio");
                }
                _nome = value;
            }
            }

        public string Sobrenome { get; set; }
    }
}