
namespace Productvity_Made_Easy
{
    partial class LimitForm
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
            this.lblLabel = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtDay = new System.Windows.Forms.TextBox();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtSec = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(109, 31);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(82, 20);
            this.lblLabel.TabIndex = 0;
            this.lblLabel.Text = "Limit Time:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(97, 270);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(94, 29);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtDay
            // 
            this.txtDay.Location = new System.Drawing.Point(84, 73);
            this.txtDay.Name = "txtDay";
            this.txtDay.PlaceholderText = "Days";
            this.txtDay.Size = new System.Drawing.Size(125, 27);
            this.txtDay.TabIndex = 2;
            // 
            // txtHour
            // 
            this.txtHour.Location = new System.Drawing.Point(84, 121);
            this.txtHour.Name = "txtHour";
            this.txtHour.PlaceholderText = "Hours";
            this.txtHour.Size = new System.Drawing.Size(125, 27);
            this.txtHour.TabIndex = 3;
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(84, 169);
            this.txtMin.Name = "txtMin";
            this.txtMin.PlaceholderText = "Minutes";
            this.txtMin.Size = new System.Drawing.Size(125, 27);
            this.txtMin.TabIndex = 4;
            // 
            // txtSec
            // 
            this.txtSec.Location = new System.Drawing.Point(84, 217);
            this.txtSec.Name = "txtSec";
            this.txtSec.PlaceholderText = "Seconds";
            this.txtSec.Size = new System.Drawing.Size(125, 27);
            this.txtSec.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(97, 315);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // LimitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 356);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtSec);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.txtHour);
            this.Controls.Add(this.txtDay);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblLabel);
            this.Name = "LimitForm";
            this.Text = "LimitForm";
            this.Load += new System.EventHandler(this.LimitForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.TextBox txtDay;
        private System.Windows.Forms.TextBox txtHour;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtSec;
        private System.Windows.Forms.Button btnCancel;
    }
}