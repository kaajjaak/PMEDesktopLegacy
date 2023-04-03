
namespace Productvity_Made_Easy
{
    partial class ApplicationManager
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
            this.lblApplicationName = new System.Windows.Forms.Label();
            this.lbxAllApps = new System.Windows.Forms.ListBox();
            this.lbxSelectedApps = new System.Windows.Forms.ListBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnDeselect = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblLimit = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLimit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblApplicationName
            // 
            this.lblApplicationName.AutoSize = true;
            this.lblApplicationName.Location = new System.Drawing.Point(23, 9);
            this.lblApplicationName.Name = "lblApplicationName";
            this.lblApplicationName.Size = new System.Drawing.Size(145, 20);
            this.lblApplicationName.TabIndex = 0;
            this.lblApplicationName.Text = "Current Application: ";
            // 
            // lbxAllApps
            // 
            this.lbxAllApps.FormattingEnabled = true;
            this.lbxAllApps.ItemHeight = 20;
            this.lbxAllApps.Location = new System.Drawing.Point(23, 55);
            this.lbxAllApps.Name = "lbxAllApps";
            this.lbxAllApps.Size = new System.Drawing.Size(150, 204);
            this.lbxAllApps.TabIndex = 1;
            // 
            // lbxSelectedApps
            // 
            this.lbxSelectedApps.FormattingEnabled = true;
            this.lbxSelectedApps.ItemHeight = 20;
            this.lbxSelectedApps.Location = new System.Drawing.Point(338, 55);
            this.lbxSelectedApps.Name = "lbxSelectedApps";
            this.lbxSelectedApps.Size = new System.Drawing.Size(150, 244);
            this.lbxSelectedApps.TabIndex = 2;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(207, 55);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 29);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "-->";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnDeselect
            // 
            this.btnDeselect.Location = new System.Drawing.Point(207, 269);
            this.btnDeselect.Name = "btnDeselect";
            this.btnDeselect.Size = new System.Drawing.Size(94, 29);
            this.btnDeselect.TabIndex = 4;
            this.btnDeselect.Text = "<--";
            this.btnDeselect.UseVisualStyleBackColor = true;
            this.btnDeselect.Click += new System.EventHandler(this.btnDeselect_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(528, 230);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(103, 29);
            this.btnConfirm.TabIndex = 9;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblLimit
            // 
            this.lblLimit.AutoSize = true;
            this.lblLimit.Location = new System.Drawing.Point(528, 57);
            this.lblLimit.Name = "lblLimit";
            this.lblLimit.Size = new System.Drawing.Size(45, 20);
            this.lblLimit.TabIndex = 11;
            this.lblLimit.Text = "Limit:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(23, 269);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(150, 29);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLimit
            // 
            this.btnLimit.Location = new System.Drawing.Point(528, 103);
            this.btnLimit.Name = "btnLimit";
            this.btnLimit.Size = new System.Drawing.Size(103, 29);
            this.btnLimit.TabIndex = 13;
            this.btnLimit.Text = "Add Limit";
            this.btnLimit.UseVisualStyleBackColor = true;
            this.btnLimit.Click += new System.EventHandler(this.btnLimit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(528, 165);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(103, 29);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear Usage";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // ApplicationManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 327);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLimit);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblLimit);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnDeselect);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.lbxSelectedApps);
            this.Controls.Add(this.lbxAllApps);
            this.Controls.Add(this.lblApplicationName);
            this.Name = "ApplicationManager";
            this.Text = "ApplicationManager";
            this.Load += new System.EventHandler(this.ApplicationManager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicationName;
        private System.Windows.Forms.ListBox lbxAllApps;
        private System.Windows.Forms.ListBox lbxSelectedApps;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnDeselect;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblLimit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLimit;
        private System.Windows.Forms.Button btnClear;
    }
}