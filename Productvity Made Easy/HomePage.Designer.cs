
namespace Productvity_Made_Easy
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCreateProcess = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lbxApplicaties = new System.Windows.Forms.ListBox();
            this.btnManage = new System.Windows.Forms.Button();
            this.ApplicationTimer = new System.Windows.Forms.Timer(this.components);
            this.CheckLimit = new System.Windows.Forms.Timer(this.components);
            this.killer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnCreateProcess
            // 
            this.btnCreateProcess.Location = new System.Drawing.Point(17, 32);
            this.btnCreateProcess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCreateProcess.Name = "btnCreateProcess";
            this.btnCreateProcess.Size = new System.Drawing.Size(240, 31);
            this.btnCreateProcess.TabIndex = 6;
            this.btnCreateProcess.Text = "Create Application";
            this.btnCreateProcess.UseVisualStyleBackColor = true;
            this.btnCreateProcess.Click += new System.EventHandler(this.btnCreateProcess_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(17, 87);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(240, 31);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh Applications";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbxApplicaties
            // 
            this.lbxApplicaties.FormattingEnabled = true;
            this.lbxApplicaties.ItemHeight = 20;
            this.lbxApplicaties.Location = new System.Drawing.Point(290, 32);
            this.lbxApplicaties.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbxApplicaties.Name = "lbxApplicaties";
            this.lbxApplicaties.Size = new System.Drawing.Size(165, 224);
            this.lbxApplicaties.TabIndex = 8;
            // 
            // btnManage
            // 
            this.btnManage.Location = new System.Drawing.Point(17, 143);
            this.btnManage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnManage.Name = "btnManage";
            this.btnManage.Size = new System.Drawing.Size(240, 31);
            this.btnManage.TabIndex = 9;
            this.btnManage.Text = "Manage Selected Application";
            this.btnManage.UseVisualStyleBackColor = true;
            this.btnManage.Click += new System.EventHandler(this.btnManage_Click);
            // 
            // ApplicationTimer
            // 
            this.ApplicationTimer.Enabled = true;
            this.ApplicationTimer.Interval = 1000;
            this.ApplicationTimer.Tick += new System.EventHandler(this.ApplicationTimer_Tick);
            // 
            // CheckLimit
            // 
            this.CheckLimit.Enabled = true;
            this.CheckLimit.Interval = 10000;
            this.CheckLimit.Tick += new System.EventHandler(this.CheckLimit_Tick);
            // 
            // killer
            // 
            this.killer.Enabled = true;
            this.killer.Interval = 1000;
            this.killer.Tick += new System.EventHandler(this.killer_Tick);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 325);
            this.Controls.Add(this.btnManage);
            this.Controls.Add(this.lbxApplicaties);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCreateProcess);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HomePage";
            this.Text = "HomePage";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreateProcess;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lbxApplicaties;
        private System.Windows.Forms.Button btnManage;
        private System.Windows.Forms.Timer ApplicationTimer;
        private System.Windows.Forms.Timer CheckLimit;
        private System.Windows.Forms.Timer killer;
    }
}