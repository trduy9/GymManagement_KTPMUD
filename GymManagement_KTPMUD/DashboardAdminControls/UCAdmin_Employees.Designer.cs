namespace GymManagement_KTPMUD.DashboardAdminControls
{
    partial class UCAdmin_Employees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAdmin_Employees));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_searchEmployee = new System.Windows.Forms.TextBox();
            this.button_searchCustomers = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dGV_Employees = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Employees)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employees";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(86, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Search Name";
            // 
            // textBox_searchEmployee
            // 
            this.textBox_searchEmployee.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_searchEmployee.Location = new System.Drawing.Point(242, 78);
            this.textBox_searchEmployee.Name = "textBox_searchEmployee";
            this.textBox_searchEmployee.Size = new System.Drawing.Size(285, 33);
            this.textBox_searchEmployee.TabIndex = 4;
            // 
            // button_searchCustomers
            // 
            this.button_searchCustomers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_searchCustomers.BackgroundImage")));
            this.button_searchCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_searchCustomers.Location = new System.Drawing.Point(526, 79);
            this.button_searchCustomers.Name = "button_searchCustomers";
            this.button_searchCustomers.Size = new System.Drawing.Size(37, 33);
            this.button_searchCustomers.TabIndex = 5;
            this.button_searchCustomers.UseVisualStyleBackColor = true;
            this.button_searchCustomers.Click += new System.EventHandler(this.button_searchCustomers_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(626, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add Employees";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(816, 77);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 37);
            this.button2.TabIndex = 7;
            this.button2.Text = "Delete Employees";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dGV_Employees
            // 
            this.dGV_Employees.BackgroundColor = System.Drawing.Color.White;
            this.dGV_Employees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Employees.Location = new System.Drawing.Point(91, 138);
            this.dGV_Employees.Name = "dGV_Employees";
            this.dGV_Employees.RowHeadersWidth = 51;
            this.dGV_Employees.RowTemplate.Height = 24;
            this.dGV_Employees.Size = new System.Drawing.Size(1090, 568);
            this.dGV_Employees.TabIndex = 8;
            this.dGV_Employees.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(1010, 77);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 37);
            this.button3.TabIndex = 9;
            this.button3.Text = "Edit Info";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // UCAdmin_Employees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dGV_Employees);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_searchCustomers);
            this.Controls.Add(this.textBox_searchEmployee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "UCAdmin_Employees";
            this.Size = new System.Drawing.Size(2000, 1600);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Employees)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_searchEmployee;
        private System.Windows.Forms.Button button_searchCustomers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dGV_Employees;
        private System.Windows.Forms.Button button3;
    }
}
