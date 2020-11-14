using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestDrive.Models;
using TestDrive.Services;
using Xamarin.Forms;

namespace TestDrive.ViewModels
{
    public class LoginViewModel
    {
        //private readonly LoginService LoginService;

        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }
        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            var loginService = new LoginService();

            EntrarCommand = new Command(async () =>
            {
                await loginService.AutenticarUsuario(new Login(usuario, senha));
            }, () =>
            {
                return !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(senha);
            });
        }

        
    }
}
