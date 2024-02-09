using HospitalWPF.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalWPF
{
    /// <summary>
    /// Логика взаимодействия для DoctorInterface.xaml
    /// </summary>
    public partial class DoctorInterface : Window
    {
        public DoctorInterface()
        {
            InitializeComponent();
        }

        private void phoneNumberBlock_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string phone = phoneNumberBlock.Text;
            string url = $"https://localhost:7104/findinfobyphone?phone={phone}";
            HttpClient httpClient = new HttpClient();
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                UserViewModel userViewModel = JsonConvert.DeserializeObject<UserViewModel>(responseBody);
                string insuranceNumber = userViewModel.InsurancePolicyNumber.ToString();
                patientName.Text = userViewModel.Name;
                patientLastname.Text = userViewModel.Lastname;
                patientSurname.Text = userViewModel.Surname;
                patientEmail.Text = userViewModel.Email;
                patientInsurancePlicyNumber.Text = insuranceNumber;

            }

            catch (HttpRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string eventName = nameOfEvent.Text;
            string docName = doctorName.Text;
            string docLastname = doctorLastname.Text;
            string phoneNumber = phonenumber.Text;
            string typeOfEvent = eventType.Text;
            string Results = result.Text;
            string Recommendations = recommendation.Text;
            string fullPrice = price.Text;
            try
            {
                var eventModel = new HealingEventViewModel()
                {
                    Name = eventName,
                    PatientPhone = phoneNumber,
                    DoctorName = docName,
                    DoctorLastName = docLastname,
                    HealingEventType = typeOfEvent,
                    Result = Results,
                    Recommendation = Recommendations,
                    Price = float.Parse(fullPrice),
                };
                ApiHelper apiHelper = new ApiHelper();
                await apiHelper.CreateHealingEvent(eventModel);
            }
            catch { }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
