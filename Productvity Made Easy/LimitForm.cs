using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Productvity_Made_Easy
{
    public partial class LimitForm : Form
    {
        private string token;
        private long AppID;
        public LimitForm(long pAppID, string pToken)
        {
            InitializeComponent();
            token = pToken;
            AppID = pAppID;
        }
        private int berekenTijdInS()
        {
            int totaalD = String.IsNullOrEmpty(txtDay.Text) ? 0 : Convert.ToInt32(txtDay.Text);
            int totaalH = String.IsNullOrEmpty(txtHour.Text) ? totaalD * 24 : totaalD * 24 + Convert.ToInt32(txtHour.Text);
            int totaalM = String.IsNullOrEmpty(txtMin.Text) ? totaalH * 60 : totaalH * 60 + Convert.ToInt32(txtMin.Text);
            int totaalS = String.IsNullOrEmpty(txtSec.Text) ? totaalM * 60 : totaalM * 60 + Convert.ToInt32(txtSec.Text);
            return totaalS;
        }

        public class Limit
        {
            public string token { get; set; }
            public int limit { get; set; }

            public Limit(string token, int limit)
            {
                this.token = token;
                this.limit = limit;
            }
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            string url = $"https://databasegip2.herokuapp.com/application/{AppID}/limits/createlimit";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(new Limit(token, berekenTijdInS()));
            //MessageBox.Show(jsonString);
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var httpClient = HttpClientFactory.Create();
            var httpResponseMessage = await httpClient.PostAsync(url, payload);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Success!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error!", "Error!");
            }
        }

        private async void LimitForm_Load(object sender, EventArgs e)
        {
            string url = $"https://databasegip2.herokuapp.com/application/{AppID}/checkLimit";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(new Limit(token, berekenTijdInS()));
            //MessageBox.Show(jsonString);
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var httpClient = HttpClientFactory.Create();
            var httpResponseMessage = await httpClient.PostAsync(url, payload);
            var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
            string limit = JsonConvert.DeserializeObject<string>(responseBody);
            MessageBox.Show(limit);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                int limitTime = Convert.ToInt32(limit);
                TimeSpan time = TimeSpan.FromSeconds(limitTime);
                txtSec.Text = time.Seconds.ToString();
                txtMin.Text = time.Minutes.ToString();
                txtHour.Text = time.Hours.ToString();
                txtDay.Text = time.Days.ToString();
            }
            else
            {
                MessageBox.Show("Error!", "Error!");
            }
        }
    }
}
