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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCAdmin_Customers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_searchCustomers = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button_ = new System.Windows.Forms.Button();
            this.gymManagementDBDataSet = new GymManagement_KTPMUD.GymManagementDBDataSet();
            this.userAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userAccountTableAdapter = new GymManagement_KTPMUD.GymManagementDBDataSetTableAdapters.UserAccountTableAdapter();
            this.gymManagementDBDataSet1 = new GymManagement_KTPMUD.GymManagementDBDataSet1();
            this.memberBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.memberTableAdapter = new GymManagement_KTPMUD.GymManagementDBDataSet1TableAdapters.MemberTableAdapter();
            this.dGV_Customers = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_searchCustomers = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gymManagementDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymManagementDBDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Customers)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_searchCustomers
            // 
            this.button_searchCustomers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_searchCustomers.BackgroundImage")));
            this.button_searchCustomers.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_searchCustomers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_searchCustomers.Location = new System.Drawing.Point(1216, 94);
            this.button_searchCustomers.Name = "button_searchCustomers";
            this.button_searchCustomers.Size = new System.Drawing.Size(30, 27);
            this.button_searchCustomers.TabIndex = 0;
            this.button_searchCustomers.UseVisualStyleBackColor = true;
            this.button_searchCustomers.Click += new System.EventHandler(this.search_button_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(133, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = " ADD ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(586, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 45);
            this.label1.TabIndex = 6;
            this.label1.Text = "CUSTOMERS";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(740, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 47);
            this.label2.TabIndex = 7;
            this.label2.Text = "SEARCHING FOR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(307, 88);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 45);
            this.button2.TabIndex = 8;
            this.button2.Text = " DELETE ";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_
            // 
            this.button_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.button_.Cursor = System.Windows.Forms.Cursors.Default;
            this.button_.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_.ForeColor = System.Drawing.Color.White;
            this.button_.Location = new System.Drawing.Point(480, 88);
            this.button_.Name = "button_";
            this.button_.Size = new System.Drawing.Size(160, 45);
            this.button_.TabIndex = 9;
            this.button_.Text = "EDIT INFO";
            this.button_.UseVisualStyleBackColor = false;
            this.button_.Click += new System.EventHandler(this.button__Click);
            // 
            // gymManagementDBDataSet
            // 
            this.gymManagementDBDataSet.DataSetName = "GymManagementDBDataSet";
            this.gymManagementDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userAccountBindingSource
            // 
            this.userAccountBindingSource.DataMember = "UserAccount";
            this.userAccountBindingSource.DataSource = this.gymManagementDBDataSet;
            // 
            // userAccountTableAdapter
            // 
            this.userAccountTableAdapter.ClearBeforeFill = true;
            // 
            // gymManagementDBDataSet1
            // 
            this.gymManagementDBDataSet1.DataSetName = "GymManagementDBDataSet1";
            this.gymManagementDBDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // memberBindingSource
            // 
            this.memberBindingSource.DataMember = "Member";
            this.memberBindingSource.DataSource = this.gymManagementDBDataSet1;
            // 
            // memberTableAdapter
            // 
            this.memberTableAdapter.ClearBeforeFill = true;
            // 
            // dGV_Customers
            // 
            this.dGV_Customers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGV_Customers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            this.dGV_Customers.BackgroundColor = System.Drawing.Color.White;
            this.dGV_Customers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGV_Customers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dGV_Customers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_Customers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dGV_Customers.ColumnHeadersHeight = 33;
            this.dGV_Customers.EnableHeadersVisualStyles = false;
            this.dGV_Customers.GridColor = System.Drawing.Color.Black;
            this.dGV_Customers.Location = new System.Drawing.Point(-3, 0);
            this.dGV_Customers.Name = "dGV_Customers";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_Customers.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGV_Customers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.dGV_Customers.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dGV_Customers.RowTemplate.Height = 24;
            this.dGV_Customers.Size = new System.Drawing.Size(1755, 740);
            this.dGV_Customers.TabIndex = 5;
            this.dGV_Customers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGV_Customers_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.dGV_Customers);
            this.panel1.Location = new System.Drawing.Point(3, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1752, 740);
            this.panel1.TabIndex = 10;
            // 
            // txt_searchCustomers
            // 
            this.txt_searchCustomers.BackColor = System.Drawing.Color.White;
            this.txt_searchCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_searchCustomers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_searchCustomers.Location = new System.Drawing.Point(938, 94);
            this.txt_searchCustomers.Name = "txt_searchCustomers";
            this.txt_searchCustomers.Size = new System.Drawing.Size(278, 27);
            this.txt_searchCustomers.TabIndex = 3;
            this.txt_searchCustomers.TextChanged += new System.EventHandler(this.txt_searchCustomers_TextChanged);
            // 
            // UCAdmin_Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Controls.Add(this.txt_searchCustomers);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_searchCustomers);
            this.Name = "UCAdmin_Customers";
            this.Size = new System.Drawing.Size(1800, 1100);
            this.Load += new System.EventHandler(this.UCAdmin_Customers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gymManagementDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userAccountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gymManagementDBDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_Customers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_searchCustomers;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button_;
        private System.Windows.Forms.BindingSource userAccountBindingSource;
        private GymManagementDBDataSet gymManagementDBDataSet;
        private GymManagementDBDataSetTableAdapters.UserAccountTableAdapter userAccountTableAdapter;
        private GymManagementDBDataSet1 gymManagementDBDataSet1;
        private System.Windows.Forms.BindingSource memberBindingSource;
        private GymManagementDBDataSet1TableAdapters.MemberTableAdapter memberTableAdapter;
        private System.Windows.Forms.DataGridView dGV_Customers;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_searchCustomers;
    }
}
