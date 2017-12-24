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
    public partial class formPhieuDatTiec : Form
    {
        DataTable pdtTable;
        DataTable khTable;
        DataTable monanTable;
        DataTable dichvuTable;
        CoSoDuLieu objKetNoi;

        string maPDT;

        public formPhieuDatTiec()
        {
            InitializeComponent();
            pdtTable = new DataTable();
            khTable = new DataTable();
            monanTable = new DataTable();
            dichvuTable = new DataTable();
        }
        public formPhieuDatTiec(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            pdtTable = new DataTable();
            khTable = new DataTable();
            monanTable = new DataTable();
            dichvuTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }

        private void formPhieuDatTiec_Load(object sender, EventArgs e)
        {
            CapNhatDuLieuVaoComboboxTenDichVu();
            CapNhatDuLieuVaoComboboxMonAn();
            CapNhatDuLieuVaoDataGridView();
            CapNhatDuLieuVaoDataGridView1();
            CapNhatDataDatTiec();
            ComboboxMS();
            comboboxCa();
            pdtTable = objKetNoi.DocDuLieu("select matiec from dattiec ");
            maPDT = MaTuDong.MaTD(pdtTable, "max(matiec)", 1);
        }

        void CapNhatDuLieuVaoComboboxTenDichVu()
        {
            dichvuTable = objKetNoi.DocDuLieu("select madv , tendv from dichvu");
            cboDichVu.DataSource = dichvuTable;
            cboDichVu.ValueMember = "madv";
            cboDichVu.DisplayMember = "tendv";
        }

        void CapNhatDuLieuVaoComboboxMonAn()
        {
            monanTable = objKetNoi.DocDuLieu("select donvitinh,mama,tenma from monan");
            cboTenMonAn.DataSource = monanTable;
            cboTenMonAn.ValueMember = "mama";
            cboTenMonAn.DisplayMember = "tenma";
        }
        void ComboboxMS()
        {
            DataTable dt = objKetNoi.DocDuLieu("select masanh from sanh");
            cboMS.DataSource = dt;
            cboMS.ValueMember = "masanh";
        }

        void comboboxCa()
        {
            DataTable dt = objKetNoi.DocDuLieu("select maca,tenca from loaica  ");
            cboCa.DataSource = dt;
            cboCa.ValueMember = "maca";
            cboCa.DisplayMember = "tenca";
        }
        /*void CapNhatDuLieuVaoComboboxDonVi()
        {
            monanTable = objKetNoi.DocDuLieu("select donvitinh from monan");
            cboDonVi.DataSource = monanTable;
            cboDonVi.DisplayMember = "donvitinh";
        }*/

        void CapNhatDataDatTiec()
        {
            pdtTable = objKetNoi.DocDuLieu("select tencr,tencd,dt,cmnd,tiencoc,slban,sobandutru from dattiec where matiec ='" + maPDT + "'");
            dtgvDT.DataSource = pdtTable;
            dtgvDT.Columns[0].HeaderText = "Tên chú rễ";
            dtgvDT.Columns[1].HeaderText = "Tên cô dâu";
            dtgvDT.Columns[2].HeaderText = "điện thoại";
            dtgvDT.Columns[3].HeaderText = "Chứng minh thư";
            dtgvDT.Columns[4].HeaderText = "tiền cọc";
            dtgvDT.Columns[5].HeaderText = "số lượng bàn";
            dtgvDT.Columns[6].HeaderText = "số bàn dự trữ";

        }

        void CapNhatDuLieuVaoDataGridView()
        {
            monanTable = objKetNoi.DocDuLieu("select tenma,donvitinh,soluongma,dongiama from chitietma,monan where matiec = '"+maPDT+"' and monan.mama=chitietma.mama ");
            dataGridView1.DataSource = monanTable;
            dataGridView1.Columns[0].HeaderText = "Tên món ăn";
            dataGridView1.Columns[1].HeaderText = "Đơn vị tính";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Đơn giá món ";
        }

        void CapNhatDuLieuVaoDataGridView1()
        {
            dichvuTable = objKetNoi.DocDuLieu("select tendv,soluongdv,dongiadv from chitietdv,dichvu where matiec ='"+maPDT+"' and dichvu.madv=chitietdv.madv");
            dataGridView2.DataSource = dichvuTable;
            dataGridView2.Columns[0].HeaderText = "Tên dịch vụ ";
            dataGridView2.Columns[1].HeaderText = "số lượng dv";
            dataGridView2.Columns[2].HeaderText = "đơn giá dv";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            monanTable = objKetNoi.DocDuLieu("insert into chitietma(matiec,mama,soluongma) values ('" + maPDT + "','" + cboTenMonAn.SelectedValue.ToString() + "','" + nudSoLuongMA.Value.ToString() + "')");
            dichvuTable = objKetNoi.DocDuLieu("insert into chitietdv(matiec,madv,soluongdv) values('" + maPDT + "','" + cboDichVu.SelectedValue.ToString() + "','" + txbDgDV.Text + "')");
            CapNhatDuLieuVaoDataGridView();
            CapNhatDuLieuVaoDataGridView1();
        }



        private void btnSua_Click(object sender, EventArgs e)
        {
            cboDichVu.Enabled = true;
            cboTenMonAn.Enabled = true;
            btnThem.Enabled = true;
            DataTable dt = objKetNoi.DocDuLieu("update chitietma set mama='" + cboTenMonAn.SelectedValue.ToString() + "',soluongma='" + nudSoLuongMA.Value.ToString() + "',tongtienma='" + txbDonGiaMA.Text + "'");
            DataTable dt1 = objKetNoi.DocDuLieu("update chitietdv set madv='" + cboDichVu.SelectedValue.ToString() + "',soluongdv='" + nudSoLuongDV.Value.ToString() + "',tongtiendv='" + txbDgDV.Text + "'");
            CapNhatDuLieuVaoDataGridView();
            CapNhatDuLieuVaoDataGridView1();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable dt = objKetNoi.DocDuLieu("delete chitietma where matiec='" + maPDT + "' and mama ='" + cboTenMonAn.SelectedValue.ToString() + "'");
                DataTable dt1 = objKetNoi.DocDuLieu("delete chitietdv where matiec='" + maPDT + "' and mama ='" + cboDichVu.SelectedValue.ToString() + "'");
                CapNhatDuLieuVaoDataGridView();
                CapNhatDuLieuVaoDataGridView1();
            }
            cboDichVu.Enabled = true;
            cboTenMonAn.Enabled = true;
            btnThem.Enabled = true;
        }

        private void btnLapPKB_Click(object sender, EventArgs e)
        {
            pdtTable = objKetNoi.DocDuLieu("insert into dattiec(matiec,tencr,tencd,dt,cmnd,tiencoc,slban,sobandutru) values ('" + maPDT + "','" + txbTenCr.Text + "','" + txbTenCd.Text + "','" + txbDT.Text + "', '" + txbCMND.Text + "','" + txbTienCoc.Text + "','" + txbSLB.Text + "','" + txbSBDT.Text + "')");
            
            DataTable dt = objKetNoi.DocDuLieu("insert into tinhtrangsanh(masanh,maca,ngaydat,tinhtrang,matiec) values ('" + cboMS.SelectedValue.ToString() + "','" + cboCa.SelectedValue.ToString() + "','" + dpNgayDat.Value.Date + "','" + lblTinhTrang.Text + "','"+maPDT+"')");
            CapNhatDataDatTiec();
        }
    }
}
