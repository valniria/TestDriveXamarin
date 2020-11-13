using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace TestDrive.ViewModels
{
    public class ListagemViewModel : BaseViewModel
    {
        const string url_get_veiculos = "http://aluracar.herokuapp.com/";
        public ObservableCollection<Veiculo> Veiculos { get; set; }
        private bool aguarde;

        public bool Aguarde
        {
            get { return aguarde; }
            set 
            { 
                aguarde = value;
                OnPropertyChanged();
            }
        }


        Veiculo veiculoSelecionado;
        public Veiculo VeiculoSelecionado
        {
            get
            {
                return VeiculoSelecionado;
            }
            set
            {
                veiculoSelecionado = value;
                if(veiculoSelecionado != null)
                    MessagingCenter.Send(veiculoSelecionado, "VeiculoSelecionado");
            }
        }

        public ListagemViewModel()
        {
            this.Veiculos = new ObservableCollection<Veiculo>();
        }

        public async Task GetVeiculos()
        {
            Aguarde = true;
            HttpClient client = new HttpClient();
            var resultado = await client.GetStringAsync(url_get_veiculos);

            var veiculosJson = JsonConvert.DeserializeObject<VeiculoJson[]>(resultado);

            foreach(var veiculo in veiculosJson)
            {
                this.Veiculos.Add(new Veiculo 
                { 
                    Modelo = veiculo.Nome,
                    Preco = veiculo.Preco
                });
            }
            Aguarde = false;
        }
    }

    public class VeiculoJson
    {
        public string Nome { get; set; }
        public int Preco { get; set; }
    }
}
