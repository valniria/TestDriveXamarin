using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestDrive.Models;
using Xamarin.Forms;

namespace TestDrive.Services
{
    public class LoginService
    {
        public async Task AutenticarUsuario(Login login)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var camposFormulario = new FormUrlEncodedContent(new[]
                    {
                    new KeyValuePair<string, string>("email", login.Email),
                    new KeyValuePair<string, string>("senha", login.Senha)
                });
                    client.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                    var resultado = await client.PostAsync("/login", camposFormulario);

                    if (resultado.IsSuccessStatusCode)
                    {
                        MessagingCenter.Send<Usuario>(new Usuario(), "SucessoLogin");
                    }
                    else
                    {
                        MessagingCenter.Send<LoginException>(new LoginException("Usuário ou senha incorretos!"),
                            "FalhaLogin");
                    }
                }
            }
            catch
            {
                MessagingCenter.Send<LoginException>(new LoginException(@"Ocorreu um erro de comunicação com o servidor.
Favor verificar sua conexão e tente novamente mais tarde"),
                            "FalhaLogin");
            }
        }

        public class LoginException : Exception
        {
            public LoginException(string message) : base(message)
            {

            }
        }
    }
}
