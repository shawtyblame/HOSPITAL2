using HospitalWPF.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HospitalWPF
{
    public class ApiHelper
    {
        private HttpClient _httpClient;
        public ApiHelper()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7104/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CreateHealingEvent(HealingEventViewModel healingEventViewModel)
        {
            try
            {
                var json = JsonConvert.SerializeObject(healingEventViewModel);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var responce = await _httpClient.PostAsync("/createevent", data);
                if (responce.IsSuccessStatusCode)
                {
                    MessageBox.Show("send");
                    return true;
                }
                else
                {
                    throw new ArgumentException($"Error: {responce.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }
    }
}
