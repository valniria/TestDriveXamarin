using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Models
{
    public class ListagemVeiculos
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemVeiculos()
        {
            this.Veiculos = new List<Veiculo>()
            {
                new Veiculo { Modelo = "Azera V6", Preco = 60000 },
                new Veiculo { Modelo = "Fiesta 2.0", Preco = 50000},
                new Veiculo { Modelo = "HB20 S", Preco = 40000}
            };
        }

    }
}
