namespace GymManagement_KTPMUD.DashboardUserControls
{
    partial class UCUser_Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCUser_Payment));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btPayNow = new System.Windows.Forms.Button();
            this.roundedPanel1 = new CustomControl.RoundedPanel();
            this.lbTotalDue = new System.Windows.Forms.Label();
            this.lbDuration = new System.Windows.Forms.Label();
            this.lbJoinDate = new System.Windows.Forms.Label();
            this.lbPlanPrice = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPlanName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.roundedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-48, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1890, 1170);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // btPayNow
            // 
            this.btPayNow.BackColor = System.Drawing.Color.DodgerBlue;
            this.btPayNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPayNow.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPayNow.ForeColor = System.Drawing.Color.White;
            this.btPayNow.Image = ((System.Drawing.Image)(resources.GetObject("btPayNow.Image")));
            this.btPayNow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btPayNow.Location = new System.Drawing.Point(788, 533);
            this.btPayNow.Name = "btPayNow";
            this.btPayNow.Size = new System.Drawing.Size(238, 65);
            this.btPayNow.TabIndex = 3;
            this.btPayNow.Text = "         PAY NOW";
            this.btPayNow.UseVisualStyleBackColor = false;
            this.btPayNow.Click += new System.EventHandler(this.btPayNow_Click);
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.White;
            this.roundedPanel1.BorderRadius = 30;
            this.roundedPanel1.Controls.Add(this.lbTotalDue);
            this.roundedPanel1.Controls.Add(this.lbDuration);
            this.roundedPanel1.Controls.Add(this.lbJoinDate);
            this.roundedPanel1.Controls.Add(this.lbPlanPrice);
            this.roundedPanel1.Controls.Add(this.label6);
            this.roundedPanel1.Controls.Add(this.label5);
            this.roundedPanel1.Controls.Add(this.label4);
            this.roundedPanel1.Controls.Add(this.label3);
            this.roundedPanel1.Controls.Add(this.lbPlanName);
            this.roundedPanel1.Controls.Add(this.label1);
            this.roundedPanel1.ForeColor = System.Drawing.Color.Black;
            this.roundedPanel1.GradientAngle = 90F;
            this.roundedPanel1.GradientBottomColor = System.Drawing.Color.Turquoise;
            this.roundedPanel1.GradientTopColor = System.Drawing.Color.PowderBlue;
            this.roundedPanel1.Location = new System.Drawing.Point(410, 176);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.Size = new System.Drawing.Size(1053, 315);
            this.roundedPanel1.TabIndex = 2;
            // 
            // lbTotalDue
            // 
            this.lbTotalDue.AutoSize = true;
            this.lbTotalDue.BackColor = System.Drawing.Color.Transparent;
            this.lbTotalDue.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalDue.ForeColor = System.Drawing.Color.SeaGreen;
            this.lbTotalDue.Location = new System.Drawing.Point(602, 173);
            this.lbTotalDue.Name = "lbTotalDue";
            this.lbTotalDue.Size = new System.Drawing.Size(140, 81);
            this.lbTotalDue.TabIndex = 9;
            this.lbTotalDue.Text = "$79";
            // 
            // lbDuration
            // 
            this.lbDuration.AutoSize = true;
            this.lbDuration.BackColor = System.Drawing.Color.Transparent;
            this.lbDuration.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDuration.ForeColor = System.Drawing.Color.White;
            this.lbDuration.Location = new System.Drawing.Point(203, 234);
            this.lbDuration.Name = "lbDuration";
            this.lbDuration.Size = new System.Drawing.Size(111, 31);
            this.lbDuration.TabIndex = 8;
            this.lbDuration.Text = "3 months";
            // 
            // lbJoinDate
            // 
            this.lbJoinDate.AutoSize = true;
            this.lbJoinDate.BackColor = System.Drawing.Color.Transparent;
            this.lbJoinDate.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbJoinDate.ForeColor = System.Drawing.Color.White;
            this.lbJoinDate.Location = new System.Drawing.Point(203, 187);
            this.lbJoinDate.Name = "lbJoinDate";
            this.lbJoinDate.Size = new System.Drawing.Size(113, 31);
            this.lbJoinDate.TabIndex = 7;
            this.lbJoinDate.Text = "Total Due";
            // 
            // lbPlanPrice
            // 
            this.lbPlanPrice.AutoSize = true;
            this.lbPlanPrice.BackColor = System.Drawing.Color.Transparent;
            this.lbPlanPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlanPrice.ForeColor = System.Drawing.Color.White;
            this.lbPlanPrice.Location = new System.Drawing.Point(203, 138);
            this.lbPlanPrice.Name = "lbPlanPrice";
            this.lbPlanPrice.Size = new System.Drawing.Size(52, 31);
            this.lbPlanPrice.TabIndex = 6;
            this.lbPlanPrice.Text = "$79";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(610, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 31);
            this.label6.TabIndex = 5;
            this.label6.Text = "Total Due";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(64, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "Duration:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(64, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 31);
            this.label4.TabIndex = 3;
            this.label4.Text = "Join Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(63, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "Plan Price:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lbPlanName
            // 
            this.lbPlanName.AutoSize = true;
            this.lbPlanName.BackColor = System.Drawing.Color.Transparent;
            this.lbPlanName.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPlanName.ForeColor = System.Drawing.Color.White;
            this.lbPlanName.Location = new System.Drawing.Point(63, 89);
            this.lbPlanName.Name = "lbPlanName";
            this.lbPlanName.Size = new System.Drawing.Size(193, 38);
            this.lbPlanName.TabIndex = 1;
            this.lbPlanName.Text = "Premium Plan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(362, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "       Payment Due";
            // 
            // UCUser_Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btPayNow);
            this.Controls.Add(this.roundedPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UCUser_Payment";
            this.Size = new System.Drawing.Size(1800, 1100);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.roundedPanel1.ResumeLayout(false);
            this.roundedPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private CustomControl.RoundedPanel roundedPanel1;
        private System.Windows.Forms.Label lbPlanName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTotalDue;
        private System.Windows.Forms.Label lbDuration;
        private System.Windows.Forms.Label lbJoinDate;
        private System.Windows.Forms.Label lbPlanPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btPayNow;
    }
}
