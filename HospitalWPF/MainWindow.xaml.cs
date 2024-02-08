using HospitalWPF.ViewModels;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                Login = loginblock.Text,
                Password = passwordblock.Text,
            };
            var json = JsonConvert.SerializeObject(loginModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://localhost:7104/validate";
            var client = new HttpClient();
            var responce = await client.PostAsync(url, data);
            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Успешнйы вход");
            }
        }
    }
}