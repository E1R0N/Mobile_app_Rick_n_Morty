using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Rick.Character;

namespace Rick
{
    public partial class MainPage : ContentPage
    {
        public class Root
        {
            public int id { get; set; }
            public string name { get; set; }
            public string status { get; set; }
            public string species { get; set; }
            public string type { get; set; }
            public string gender { get; set; }
            public Origin origin { get; set; }
            public Location location { get; set; }
            public string image { get; set; }
            public List<string> episode { get; set; }
            public string url { get; set; }
            public DateTime created { get; set; }
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("https://rickandmortyapi.com/api/character/"+Ingreso.Text);
            request.Method = HttpMethod.Get;
            request.Headers.Add("Accept", "application/json");
            var client = new HttpClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();
                Root resultado = JsonConvert.DeserializeObject<Root>(content);
                Nombre1.Text = resultado.name;
                Status1.Text = resultado.status;
                Species1.Text = resultado.species;
                Tipo1.Text = resultado.type;
                Genero1.Text = resultado.gender;
            }
        }
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
