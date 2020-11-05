using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesView : ContentPage
    {
        private const int FreioAbs = 800;
        private const int ArCondicionado = 1000;
        private const int Mp3Player = 500;

        public Veiculo Veiculo { get; set; }

        public string TextoFreioAbs { 
            get {
                return string.Format("Freio ABS - R$ {0}", FreioAbs);
            } 
        }

        public string TextoArCondicionado {
            get {
                return string.Format("Ar Condicionado - R$ {0}", ArCondicionado);
            }
        }

        public string TextoMp3Player
        {
            get
            {
                return string.Format("MP3 Player - R$ {0}", Mp3Player);
            }
        }

        bool temFreioAbs;
        public bool TemFreioAbs {
            get {
                return temFreioAbs;
            }
            set
            {
                temFreioAbs = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool temArCondicionado;
        public bool TemArCondicionado
        {
            get
            {
                return temArCondicionado;
            }
            set
            {
                temArCondicionado = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        bool temMp3Player;
        public bool TemMp3Player
        {
            get
            {
                return temMp3Player;
            }
            set
            {
                temMp3Player = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ValorTotal));
            }
        }

        public string ValorTotal {
            get {
                return string.Format("Valor Total: R$ {0}", 
                    Veiculo.Preco
                    + (TemFreioAbs?FreioAbs:0)
                    + (TemArCondicionado?ArCondicionado:0)
                    + (TemMp3Player? Mp3Player:0));
            }
        }

        public DetalhesView(Veiculo veiculo)
        {
            InitializeComponent();

            this.Veiculo = veiculo;
            this.BindingContext = this;
        }

        private async void buttonProximo_Clicked(object sender, EventArgs e)
        {


            await Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}