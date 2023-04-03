using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace Productvity_Made_Easy
{
    public partial class ApplicationManager : Form
    {

        public class ProcessGroup
        {
            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }



        }
        public class ProcessJson
        {
            [JsonProperty("process")]
            public ProcessGroup process { get; set; }

            [JsonProperty("id")]
            public int id { get; set; }
        }



        HomePage.ApplicationJson applicatie;
        string Token;
        public ApplicationManager(HomePage.ApplicationJson applicationJson, string token)
        {
            applicatie = applicationJson;
            Token = token;
            InitializeComponent();

        }

        private void ApplicationManager_Load(object sender, EventArgs e)
        {
            lblApplicationName.Text = "Application Name: " + applicatie.application.Name;
            loadProcessesFromServer();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            lbxSelectedApps.Items.Add(lbxAllApps.SelectedItem.ToString());
            lbxAllApps.Items.RemoveAt(lbxAllApps.SelectedIndex);
        }

        private void btnDeselect_Click(object sender, EventArgs e)
        {
            lbxAllApps.Items.Add(lbxSelectedApps.SelectedItem.ToString());
            lbxSelectedApps.Items.RemoveAt(lbxSelectedApps.SelectedIndex);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadProcesses();
        }
        private void loadProcesses()
        {
            lbxAllApps.Items.Clear();
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle) && !lbxSelectedApps.Items.Contains(p.ProcessName))
                {
                    lbxAllApps.Items.Add(p.ProcessName);
                }
            }
        }
        private async void loadProcessesFromServer()
        {
            string url = $"https://databasegip2.herokuapp.com/application/{applicatie.application.Id}/processList";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(new HomePage.Token(Token));
            //MessageBox.Show(jsonString);
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var httpClient = HttpClientFactory.Create();
            var httpResponseMessage = await httpClient.PostAsync(url, payload);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                //string responsedata = responseBody.Replace(@"\", "");
                List<ProcessJson> processes = JsonConvert.DeserializeObject<List<ProcessJson>>(responseBody);
                MainForm.processes.RemoveAll(x => processes.Contains(x));
                MainForm.processes.AddRange(processes);

                lbxSelectedApps.Items.Clear();
                foreach (ProcessJson invProcess in processes)
                {
                    lbxSelectedApps.Items.Add(invProcess.process.Name);
                }
                loadProcesses();


            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        public class AppProcess
        {
            public string applicationName { get; set; }
            public string processName { get; set; }
            public string jwt { get; set; }

            public AppProcess(string appName, string pProcess, string token)
            {
                this.applicationName = appName;
                this.processName = pProcess;
                this.jwt = token;
            }
        }
        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (var item in lbxSelectedApps.Items)
            {
                if (!MainForm.processes.Exists(x => x.process.Name == item.ToString() && x.id == applicatie.application.Id))
                {
                    AppProcess process = new AppProcess(applicatie.application.Name, item.ToString(), Token);
                    string url = $"https://databasegip2.herokuapp.com/application/{applicatie.application.Id}/process/createProcess";
                    string jsonString = System.Text.Json.JsonSerializer.Serialize(process);
                    //MessageBox.Show(jsonString);
                    var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var httpClient = HttpClientFactory.Create();
                    var httpResponseMessage = await httpClient.PostAsync(url, payload);

                    if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Created)
                    {
                        MessageBox.Show("Success!", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Invalid", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            loadProcessesFromServer();

        }


        private void btnLimit_Click(object sender, EventArgs e)
        {
            LimitForm limitForm = new LimitForm(applicatie.application.Id, Token);
            limitForm.Show();
        }

        private async void btnClear_Click(object sender, EventArgs e)
        {
            string url = $"https://databasegip2.herokuapp.com/application/{applicatie.application.Id}/usage/deleteAllUsage";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(new HomePage.Token(Token));
            //MessageBox.Show(jsonString);
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var httpClient = HttpClientFactory.Create();
            var httpResponseMessage = await httpClient.PostAsync(url, payload);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Success!", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
