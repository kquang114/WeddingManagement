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
    public partial class formDanhMucMonAn : Form
    {
        DataTable monAnTable;
        CoSoDuLieu objKetNoi;
        string maMA;
        DataRow dr;
        
        public string MaMA
        {
            get
            {
                return maMA;
            }

            set
            {
                maMA = value;
            }
        }

        public formDanhMucMonAn()
        {
            InitializeComponent();
            monAnTable = new DataTable();
        }
        public formDanhMucMonAn(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            monAnTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }


        private void formDanhMucMonAn_Load(object sender, EventArgs e)
        {
            CapNhatDataGridView();
            maMA = MaTuDong.MaTD(monAnTable, "MAX(mama)", 2);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lblCur.Text == lbl100.Text)
            {
                MessageBox.Show("Đã đạt đủ số lượng món ăn", "Thông Báo!", MessageBoxButtons.OK);
            }
            //DataTable dt = objKetNoi.DocDuLieu("insert into monan(mama,tenma,donvitinh,dongiama) values ('" +maMA+"','" + txbTen.Text + "','" + cboDvTinh.Text + "','" + txbDonGia.Text + "')");
            //dgvMonAn.DataSource = dt;
           else
            {
                ThemMotDong();
                RefreshText();
                CapNhatDuLieu("Cập nhật thành công");
                CapNhatDataGridView();
            }
        }

        void CapNhatDuLieu(string chuoi)
        {
            string strSql = "SELECT * FROM MONAN";
            objKetNoi.CapNhatDuLieu(monAnTable, strSql);
            MessageBox.Show(chuoi);
        }

        void CapNhatDataRow()
        {
            dr[0] = txbMa.Text;
            dr[1] = txbTen.Text;
            dr[2] = cboDvTinh.Text;
            dr[3] = txbDonGia.Text;
        }

        void ThemMotDong()
        {
            dr = monAnTable.NewRow();
            CapNhatDataRow();          
            monAnTable.Rows.Add(dr);
            dgvMonAn.DataSource = monAnTable;
        }

        void CapNhatDataGridView()
        {
            monAnTable = objKetNoi.DocDuLieu("select * from monan ");
            dgvMonAn.DataSource = monAnTable;
            dgvMonAn.Columns[0].HeaderText = "Mã Món Ăn";
            dgvMonAn.Columns[1].HeaderText = "Tên Món Ăn";
            dgvMonAn.Columns[2].HeaderText = "Đơn vị tính";
            dgvMonAn.Columns[3].HeaderText = "Đơn giá";
            DataTable dt = objKetNoi.DocDuLieu("select count(mama) from monan");
            lblCur.Text = dt.Rows[0][0].ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không? ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                monAnTable = objKetNoi.DocDuLieu("delete monan where mama = '" + dr[0].ToString() + "'");
                //monAnTable = objKetNoi.DocDuLieu("delete chitietma where mama = '" + dr[0].ToString() + "'");
                CapNhatDataGridView();
              
            }
        }

        private void dgvMonAn_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dr = monAnTable.Rows[dgvMonAn.CurrentRow.Index];
            XuatThongTin();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }
        void RefreshText()
        {
            txbMa.Text = "";
            txbTen.Text = "";
            txbDonGia.Text = "";
            cboDvTinh.Text = "";
        }

        void XuatThongTin()
        {
            txbMa.Text = dr[0].ToString();
            txbTen.Text = dr[1].ToString();
            cboDvTinh.Text = dr[2].ToString();
            txbDonGia.Text = dr[3].ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            CapNhatDataRow();
            monAnTable = objKetNoi.DocDuLieu("update monan set tenma= N'" + txbTen.Text + "', donvitinh ='" + cboDvTinh.Text + "', dongiama ='" + txbDonGia.Text + "' where mama = '"+txbMa.Text+"'");
            // DataTable dt = objKetNoi.DocDuLieu("select * from monan");
            //dgvMonAn.DataSource = dt;
            CapNhatDataGridView();
        }

        private void dgvMonAn_KeyUp(object sender, KeyEventArgs e)
        {
            dr = monAnTable.Rows[dgvMonAn.CurrentRow.Index];
            XuatThongTin();
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {

        }


    }
}
