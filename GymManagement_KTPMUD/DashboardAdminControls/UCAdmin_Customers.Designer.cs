namespace GymManagement_KTPMUD.DashboardAdminControls
{
    partial class UCAdmin_Customers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAdmin_Customers));
            this.button_searchCustomers = new System.Windows.Forms.Button();
            this.txt_searchCustomers = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dGV_Customers = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button_ = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Customers)).BeginInit();
            this.SuspendLayout();
            // 
            // button_searchCustomers
            // 
            this.button_searchCustomers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_searchCustomers.BackgroundImage")));
            this.button_searchCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_searchCustomers.Location = new System.Drawing.Point(511, 72);
            this.button_searchCustomers.Name = "button_searchCustomers";
            this.button_searchCustomers.Size = new System.Drawing.Size(37, 33);
            this.button_searchCustomers.TabIndex = 0;
            this.button_searchCustomers.UseVisualStyleBackColor = true;
            this.button_searchCustomers.Click += new System.EventHandler(this.search_button_Click);
            // 
            // txt_searchCustomers
            // 
            this.txt_searchCustomers.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchCustomers.Location = new System.Drawing.Point(242, 71);
            this.txt_searchCustomers.Name = "txt_searchCustomers";
            this.txt_searchCustomers.Size = new System.Drawing.Size(270, 33);
            this.txt_searchCustomers.TabIndex = 3;
            this.txt_searchCustomers.TextChanged += new System.EventHandler(this.txt_searchCustomers_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(636, 69);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(171, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add Customers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dGV_Customers
            // 
            this.dGV_Customers.BackgroundColor = System.Drawing.Color.White;
            this.dGV_Customers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_Customers.Location = new System.Drawing.Point(92, 128);
            this.dGV_Customers.Name = "dGV_Customers";
            this.dGV_Customers.RowHeadersWidth = 51;
            this.dGV_Customers.RowTemplate.Height = 24;
            this.dGV_Customers.Size = new System.Drawing.Size(1099, 577);
            this.dGV_Customers.TabIndex = 5;
            this.dGV_Customers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Customers_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 35);
            this.label1.TabIndex = 6;
            this.label1.Text = "Customers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 26);
            this.label2.TabIndex = 7;
            this.label2.Text = "Search Name";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(827, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(171, 37);
            this.button2.TabIndex = 8;
            this.button2.Text = "Delete Customers";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_
            // 
            this.button_.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_.Location = new System.Drawing.Point(1020, 67);
            this.button_.Name = "button_";
            this.button_.Size = new System.Drawing.Size(171, 37);
            this.button_.TabIndex = 9;
            this.button_.Text = "Edit Info";
            this.button_.UseVisualStyleBackColor = true;
            this.button_.Click += new System.EventHandler(this.button__Click);
            // 
            // UCAdmin_Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button_);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGV_Customers);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_searchCustomers);
            this.Controls.Add(this.button_searchCustomers);
            this.Name = "UCAdmin_Customers";
            this.Size = new System.Drawing.Size(2000, 1600);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Customers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_searchCustomers;
        private System.Windows.Forms.TextBox txt_searchCustomers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dGV_Customers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_;
    }
}
