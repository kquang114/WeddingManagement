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
    public partial class formHDThem : Form
    {

        DataTable hdTable;
        DataTable khTable;
        CoSoDuLieu objKetNoi;
        string maHD;
        int[] tienBan;
        int[] soluongBan;
        int[] soluongDV;
        int[] giatienDV;
        int tongTienBan;
        int tongTienDV;
        int hieuso;

        public formHDThem()
        {
            InitializeComponent();
            hdTable = new DataTable();
            khTable = new DataTable();
        }
        public formHDThem(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            hdTable = new DataTable();
            khTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }


        private void btnDongY_Click(object sender, EventArgs e)
        {
            khTable = objKetNoi.DocDuLieu("insert into hoadon(mahd,matiec,ngaytt,tongtienban,tongtiendv,tongtienhd) values ('" + maHD + "','" + cboMT.SelectedValue.ToString() + "','" + dtpkNgayTT.Value.Date + "','" + lblTienBan.Text + "','" + lblTienDV.Text + "','" + lblTongTien.Text + "')");
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnXemHD_Click(object sender, EventArgs e)
        {
            //DataTable dt = objKetNoi.DocDuLieu("select tongtien ,datediff(day,@ngaydat,@ngaytt)");
            // DataTable dt1 = objKetNoi.DocDuLieu("select datediff(d,ngaytt,ngaydat)  from tinhtrangsanh,hoadon where tinhtrangsanh.matiec in (select matiec from dattiec where matiec ='"+cboMT.SelectedValue.ToString()+"' )");
            DataTable dt1 = objKetNoi.DocDuLieu("select day('" + dtpkNgayDat.Value + "')");
            DataTable dt2 = objKetNoi.DocDuLieu("select day('" + dtpkNgayTT.Value + "')");
            int a = int.Parse(dt1.Rows[0][0].ToString());
            int b = int.Parse(dt2.Rows[0][0].ToString());
            if (b > a)
            {
                hieuso = b - a;
            }
            else
            {
                hieuso = 1;
            }

            lblHS.Text = hieuso.ToString();
            DataTable dt = objKetNoi.DocDuLieu("select count(mama) from chitietma where matiec = (select matiec from dattiec where matiec = '" + cboMT.SelectedValue.ToString() + "')");
            int max = int.Parse(dt.Rows[0][0].ToString());
            DataTable tienban = objKetNoi.DocDuLieu("select dongiama from monan where mama in (select mama from chitietma where matiec = (select matiec from dattiec where matiec = '" + cboMT.SelectedValue.ToString() + "'))");
            
            DataTable soluongban = objKetNoi.DocDuLieu("select SoLuongMA from chitietma where matiec in (select matiec from dattiec where matiec = '" + cboMT.SelectedValue.ToString() + "')");
            tienBan = new int[max];
            soluongBan= new int[max];
                for (int i = 0; i < max; i++)
                {

                    tienBan[i] = int.Parse(tienban.Rows[i][0].ToString());
                    soluongBan[i] = int.Parse(soluongban.Rows[i][0].ToString());
                    tongTienBan += (soluongBan[i] * tienBan[i]);
                }

            DataTable tienDV = objKetNoi.DocDuLieu("select dongiadv from dichvu where madv in (select madv from chitietdv where matiec = (select matiec from dattiec where matiec = '" + cboMT.SelectedValue.ToString() + "'))");
            DataTable soluongdv = objKetNoi.DocDuLieu("select soluongdv from chitietdv where matiec in ( select matiec from dattiec where matiec = '" + cboMT.SelectedValue.ToString() + "')");

            DataTable dtdv = objKetNoi.DocDuLieu("select count(madv) from chitietdv where matiec = (select matiec from dattiec where matiec ='" + cboMT.SelectedValue.ToString() + "')");
            int maxdv = int.Parse(dtdv.Rows[0][0].ToString());
            giatienDV = new int[maxdv];
            soluongDV = new int[maxdv];
            for(int i = 0; i < maxdv; i++)
            {
                giatienDV[i] = int.Parse(tienDV.Rows[i][0].ToString());
                soluongDV[i] = int.Parse(soluongdv.Rows[i][0].ToString());
                tongTienDV += (soluongDV[i] * giatienDV[i]);
            }
          

            lblTienBan.Text = tongTienBan.ToString();
            lblTienDV.Text = tongTienDV.ToString();
            lblTongTien.Text = ((tongTienBan + tongTienDV) + (tongTienBan + tongTienDV)*(hieuso*0.01)).ToString();
        }

        private void dtpkNgayDat_ValueChanged(object sender, EventArgs e)
        {
            khTable = objKetNoi.DocDuLieu("select matiec from dattiec where matiec in (select matiec from tinhtrangsanh where ngayDat='" + dtpkNgayDat.Value + "')");
            cboMT.DataSource = khTable;
            cboMT.ValueMember = "matiec";
            cboMT.DisplayMember = "matiec";
        }

        private void formHDThem_Load_1(object sender, EventArgs e)
        {
            dtpkNgayTT.Value = DateTime.Now.Date;
            hdTable = objKetNoi.DocDuLieu("select mahd from hoadon");
            maHD = MaTuDong.MaTD(hdTable, "max(mahd)", 2);
        }
    }
}
