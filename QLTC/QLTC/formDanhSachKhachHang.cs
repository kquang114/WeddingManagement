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
    public partial class formDanhSachKH : Form
    {
        DataTable dtTable;
        CoSoDuLieu objKetNoi;
        DataRow dr;


        public formDanhSachKH()
        {
            InitializeComponent();
            dtTable = new DataTable();
        }

        public formDanhSachKH(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            dtTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }

        private void formDanhSachDatTiec_Load(object sender, EventArgs e)
        {
            dtpNgayDat.Value = DateTime.Now.Date;
           // CapNhatDataGridView();
            dtTable.Clear();
        }
       

        void CapNhatDataGridView()
        {           
            dtTable = objKetNoi.DocDuLieu("select dattiec.matiec,tencr,tencd,dt,cmnd,tenca,masanh from dattiec,tinhtrangsanh,loaica where dattiec.matiec = tinhtrangsanh.matiec and ngaydat = '" + dtpNgayDat.Value.Date + "' ");
            dgvDST.DataSource = dtTable;
            dgvDST.Columns[0].HeaderText = "mã tiệc";
            dgvDST.Columns[1].HeaderText = "Tên chú rễ";
            dgvDST.Columns[1].Width = 150;
            dgvDST.Columns[2].HeaderText = "Tên cô dâu";
            dgvDST.Columns[2].Width = 150;
            dgvDST.Columns[3].HeaderText = "điện thoại";
            dgvDST.Columns[4].HeaderText = "chứng minh nhân dân";
            dgvDST.Columns[5].HeaderText = "tenca";
            dgvDST.Columns[6].HeaderText = "mã sảnh";
            DataTable dt = objKetNoi.DocDuLieu("select count(matiec) from tinhtrangsanh where ngaydat = '" + dtpNgayDat.Value.Date + "' ");
            lblCur.Text = dt.Rows[0][0].ToString();
        }


        private void dgvDST_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // dr = dtTable.Rows[dgvDST.CurrentRow.Index];

        }

        private void dtpNgayDat_ValueChanged(object sender, EventArgs e)
        {
            
            CapNhatDataGridView();


        }
    }
}
