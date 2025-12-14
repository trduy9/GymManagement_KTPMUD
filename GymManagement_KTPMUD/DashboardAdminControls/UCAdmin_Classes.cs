using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace GymManagement_KTPMUD.DashboardAdminControls
{
    public partial class UCAdmin_Classes : UserControl
    {
        int month, year;
        // create a static variable that can pass to another form for month and year
        public static int static_month, static_year;

        public UCAdmin_Classes()
        {
            InitializeComponent();
            displayDays();
        }


        private void displayDays()
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            static_month = month;
            static_year = year;

            // get the first day of the month

            DateTime startofthemonth = new DateTime(year, month, 1);

            //get the count of days in the month
            int days = DateTime.DaysInMonth(year, month);

            // convert the startofthemonth into interger
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            // loop to create day buttons
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            // create usercontrol for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // clear container
            daycontainer.Controls.Clear();

            // increase month by when click next button
            month++;
            static_month = month;
            static_year = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            //get the count of days in the month
            int days = DateTime.DaysInMonth(year, month);

            // convert the startofthemonth into interger
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            // loop to create day buttons
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            // create usercontrol for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void button_previous_Click(object sender, EventArgs e)
        {
            // clear container
            daycontainer.Controls.Clear();

            // decrease month by when click next button
            month--;
            static_month = month;
            static_year = year;
            String monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = monthname + " " + year;

            DateTime startofthemonth = new DateTime(year, month, 1);

            //get the count of days in the month
            int days = DateTime.DaysInMonth(year, month);

            // convert the startofthemonth into interger
            int dayoftheweek = Convert.ToInt32(startofthemonth.DayOfWeek.ToString("d")) + 1;

            // loop to create day buttons
            for (int i = 1; i < dayoftheweek; i++)
            {
                UserControlBlank ucblank = new UserControlBlank();
                daycontainer.Controls.Add(ucblank);
            }

            // create usercontrol for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucdays = new UserControlDays();
                ucdays.days(i);
                daycontainer.Controls.Add(ucdays);
            }
        }

        private void UCAdmin_Classes_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    //    SqlConnection conn = new SqlConnection(
    //    "Data Source=.;Initial Catalog=GymManagement;Integrated Security=True");

    //    // ngày được chọn (từ UserControlDays)
    //    public static int static_year;
    //    public static int static_month;

    //    public UCAdmin_Classes()
    //    {
    //        InitializeComponent();
    //    }

    //    private void UCAdmin_Classes_Load(object sender, EventArgs e)
    //    {
    //        static_year = DateTime.Now.Year;
    //        static_month = DateTime.Now.Month;

    //        DisplayDays();
    //        LoadClasses();   // ← tự load lớp đã tạo trước đây
    //    }

    //    // Hiển thị từ 1 -> 31 ngày trong tháng
    //    private void DisplayDays()
    //    {
    //        flowLayoutPanelDays.Controls.Clear();

    //        int days = DateTime.DaysInMonth(static_year, static_month);

    //        for (int i = 1; i <= days; i++)
    //        {
    //            UserControlDays ucd = new UserControlDays();
    //            ucd.DayNumber = i;
    //            flowLayoutPanelDays.Controls.Add(ucd);
    //        }
    //    }

    //    // Load Class đã lưu trong database
    //    private void LoadClasses()
    //    {
    //        flowLayoutPanelClasses.Controls.Clear();

    //        try
    //        {
    //            conn.Open();

    //            string sql = "SELECT ClassName, Schedule FROM Class ORDER BY Id DESC";
    //            SqlCommand cmd = new SqlCommand(sql, conn);
    //            SqlDataReader dr = cmd.ExecuteReader();

    //            while (dr.Read())
    //            {
    //                Panel p = new Panel();
    //                p.Width = 250;
    //                p.Height = 60;
    //                p.BackColor = Color.AliceBlue;
    //                p.Padding = new Padding(10);
    //                p.Margin = new Padding(5);

    //                Label lbName = new Label();
    //                lbName.Text = "Tên lớp: " + dr["ClassName"].ToString();
    //                lbName.Font = new Font("Segoe UI", 10, FontStyle.Bold);
    //                lbName.Dock = DockStyle.Top;

    //                Label lbDate = new Label();
    //                lbDate.Text = "Ngày: " + dr["Schedule"].ToString();
    //                lbDate.Font = new Font("Segoe UI", 9);
    //                lbDate.Dock = DockStyle.Bottom;

    //                p.Controls.Add(lbName);
    //                p.Controls.Add(lbDate);

    //                flowLayoutPanelClasses.Controls.Add(p);
    //            }

    //            dr.Close();
    //        }
    //        catch (Exception ex)
    //        {
    //            MessageBox.Show("Error loading classes: " + ex.Message);
    //        }
    //        finally
    //        {
    //            conn.Close();
    //        }
    //    }
    //}
}

