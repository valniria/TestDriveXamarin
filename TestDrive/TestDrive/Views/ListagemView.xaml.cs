using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestDrive.Views
{
    public class Veiculo
    {
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public string PrecoFormatado { get { return string.Format("R$ {0}", Preco); } }
    }

    public partial class ListagemView : ContentPage
    {
        public List<Veiculo> Veiculos { get; set; }

        public ListagemView()
        {
            InitializeComponent();

            this.Veiculos = new List<Veiculo>()
            {
                new Veiculo { Modelo = "Azera V6", Preco = 60000 },
                new Veiculo { Modelo = "Fiesta 2.0", Preco = 50000},
                new Veiculo { Modelo = "HB20 S", Preco = 40000}
            };

            this.BindingContext = this;
        }

        private async void listViewVeiculos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var veiculo = (Veiculo) e.Item;

            await Navigation.PushAsync(new DetalhesView(veiculo));
        }
    }
}
