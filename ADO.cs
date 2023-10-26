using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace FesTourTourisme
{
    class ADO
    {
        //ADO Elements

        public SqlConnection cn = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public DataTable dt = new DataTable();

        //ADO Methods
        public void Connecter()
        {
            if (cn.State==ConnectionState.Closed)
            {               
                cn.Open();
            }
        }

        public void DeConnecter()
        {
            if (cn.State==ConnectionState.Open)
            {
                cn.Close();
            }
        }

    }
}
