using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTC
{
    public partial class fromDoanhThu : Form
    {
        DataTable dt;
        CoSoDuLieu objKetNoi;
        string thang;
        string nam;
        public fromDoanhThu()
        {
            InitializeComponent();
            dt = new DataTable();
        }

        public fromDoanhThu(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            dt = new DataTable();
            this.objKetNoi = objKetNoi;
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            thang = cboThang.Text;
            nam = cboNam.Text;
            dt = objKetNoi.DocDuLieu("select  convert(varchar, ngaytt,103),count(mahd), SUM(convert(int, tongtienhd)), AVG(convert(int, tongtienhd)) from HOADON where MONTH(ngaytt) = " + thang.Substring(6) + " and year(ngaytt) = " + nam.Substring(4) + " group by ngaytt");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Ngày thanh toán";
            dataGridView1.Columns[1].HeaderText = "Số lượng tiệc";
            dataGridView1.Columns[2].HeaderText = "Doanh thu";
            dataGridView1.Columns[3].HeaderText = "Tỷ lệ";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fromDoanhThu_Load(object sender, EventArgs e)
        {

        }
    }
}
