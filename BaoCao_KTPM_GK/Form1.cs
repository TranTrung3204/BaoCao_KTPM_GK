using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoCao_KTPM_GK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnArea_62_Trung_Click(object sender, EventArgs e)
        {
            try
            {
                double x1 = double.Parse(txtX1_62_Trung.Text);
                double y1 = double.Parse(txtY1_62_Trung.Text);
                double x2 = double.Parse(txtX2_62_Trung.Text);
                double y2 = double.Parse(txtY2_62_Trung.Text);
                double x3 = double.Parse(txtX3_62_Trung.Text);
                double y3 = double.Parse(txtY3_62_Trung.Text);
                double x4 = double.Parse(txtX4_62_Trung.Text);
                double y4 = double.Parse(txtY4_62_Trung.Text);

                double area = Rectangle_62_Trung.CalculateArea_62_Trung(x1, y1, x2, y2, x3, y3, x4, y4);
                lblKetQua_62_Trung.Text = $"Diện tích: {area}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static class Rectangle_62_Trung
        {
            public static double CalculateArea_62_Trung(double x1_62_Trung, double y1_62_Trung, double x2_62_Trung, double y2_62_Trung,
                                               double x3_62_Trung, double y3_62_Trung, double x4_62_Trung, double y4_62_Trung)
            {
                if (!IsRectangle_62_Trung(x1_62_Trung, y1_62_Trung, x2_62_Trung, y2_62_Trung, x3_62_Trung, y3_62_Trung, x4_62_Trung, y4_62_Trung))
                    throw new ArgumentException("4 điểm không tạo thành hình chữ nhật hợp lệ");

                double width_62_Trung = Math.Sqrt(Math.Pow(x2_62_Trung - x1_62_Trung, 2) + Math.Pow(y2_62_Trung - y1_62_Trung, 2));
                double height_62_Trung = Math.Sqrt(Math.Pow(x3_62_Trung - x1_62_Trung, 2) + Math.Pow(y3_62_Trung - y1_62_Trung, 2));
                return width_62_Trung * height_62_Trung;
            }

            public static bool IsRectangle_62_Trung(double x1_62_Trung, double y1_62_Trung, double x2_62_Trung, double y2_62_Trung,
                                           double x3_62_Trung, double y3_62_Trung, double x4_62_Trung, double y4_62_Trung)
            {
                double d1_62_Trung = Math.Pow(x2_62_Trung - x1_62_Trung, 2) + Math.Pow(y2_62_Trung - y1_62_Trung, 2);
                double d2_62_Trung = Math.Pow(x3_62_Trung - x2_62_Trung, 2) + Math.Pow(y3_62_Trung - y2_62_Trung, 2);
                double d3_62_Trung = Math.Pow(x4_62_Trung - x3_62_Trung, 2) + Math.Pow(y4_62_Trung - y3_62_Trung, 2);
                double d4_62_Trung = Math.Pow(x1_62_Trung - x4_62_Trung, 2) + Math.Pow(y1_62_Trung - y4_62_Trung, 2);

                double diagonal1_62_Trung = Math.Pow(x3_62_Trung - x1_62_Trung, 2) + Math.Pow(y3_62_Trung - y1_62_Trung, 2);
                double diagonal2_62_Trung = Math.Pow(x4_62_Trung - x2_62_Trung, 2) + Math.Pow(y4_62_Trung - y2_62_Trung, 2);

                return (d1_62_Trung == d3_62_Trung && d2_62_Trung == d4_62_Trung && diagonal1_62_Trung == diagonal2_62_Trung);
            }
        }
    }
}
