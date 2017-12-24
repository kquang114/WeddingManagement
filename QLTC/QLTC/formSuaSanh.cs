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
    public partial class formSuaSanh : Form
    {
        DataTable dt;
        CoSoDuLieu objKetNoi;
        string maSanh;
        string loaiSanh;
        string tenSanh;
        string dgBan;
        string slBan;
        string ghiChu;

        public string MaSanh
        {
            get
            {
                return maSanh;
            }

            set
            {
                maSanh = value;
            }
        }

        public string LoaiSanh
        {
            get
            {
                return loaiSanh;
            }

            set
            {
                loaiSanh = value;
            }
        }

        public string TenSanh
        {
            get
            {
                return tenSanh;
            }

            set
            {
                tenSanh = value;
            }
        }

        public string DgBan
        {
            get
            {
                return dgBan;
            }

            set
            {
                dgBan = value;
            }
        }

        public string SlBan
        {
            get
            {
                return slBan;
            }

            set
            {
                slBan = value;
            }
        }

        public string GhiChu
        {
            get
            {
                return ghiChu;
            }

            set
            {
                ghiChu = value;
            }
        }

        public formSuaSanh()
        {
            InitializeComponent();
            dt = new DataTable();
        }
        public formSuaSanh(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            dt = new DataTable();
            this.objKetNoi = objKetNoi;
        }

        private void formSuaSanh_Load(object sender, EventArgs e)
        {
            txbMS.Text = maSanh;
            txbTenSanh.Text = tenSanh;
            cboLoai.Text = loaiSanh;
            txbSL.Text = slBan;
            txbDonGia.Text = DgBan;
            txbGhiChu.Text = ghiChu;
            CapNhatVaoComboboxLoaiSanh();
        }
        void CapNhatVaoComboboxLoaiSanh()
        {
            dt = objKetNoi.DocDuLieu("select loaisanh from loai");
            cboLoai.DataSource = dt;
            cboLoai.ValueMember = "loaisanh";
            cboLoai.DisplayMember = "loaisanh";
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            MaSanh = txbMS.Text;
            TenSanh = txbTenSanh.Text;
            LoaiSanh = cboLoai.Text;
            SlBan = txbSL.Text;
            DgBan = txbDonGia.Text;
            GhiChu = txbGhiChu.Text;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = objKetNoi.DocDuLieu("select dgbantoithieu from loai where loaisanh ='" + cboLoai.SelectedValue.ToString() + "'");
            txbDonGia.Text = dt.Rows[0][0].ToString();
        }
    }
}
