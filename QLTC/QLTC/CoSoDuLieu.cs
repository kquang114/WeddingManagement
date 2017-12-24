using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTC
{
    public class CoSoDuLieu
    {
        string strConn;
        SqlConnection conn;
        SqlDataAdapter da;

        public CoSoDuLieu(string chuoiKetNoi)
        {
            strConn = chuoiKetNoi;
        }

        public DataTable DocDuLieu(string strSql)
        {
            DataTable dt = new DataTable();
            conn = new SqlConnection(strConn);
            da = new SqlDataAdapter(strSql, conn);
            da.Fill(dt);
            conn.Dispose();
            return dt;
        }
        public void CapNhatDuLieu(DataTable dt, string strSql)
        {
            conn = new SqlConnection(strConn);
            da = new SqlDataAdapter(strSql, conn);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
            conn.Dispose();
        }
    }
}
