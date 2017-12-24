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
    public partial class formLapHoaDon : Form
    {
        DataTable hdTable;
        CoSoDuLieu objKetNoi;
        DataRow dr;
        public formLapHoaDon()
        {
            InitializeComponent();
            hdTable = new DataTable();
        }
        public formLapHoaDon(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            hdTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }

     
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa hóa đơn này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                hdTable = objKetNoi.DocDuLieu("delete hoadon where mahd='" + dr[0].ToString() + "'");
                formLapHoaDon_Load_1(sender, e);
            }

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            hdTable = objKetNoi.DocDuLieu("select mahd, matiec, ngaytt, tongtienban, tongtiendv,tongtienhd from hoadon where dattiec.matiec = hoadon.matiec");
            dataGridView1.DataSource = hdTable;
            dataGridView1.Columns[0].HeaderText = "Mã HD";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].HeaderText = "mã tiệc";
            dataGridView1.Columns[2].HeaderText = "Ngày thanh toán";
            dataGridView1.Columns[3].HeaderText = "tổng tiền bàn";
            dataGridView1.Columns[4].HeaderText = "tổng tiền dịch vụ";
            dataGridView1.Columns[5].HeaderText = "tổng tiền hóa đơn";

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dr = hdTable.Rows[dataGridView1.CurrentRow.Index];
            btnXoa.Enabled = true;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            formHDThem frmHDT = new formHDThem(objKetNoi);
            frmHDT.ShowDialog();
            CapNhatDataGridView();
        }

        void CapNhatDataGridView()
        {
            hdTable = objKetNoi.DocDuLieu("select mahd, dattiec.matiec, ngaytt, tongtienban, tongtiendv,tongtienhd from hoadon,dattiec where dattiec.matiec = hoadon.matiec");
            dataGridView1.DataSource = hdTable;
            dataGridView1.Columns[0].HeaderText = "Mã HD";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].HeaderText = "mã tiệc";
            dataGridView1.Columns[2].HeaderText = "Ngày thanh toán";
            dataGridView1.Columns[3].HeaderText = "tổng tiền bàn";
            dataGridView1.Columns[4].HeaderText = "tổng tiền dịch vụ";
            dataGridView1.Columns[5].HeaderText = "tổng tiền hóa đơn";
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void formLapHoaDon_Load_1(object sender, EventArgs e)
        {
            CapNhatDataGridView();

        }
    }
}
