using HospitalWPF.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace HospitalWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var loginModel = new LoginViewModel()
            {
                Login = loginBlock.Text,
                Password = passwordBlock.Text,
            };
            var json = JsonConvert.SerializeObject(loginModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:7104/validate";
            var client = new HttpClient();
            var responce = await client.PostAsync(url, data);
            DoctorInterface doctorInterface = new DoctorInterface();
            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                
                MessageBox.Show("Успешный вход");
                doctorInterface.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}