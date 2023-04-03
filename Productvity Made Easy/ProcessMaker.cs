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
    public partial class ProcessMaker : Form
    {
        string jwt;
        HomePage myParent;
        public ProcessMaker(string jwt, HomePage homePage)
        {
            this.jwt = jwt;
            myParent = homePage;
            InitializeComponent();
        }
        public class ApplicationName
        {
            public ApplicationName(string application, string jwt)
            {
                this.applicationName = application;
                this.jwt = jwt;
            }
            public string applicationName { get; }
            public string jwt { get; }
        }
        public class ID
        {
            public ID(string id)
            {
                this.id = id;
            }
            public string id { get; }
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            ApplicationName appName = new ApplicationName(txtName.Text, jwt);
            string url = "https://databasegip2.herokuapp.com/application/createApplication";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(appName);
            //MessageBox.Show(jsonString);
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var httpClient = HttpClientFactory.Create();
            var httpResponseMessage = await httpClient.PostAsync(url, payload);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                ID ID1 = JsonConvert.DeserializeObject<ID>(responseBody);
                MessageBox.Show("Success!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                myParent.LoadApplications();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
