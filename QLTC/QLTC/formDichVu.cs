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
    public partial class formDichVu : Form
    {
        DataTable dichVu;
        CoSoDuLieu objKetNoi;
        string maDV;
        DataRow dr;

        public string MaDV
        {
            get
            {
                return maDV;
            }

            set
            {
                maDV = value;
            }
        }

        public formDichVu()
        {
            InitializeComponent();
            dichVu = new DataTable();
        }

        public formDichVu(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            dichVu = new DataTable();
            this.objKetNoi = objKetNoi;
        }

        private void formDichVu_Load(object sender, EventArgs e)
        {
            CapNhatDataGrid();
            MaDV = MaTuDong.MaTD(dichVu, "max(madv)", 2);
        }

        void CapNhatDataGrid()
        {
            dichVu = objKetNoi.DocDuLieu("select * from dichvu");
            dgvDichVu.DataSource = dichVu;
            dgvDichVu.Columns[0].HeaderText = "Mã dịch vụ ";
            dgvDichVu.Columns[1].HeaderText = "Tên dịch vụ";
            dgvDichVu.Columns[2].HeaderText = "Đơn giá dịch vụ";
            DataTable dt = objKetNoi.DocDuLieu("select count(madv) from dichvu");
            lblCur.Text = dt.Rows[0][0].ToString();
        }

        void CapNhatDataRow()
        {
            dr[0] = txbMa.Text;
            dr[1] = txbTen.Text;
            dr[2] = txbDonGia.Text;
        }

        void ThemMotDong()
        {
            dr = dichVu.NewRow();
            CapNhatDataRow();
            dichVu.Rows.Add(dr);
            dgvDichVu.DataSource = dichVu;
            RefreshText();
        }

        void XuatThongTin()
        {
            txbMa.Text = dr[0].ToString();
            txbTen.Text = dr[1].ToString();
            txbDonGia.Text = dr[2].ToString();
        }

        void RefreshText()
        {
            txbMa.Text = "";
            txbTen.Text = "";
            txbDonGia.Text = "";
        }

        void CapNhatDuLieu(string chuoi)
        {
            string strSql = "SELECT * FROM DICHVU";
            objKetNoi.CapNhatDuLieu(dichVu, strSql);
            MessageBox.Show(chuoi);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lblCur.Text == lbl20.Text)
            {
                MessageBox.Show("Đã đạt đủ số lượng dịch vụ", "Thông Báo!", MessageBoxButtons.OK);
            }
            else
            {
                ThemMotDong();
                RefreshText();
                CapNhatDuLieu("Thêm Thành Công");
                CapNhatDataGrid();
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CapNhatDataRow();
            DataTable dt = objKetNoi.DocDuLieu("update dichvu set tendv = '" + txbTen.Text + "',dongiadv='" + txbDonGia.Text + "' where madv ='"+dr[0].ToString() + "'");
            CapNhatDataGrid();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn xóa không?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                dichVu = objKetNoi.DocDuLieu("delete dichvu where madv = '" + dr[0].ToString() + "'");
                CapNhatDataGrid();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvDichVu_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dr = dichVu.Rows[dgvDichVu.CurrentRow.Index];
            XuatThongTin();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void dgvDichVu_KeyUp(object sender, KeyEventArgs e)
        {
            dr = dichVu.Rows[dgvDichVu.CurrentRow.Index];
            XuatThongTin();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;

        }
    }
}
