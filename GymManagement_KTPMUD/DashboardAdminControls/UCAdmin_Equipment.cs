using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GymManagement_KTPMUD.DashboardAdminControls
{
    public partial class lbName : UserControl
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GymManagementDB;Integrated Security=True";
        public lbName()
        {
            InitializeComponent();
            load_equipment();
            btnAdd.Click += (s, e) => InsertEquipment();
            btnUpdate.Click += (s, e) => UpdateEquipment();
            btnDelete.Click += (s, e) => DeleteEquipment();
            dgvEquipment.CellContentClick += dGV_Equipment_CellContentClick;

        }

        private void UCAdmin_Equipment_Load(object sender, EventArgs e)
        {

        }

        private void dGV_Equipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEquipment.Columns[e.ColumnIndex].Name == "||||")
            {
                LoadSelectedEquipmentToForm(e.RowIndex);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void load_equipment(string keyword = "")
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT EquipmentID, Name, Quantity, Image
                        FROM Equipment";

                    if (!string.IsNullOrWhiteSpace(keyword))
                        query += " WHERE Name LIKE @Search";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(keyword))
                            cmd.Parameters.AddWithValue("@Search", "%" + keyword + "%");

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvEquipment.AutoGenerateColumns = true;
                        dgvEquipment.DataSource = dt;
                    }
                }

                // Ẩn cột Image
                if (dgvEquipment.Columns.Contains("Image"))
                    dgvEquipment.Columns["Image"].Visible = false;

                // Thêm cột View
                if (!dgvEquipment.Columns.Contains("||||"))
                {
                    DataGridViewLinkColumn link = new DataGridViewLinkColumn();
                    link.Name = "||||";              // tên cột
                    link.HeaderText = "||||";        // chữ trên header
                    link.Text = "View";              // chữ hiển thị trong ô
                    link.UseColumnTextForLinkValue = true;

                    dgvEquipment.Columns.Add(link);
                }

                dgvEquipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                dgvEquipment.Columns["EquipmentID"].Width = 150;
                dgvEquipment.Columns["Name"].Width = 300;
                dgvEquipment.Columns["Quantity"].Width = 150;
                dgvEquipment.Columns["||||"].Width = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPEG Files (*.jpeg;*.jpg)|*.jpeg;*.jpg|PNG Files (*.png)|*.png|All Files (*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxEquipment.Image = new Bitmap(dialog.FileName);
                
            }
        }

        private byte[] ImageToBytes(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Tạo một copy của ảnh để tránh file bị lock
                using (Bitmap bmp = new Bitmap(img))
                {
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                return ms.ToArray();
            }
        }

        private void InsertEquipment()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Equipment (Name, Quantity, Image)
                        VALUES (@Name, @Quantity, @Image)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));

                        byte[] imgBytes = ImageToBytes(pictureBoxEquipment.Image);
                        cmd.Parameters.AddWithValue("@Image", (object)imgBytes ?? DBNull.Value);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                MessageBox.Show("Inserted successfully!");
                load_equipment(); // load lại bảng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Insert: " + ex.Message);
            }
        }

        private void UpdateEquipment()
        {
            try
            {
                byte[] imageBytes = null;

                if (pictureBoxEquipment.Image != null)
                {
                    imageBytes = ImageToBytes(pictureBoxEquipment.Image);
                }
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                        UPDATE Equipment
                        SET Name = @Name,
                            Quantity = @Quantity,
                            Image = @Image
                        WHERE EquipmentID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", int.Parse(txtEquipmentID.Text));
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@Quantity", int.Parse(txtQuantity.Text));

                        byte[] imgBytes = ImageToBytes(pictureBoxEquipment.Image);
                        cmd.Parameters.AddWithValue("@Image", (object)imgBytes ?? DBNull.Value);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                MessageBox.Show("Updated successfully!");
                load_equipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Update: " + ex.Message);
            }
        }

        private void DeleteEquipment()
        {
            if (string.IsNullOrWhiteSpace(txtEquipmentID.Text))
            {
                MessageBox.Show("Please select a row to delete!");
                return;
            }

            if (MessageBox.Show("Delete this item?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Equipment WHERE EquipmentID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ID", int.Parse(txtEquipmentID.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                MessageBox.Show("Deleted successfully!");
                load_equipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Delete: " + ex.Message);
            }
        }

        private void LoadSelectedEquipmentToForm(int rowIndex)
        {
            DataGridViewRow row = dgvEquipment.Rows[rowIndex];

            txtEquipmentID.Text = row.Cells["EquipmentID"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtQuantity.Text = row.Cells["Quantity"].Value.ToString();

            if (row.Cells["Image"].Value != DBNull.Value)
            {
                byte[] bytes = (byte[])row.Cells["Image"].Value;
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    pictureBoxEquipment.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBoxEquipment.Image = null;
            }
        }

    }
}
