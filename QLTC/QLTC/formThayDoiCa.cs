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
    public partial class formThayDoiCa : Form
    {
        DataTable caTable;
        CoSoDuLieu objKetNoi;
        DataRow dr;
        string maCa;

        public string MaCa
        {
            get
            {
                return maCa;
            }

            set
            {
                maCa = value;
            }
        }

        public formThayDoiCa()
        {
            InitializeComponent();
            caTable = new DataTable();
        }

        public formThayDoiCa(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            caTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }

        void CapNhatDataGird()
        {
            caTable = objKetNoi.DocDuLieu("select * from loaica");
            dataGridView1.DataSource = caTable;
            dataGridView1.Columns[0].HeaderText = "mã ca";
            dataGridView1.Columns[1].HeaderText = "tên ca";
        }

        private void formThayDoiCa_Load(object sender, EventArgs e)
        {
            CapNhatDataGird();
            maCa = MaTuDong.MaTD(caTable, "MAX(maca)", 1);
        }

        void CapNhatDataRow()
        {
            dr[0] = txbTen.Text;
            dr[1] = txbGia.Text;
        }

        void ThemMotDong()
        {
            dr = caTable.NewRow();
            CapNhatDataRow();
            caTable.Rows.Add(dr);
            dataGridView1.DataSource = caTable;
        }

        void XuatThongTin()
        {
            txbTen.Text = dr[0].ToString();
            txbGia.Text = dr[1].ToString();
        }

        void CapNhatDuLieu(string chuoi)
        {
            string strSql = "SELECT * FROM loaica";
            objKetNoi.CapNhatDuLieu(caTable, strSql);
            MessageBox.Show(chuoi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemMotDong();
            CapNhatDuLieu("Thêm Thành Công");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CapNhatDataRow();
            DataTable dt = objKetNoi.DocDuLieu("update loaica set tenca =N'" + txbGia.Text + "' where maca ='" + dr[0].ToString() + "'");
            CapNhatDataGird();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CapNhatDataRow();
            caTable = objKetNoi.DocDuLieu("delete loaica where maca='" + dr[0].ToString() + "'");
            CapNhatDataGird();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dr = caTable.Rows[dataGridView1.CurrentRow.Index];
            XuatThongTin();
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            dr = caTable.Rows[dataGridView1.CurrentRow.Index];
            XuatThongTin();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }
    }
}
