namespace GymManagement_KTPMUD.DashboardAdminControls
{
    partial class UCAdmin_Payment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSummary = new System.Windows.Forms.Panel();
            this.panelTodayPayment = new System.Windows.Forms.Panel();
            this.lblTodayPayment = new System.Windows.Forms.Label();
            this.lblTodayTitle = new System.Windows.Forms.Label();
            this.panelTotalRevenue = new System.Windows.Forms.Panel();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panelSummary.SuspendLayout();
            this.panelTodayPayment.SuspendLayout();
            this.panelTotalRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSummary
            // 
            this.panelSummary.Controls.Add(this.panelTodayPayment);
            this.panelSummary.Controls.Add(this.panelTotalRevenue);
            this.panelSummary.Location = new System.Drawing.Point(456, 56);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(861, 197);
            this.panelSummary.TabIndex = 0;
            // 
            // panelTodayPayment
            // 
            this.panelTodayPayment.BackColor = System.Drawing.Color.Lime;
            this.panelTodayPayment.Controls.Add(this.lblTodayPayment);
            this.panelTodayPayment.Controls.Add(this.lblTodayTitle);
            this.panelTodayPayment.Location = new System.Drawing.Point(439, 25);
            this.panelTodayPayment.Name = "panelTodayPayment";
            this.panelTodayPayment.Size = new System.Drawing.Size(394, 149);
            this.panelTodayPayment.TabIndex = 1;
            // 
            // lblTodayPayment
            // 
            this.lblTodayPayment.AutoSize = true;
            this.lblTodayPayment.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayPayment.ForeColor = System.Drawing.Color.White;
            this.lblTodayPayment.Location = new System.Drawing.Point(23, 83);
            this.lblTodayPayment.Name = "lblTodayPayment";
            this.lblTodayPayment.Size = new System.Drawing.Size(46, 54);
            this.lblTodayPayment.TabIndex = 2;
            this.lblTodayPayment.Text = "0";
            // 
            // lblTodayTitle
            // 
            this.lblTodayTitle.AutoSize = true;
            this.lblTodayTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayTitle.ForeColor = System.Drawing.Color.White;
            this.lblTodayTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTodayTitle.Name = "lblTodayTitle";
            this.lblTodayTitle.Size = new System.Drawing.Size(247, 38);
            this.lblTodayTitle.TabIndex = 1;
            this.lblTodayTitle.Text = "PAYMENT TODAY";
            this.lblTodayTitle.Click += new System.EventHandler(this.lblTodayTitle_Click);
            // 
            // panelTotalRevenue
            // 
            this.panelTotalRevenue.BackColor = System.Drawing.Color.Cyan;
            this.panelTotalRevenue.Controls.Add(this.lblTotalRevenue);
            this.panelTotalRevenue.Controls.Add(this.lblTotalTitle);
            this.panelTotalRevenue.Location = new System.Drawing.Point(22, 25);
            this.panelTotalRevenue.Name = "panelTotalRevenue";
            this.panelTotalRevenue.Size = new System.Drawing.Size(394, 149);
            this.panelTotalRevenue.TabIndex = 0;
            // 
            // lblTotalRevenue
            // 
            this.lblTotalRevenue.AutoSize = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.White;
            this.lblTotalRevenue.Location = new System.Drawing.Point(23, 83);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(146, 54);
            this.lblTotalRevenue.TabIndex = 1;
            this.lblTotalRevenue.Text = "0 VNĐ";
            this.lblTotalRevenue.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTotalTitle
            // 
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTitle.ForeColor = System.Drawing.Color.White;
            this.lblTotalTitle.Location = new System.Drawing.Point(23, 18);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(232, 38);
            this.lblTotalTitle.TabIndex = 0;
            this.lblTotalTitle.Text = "TOTAL REVENUE";
            this.lblTotalTitle.Click += new System.EventHandler(this.lblTotalTitle_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(78, 470);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1239, 592);
            this.dataGridView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1504, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Payment Detail";
            // 
            // UCAdmin_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panelSummary);
            this.Name = "UCAdmin_Payment";
            this.Size = new System.Drawing.Size(1800, 1100);
            this.panelSummary.ResumeLayout(false);
            this.panelTodayPayment.ResumeLayout(false);
            this.panelTodayPayment.PerformLayout();
            this.panelTotalRevenue.ResumeLayout(false);
            this.panelTotalRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Panel panelTotalRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Panel panelTodayPayment;
        private System.Windows.Forms.Label lblTodayPayment;
        private System.Windows.Forms.Label lblTodayTitle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}
