namespace Private_Schooling_Information_System
{
    partial class Action
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPullReport = new System.Windows.Forms.Button();
            this.btnAddViolation = new System.Windows.Forms.Button();
            this.btnLogViolation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "Take action";
            // 
            // btnPullReport
            // 
            this.btnPullReport.BackColor = System.Drawing.Color.Aqua;
            this.btnPullReport.Location = new System.Drawing.Point(196, 153);
            this.btnPullReport.Name = "btnPullReport";
            this.btnPullReport.Size = new System.Drawing.Size(108, 56);
            this.btnPullReport.TabIndex = 1;
            this.btnPullReport.Text = "Create Report";
            this.btnPullReport.UseVisualStyleBackColor = false;
            this.btnPullReport.Click += new System.EventHandler(this.btnPullReport_Click);
            // 
            // btnAddViolation
            // 
            this.btnAddViolation.BackColor = System.Drawing.Color.Lime;
            this.btnAddViolation.Location = new System.Drawing.Point(309, 269);
            this.btnAddViolation.Name = "btnAddViolation";
            this.btnAddViolation.Size = new System.Drawing.Size(108, 56);
            this.btnAddViolation.TabIndex = 3;
            this.btnAddViolation.Text = "Add Violations";
            this.btnAddViolation.UseVisualStyleBackColor = false;
            this.btnAddViolation.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnLogViolation
            // 
            this.btnLogViolation.BackColor = System.Drawing.Color.Red;
            this.btnLogViolation.Location = new System.Drawing.Point(86, 269);
            this.btnLogViolation.Name = "btnLogViolation";
            this.btnLogViolation.Size = new System.Drawing.Size(108, 56);
            this.btnLogViolation.TabIndex = 2;
            this.btnLogViolation.Text = "Log Violation";
            this.btnLogViolation.UseVisualStyleBackColor = false;
            this.btnLogViolation.Click += new System.EventHandler(this.btnLogViolation_Click);
            // 
            // Action
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(509, 395);
            this.Controls.Add(this.btnLogViolation);
            this.Controls.Add(this.btnAddViolation);
            this.Controls.Add(this.btnPullReport);
            this.Controls.Add(this.label1);
            this.Name = "Action";
            this.Text = "Action";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPullReport;
        private System.Windows.Forms.Button btnAddViolation;
        private System.Windows.Forms.Button btnLogViolation;
    }
}