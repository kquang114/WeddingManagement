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
    public partial class formDanhSachSanh : Form
    {
        CoSoDuLieu objKetNoi;
        DataTable sanhTable;
        DataTable loaiTable;
        string masanh;
        DataRow dr;

        public string Masanh
        {
            get
            {
                return masanh;
            }

            set
            {
                masanh = value;
            }
        }

        public formDanhSachSanh()
        {
            InitializeComponent();
            sanhTable = new DataTable();
            loaiTable = new DataTable();
        }

        public formDanhSachSanh(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            sanhTable = new DataTable();
            loaiTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }

        private void formDanhSachSanh_Load(object sender, EventArgs e)
        {
            CapNhatDataGridView();
        }

        void CapNhatDataGridView()
        {
            sanhTable = objKetNoi.DocDuLieu("select masanh,loai.loaisanh,tensanh,slbantoida,dgbantoithieu,tinhtrangsanh from sanh,loai where loai.loaisanh = sanh.loaisanh");
            dgvSanh.DataSource = sanhTable;
            dgvSanh.Columns[0].HeaderText = "masanh";
            dgvSanh.Columns[1].HeaderText = "loaisanh";
            dgvSanh.Columns[2].HeaderText = "tensanh";
            dgvSanh.Columns[2].Width = 150;
            dgvSanh.Columns[3].HeaderText = "slbantoida";
            dgvSanh.Columns[4].HeaderText = "dgbantoithieu";
            dgvSanh.Columns[5].HeaderText = "tinhtrang";
            dgvSanh.Columns[5].Width = 200;
            DataTable dt = objKetNoi.DocDuLieu("select count(masanh) from sanh ");
            lblCur.Text = dt.Rows[0][0].ToString();
        }


        private void dgvSanh_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dr = sanhTable.Rows[dgvSanh.CurrentRow.Index];
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            formThemSanh frmThemSanh = new formThemSanh(objKetNoi);
            frmThemSanh.ShowDialog();
            CapNhatDataGridView();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            formSuaSanh frmSuaSanh = new formSuaSanh(objKetNoi);
            frmSuaSanh.MaSanh = dr[0].ToString();
            frmSuaSanh.LoaiSanh = dr[1].ToString();
            frmSuaSanh.TenSanh = dr[2].ToString();
            frmSuaSanh.DgBan = dr[3].ToString();
            frmSuaSanh.SlBan = dr[4].ToString();
            frmSuaSanh.GhiChu = dr[5].ToString();
            frmSuaSanh.ShowDialog();
            try
            {
                sanhTable = objKetNoi.DocDuLieu("update sanh set masanh='" + frmSuaSanh.MaSanh + "', loaisanh= '" + frmSuaSanh.LoaiSanh + "', tensanh =N'" + frmSuaSanh.TenSanh + "', slbantoida'" + frmSuaSanh.SlBan+ "', dgbantoithieu='" +frmSuaSanh.DgBan+ "',tinhtrangsanh= N'"+frmSuaSanh.GhiChu+"'");
                CapNhatDataGridView();
            }
            catch
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sanhTable = objKetNoi.DocDuLieu("delete dattiec where dattiec.masanh= '" + dr[0].ToString() + "'");
                sanhTable = objKetNoi.DocDuLieu("delete sanh where masanh = '" + dr[0].ToString() + "'");
                // sanhTable = objKetNoi.DocDuLieu("delete chitietkh where chitietkh.matiec=dattiec.matiec");
                sanhTable = objKetNoi.DocDuLieu("delete tinhtrangsanh where masanh = '" + dr[0].ToString() + "'");
                CapNhatDataGridView();
            }
            else
            {
                CapNhatDataGridView();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
