using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTC
{
    public partial class FormMain : Form
    {
        CoSoDuLieu objKetNoi;
        string strConn;

        public FormMain()
        {
            InitializeComponent();
            strConn = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;
            objKetNoi = new CoSoDuLieu(strConn);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            formDangNhap frmDN = new formDangNhap(objKetNoi);
            frmDN.ShowDialog();
            btnDangNhap.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formPhieuDatTiec frmDT = new formPhieuDatTiec(objKetNoi);
            frmDT.ShowDialog();

        }

        private void danhSáchTiệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDanhSachKH frmDST = new formDanhSachKH(objKetNoi);
            frmDST.ShowDialog();
        }

        private void tiệcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDanhMucMonAn frmMA = new formDanhMucMonAn(objKetNoi);
            frmMA.ShowDialog();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void dịchVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDichVu frmDV = new formDichVu(objKetNoi);
            frmDV.ShowDialog();
        }

        private void danhSáchSảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDanhSachSanh frmDSS = new formDanhSachSanh(objKetNoi);
            frmDSS.ShowDialog();
        }

        private void loạiSảnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formLoaiSanh frmls = new formLoaiSanh(objKetNoi);
            frmls.ShowDialog();
        }

        private void thayĐổiCaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formThayDoiCa frmTDC = new formThayDoiCa(objKetNoi);
            frmTDC.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formLapHoaDon frmHD = new formLapHoaDon(objKetNoi);
            frmHD.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fromDoanhThu fDT = new fromDoanhThu(objKetNoi);
            fDT.ShowDialog();
        }
    }
}
