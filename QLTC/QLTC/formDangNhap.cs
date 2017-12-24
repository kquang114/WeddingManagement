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
    public partial class formDangNhap : Form
    {
        DataTable nguoiDungTable;
        CoSoDuLieu objKetNoi;
        string userName;

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public formDangNhap()
        {
            InitializeComponent();
            nguoiDungTable = new DataTable();
        }
        public formDangNhap(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            nguoiDungTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            nguoiDungTable = objKetNoi.DocDuLieu("select password from DANGNHAP where username ='" + txbTK.Text + "'");
            if (txbMK.Text == nguoiDungTable.Rows[0][0].ToString())
            {
                userName = txbTK.Text;
                MessageBox.Show("Đăng nhập thành công !", "Thông báo");
                Close();
            }
            else
            {
                MessageBox.Show("UserName hoặc Password không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
     
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}