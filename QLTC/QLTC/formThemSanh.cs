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
    public partial class formThemSanh : Form
    {
        DataTable sanhTable;
        CoSoDuLieu objKetNoi;

        string masanh;

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

        public formThemSanh()
        {
            InitializeComponent();
            sanhTable = new DataTable();
        }
        public formThemSanh(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            sanhTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }


        private void formThemSanh_Load(object sender, EventArgs e)
        {
            sanhTable = objKetNoi.DocDuLieu("select * from sanh,loai");
            masanh = MaTuDong.MaTD(sanhTable, "max(masanh)", 2);
            CapNhatVaoComboboxLoaiSanh();
        }

        void CapNhatVaoComboboxLoaiSanh()
        {
            sanhTable = objKetNoi.DocDuLieu("select loaisanh from loai");
            cboLoai.DataSource = sanhTable;
            cboLoai.ValueMember = "loaisanh";
            cboLoai.DisplayMember = "loaisanh";         
        }


        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = objKetNoi.DocDuLieu("select dgbantoithieu from loai where loaisanh ='" + cboLoai.SelectedValue.ToString() + "'");
            txbDonGia.Text = dt.Rows[0][0].ToString();
            /*if (cboLoai.Text == "A")
            {
                txbDonGia.Text = "1000000";
            }
            else if (cboLoai.Text == "B")
                txbDonGia.Text = "1100000";
            else if (cboLoai.Text == "C")
                txbDonGia.Text = "1200000";
            else if (cboLoai.Text == "D")
                txbDonGia.Text = "1400000";
            else
                txbDonGia.Text = "1600000";*/
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            DataTable dt = objKetNoi.DocDuLieu("insert into sanh(masanh,loaisanh,tensanh,slbantoida,tinhtrang) values ('" + txbMS.Text + "','" + cboLoai.Text + "',N'" + txbTenSanh.Text + "','" + txbSL.Text + "','" + txbGhiChu.Text + "')");
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
