using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;
using System.Linq;
using System.Globalization;
using Newtonsoft.Json.Converters;
namespace Productvity_Made_Easy
{
    public partial class HomePage : Form
    {
        public class Token
        {
            public string token {get; set; }

            public Token(string token)
            {
                this.token = token;
            }
        }
        public class ApplicationGroup
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            public override string ToString()
            {
                return $"{Id} - {Name}";
            }
        }
        public class ApplicationJson
        {
            [JsonProperty("application")]
            public ApplicationGroup application { get; set; }
        }



        string jwt;
        List<ApplicationJson> applicaties = new List<ApplicationJson>();

        public HomePage(string jwt)
        {
            this.jwt = jwt;
            InitializeComponent();
        }

        /*private void HomePage_Load(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {
                    runningProcess.Items.Add(p.ProcessName);
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            selectedProcess.Items.Add(runningProcess.SelectedItem.ToString());
            runningProcess.Items.RemoveAt(runningProcess.SelectedIndex);
        }
        */
        private void btnCreateProcess_Click(object sender, EventArgs e)
        {
            ProcessMaker processMaker = new ProcessMaker(jwt, this);
            processMaker.ShowDialog();
        }

        public async void LoadApplications()
        {
            Token token = new Token(jwt);
            string url = "https://databasegip2.herokuapp.com/application/applicationList";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(token);
            //MessageBox.Show(jsonString);
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var httpClient = HttpClientFactory.Create();
            var httpResponseMessage = await httpClient.PostAsync(url, payload);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                //string responsedata = responseBody.Replace(@"\", "");


                applicaties = JsonConvert.DeserializeObject<List<ApplicationJson>>(responseBody);

                lbxApplicaties.Items.Clear();
                foreach (ApplicationJson application in applicaties)
                {
                    lbxApplicaties.Items.Add(application.application.Name);
                }

            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadApplications();
        }

        private void btnManage_Click(object sender, EventArgs e)
        {
            if (lbxApplicaties.Items.Count == 0 || lbxApplicaties.SelectedIndex == -1) return;
            new ApplicationManager(applicaties[lbxApplicaties.SelectedIndex], jwt).Show();
        }
        IDictionary<int, bool> usage = new Dictionary<int, bool>();
        IDictionary<int, bool> running = new Dictionary<int, bool>();
        private void ApplicationTimer_Tick(object sender, EventArgs e)
        {
            Process[] RunningProcesses = Process.GetProcesses();
            foreach (ApplicationManager.ProcessJson AppProcess in MainForm.processes)
            {
                running[AppProcess.id] = false;
                foreach (Process RunningProcess in RunningProcesses)
                {
                    if (AppProcess.process.Name == RunningProcess.ProcessName)
                    {
                        if (!usage.ContainsKey(AppProcess.id) || usage[AppProcess.id] != true)
                        {
                            usage[AppProcess.id] = true;
                            running[AppProcess.id] = true;
                            startUsage(AppProcess.id);
                            break;
                        }
                        else
                        {
                            running[AppProcess.id] = true;
                        }
                    }
                }
                if (running[AppProcess.id] == false)
                {
                    if (usage.ContainsKey(AppProcess.id) && usage[AppProcess.id] != false)
                    {
                        bool other = false;
                        foreach (ApplicationManager.ProcessJson AppProcess2 in MainForm.processes.FindAll(x => x.id == AppProcess.id))
                        {
                            if(RunningProcesses.Any(x => x.ProcessName == AppProcess2.process.Name)) other = true;
                        }
                        if (other) continue;
                        endUsage(AppProcess.id);
                    }
                    usage[AppProcess.id] = false;
                }
            }
        }
        IDictionary<int, bool> bezig = new Dictionary<int, bool>();
        private async void startUsage(int app_id)
        {
            if (!bezig.ContainsKey(app_id) || bezig[app_id] != true)
                bezig[app_id] = true;
                string url = $"https://databasegip2.herokuapp.com/application/{app_id}/usage/startUsage";
                string jsonString = System.Text.Json.JsonSerializer.Serialize(new HomePage.Token(jwt));
                //MessageBox.Show(jsonString);
                var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var httpClient = HttpClientFactory.Create();
                var httpResponseMessage = await httpClient.PostAsync(url, payload);

                if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    bezig[app_id] = false;
                }
                else
                {
                    bezig[app_id] = false;
                    MessageBox.Show("Error!", "Error!");
                }
        }

        private async void endUsage(int app_id)
        {
            if (!bezig.ContainsKey(app_id) || bezig[app_id] != true)
                bezig[app_id] = true;
            string url = $"https://databasegip2.herokuapp.com/application/{app_id}/usage/endUsage";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(new HomePage.Token(jwt));
            //MessageBox.Show(jsonString);
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var httpClient = HttpClientFactory.Create();
            var httpResponseMessage = await httpClient.PostAsync(url, payload);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                bezig[app_id] = false;
            }
            else
            {
                bezig[app_id] = false;
                MessageBox.Show("Error!", "Error!");
            }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class MyArray
        {
            [JsonProperty("app")]
            public string App { get; set; }
        }

        public class Root
        {
            [JsonProperty("MyArray")]
            public List<MyArray> MyArray { get; set; }
        }





        List<string> processesToKill = new List<string>();
        private async void terminator()
        {
            string url = $"https://databasegip2.herokuapp.com/accounts/checklimits";
            string jsonString = System.Text.Json.JsonSerializer.Serialize(new HomePage.Token(jwt));
            //MessageBox.Show(jsonString);
            var payload = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var httpClient = HttpClientFactory.Create();
            var httpResponseMessage = await httpClient.PostAsync(url, payload);

            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();
                processesToKill = JsonConvert.DeserializeObject<List<string>>(responseBody);
                kill();
            }

            else
            {
                MessageBox.Show("Error!", "Error!");
            }
        }

        private void kill()
        {
            Process[] RunningProcesses = Process.GetProcesses();
            foreach (string process in processesToKill)
            {
                foreach (Process RunningProcess in RunningProcesses)
                {
                    if (process == RunningProcess.ProcessName)
                    {
                        RunningProcess.Kill();
                    }
                }
            }
        }

        private void killer_Tick(object sender, EventArgs e)
        {
            kill();
        }

        private void CheckLimit_Tick(object sender, EventArgs e)
        {
            terminator();
        }
    }
}
