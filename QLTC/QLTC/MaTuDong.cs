using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTC
{
    class MaTuDong
    {
        public static string MaTD(DataTable table, string bieuThuc, int viTriSo)
        {
            string str = table.Compute(bieuThuc, "").ToString();
            string strLeft = str.Substring(0, viTriSo);
            int so = int.Parse(str.Substring(viTriSo));
            so++;
            return strLeft + String.Format("{0:0}", so);
        }
    }
}
