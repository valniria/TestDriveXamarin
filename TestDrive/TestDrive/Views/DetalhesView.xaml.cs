using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public DetalhesView(Veiculo veiculo)
        {
            InitializeComponent();
            this.Veiculo = veiculo;
            this.BindingContext = new DetalheViewModel(veiculo);
        }

        private async void buttonProximo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgendamentoView(this.Veiculo));
        }
    }
}