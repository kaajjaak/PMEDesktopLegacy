using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;


namespace Productvity_Made_Easy
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        Boolean isWaiting = false;
        private async void btnLogin_ClickAsync(object sender, EventArgs e)
        {
            if (!isWaiting)
            {
                isWaiting = true;
                LoginAccount account = new LoginAccount(txtUsername.Text, txtPassword.Text);
                string url = "https://databasegip2.herokuapp.com/accounts/login";
                string jsonString = System.Text.Json.JsonSerializer.Serialize(account);
                //MessageBox.Show(jsonString);
                var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var httpClient = HttpClientFactory.Create();
                var httpResponseMessage = await httpClient.PostAsync(url, payload);

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                    Account account1 = JsonConvert.DeserializeObject<Account>(responseBody);
                    HomePage homePage = new HomePage(account1.token);
                    this.Hide();
                    homePage.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid username or password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                isWaiting = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Hide();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}
