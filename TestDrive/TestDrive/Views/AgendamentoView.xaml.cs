using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using TestDrive.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestDrive.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public AgendamentoViewModel ViewModel { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            this.ViewModel = new AgendamentoViewModel(veiculo);
            this.BindingContext = this.ViewModel;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Agendamento>(this, "Agendamento", (msg) => {
                DisplayAlert("Agendamento Realizado com Sucesso",
            string.Format(
            @"Veiculo: {0}
            Nome: {1}
            Fone: {2}
            E-mail: {3}
            Data Agendamento: {4}
            Hora Agendamento: {5}", ViewModel.Veiculo.Modelo,
                ViewModel.Nome,
                ViewModel.Fone,
                ViewModel.Email,
                ViewModel.DataAgendamento.ToString("dd/MM/yyyy"),
                ViewModel.HoraAgendamento),
            "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Agendamento>(this, "Agendamento");
        }
    }
}