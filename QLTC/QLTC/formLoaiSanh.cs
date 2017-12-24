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
    public partial class formLoaiSanh : Form
    {

        DataTable sanhTable;
        CoSoDuLieu objKetNoi;
        DataRow dr;

        public formLoaiSanh()
        {
            InitializeComponent();
            sanhTable = new DataTable();
        }

        public formLoaiSanh(CoSoDuLieu objKetNoi)
        {
            InitializeComponent();
            sanhTable = new DataTable();
            this.objKetNoi = objKetNoi;
        }

        void ThemMotDong()
        {
            dr = sanhTable.NewRow();
            CapNhatDataRow();
            sanhTable.Rows.Add(dr);
            dataGridView1.DataSource = sanhTable;
        }

        void CapNhatDuLieu(string chuoi)
        {
            string strSql = "SELECT * FROM Loai";
            objKetNoi.CapNhatDuLieu(sanhTable, strSql);
            MessageBox.Show(chuoi);
        }

        void CapNhatDataRow()
        {
            dr[0] = txbTen.Text;
            dr[1] = txbGia.Text;
        }
        void CapNhatDataGridView()
        {
            sanhTable = objKetNoi.DocDuLieu("select * from loai");
            dataGridView1.DataSource = sanhTable;
            dataGridView1.Columns[0].HeaderText = "tên loại sảnh";
            dataGridView1.Columns[1].HeaderText = "đơn giá tối thiểu";
        }

        private void formLoaiSanh_Load(object sender, EventArgs e)
        {           
            CapNhatDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemMotDong();
            CapNhatDuLieu("Thêm Thành Công ");
            //sanhTable = objKetNoi.DocDuLieu("insert into loai(loaisanh,dgbantoithieu) values ('" + txbTen.Text + "','" + txbGia.Text + "')");
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CapNhatDataRow();
            DataTable dt = objKetNoi.DocDuLieu("update loai set dgbantoithieu='" + txbGia.Text + "' where  loaisanh='" + dr[0].ToString() + "'");
            CapNhatDataGridView();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               sanhTable= objKetNoi.DocDuLieu("delete loai where loaisanh = '" +txbTen.Text+ "'");
                CapNhatDataGridView();
            }
        }
        void XuatThongTin()
        {
            txbTen.Text = dr[0].ToString();
            txbGia.Text = dr[1].ToString();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dr = sanhTable.Rows[dataGridView1.CurrentRow.Index];
            XuatThongTin();
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            dr = sanhTable.Rows[dataGridView1.CurrentRow.Index];
            XuatThongTin();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
        }
     
    }
}
