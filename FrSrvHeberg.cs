using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace FesTourTourisme
{
    public partial class FrSrvHeberg : Form
    {
        ADO obj = new ADO();

        int t;
        public void foncH(int k)
        {
            t = k;
        }
        public FrSrvHeberg()
        {
            InitializeComponent();
        }

        private void FrSrvHeberg_Load(object sender, EventArgs e)
        {
            obj.cn = new SqlConnection(@"Data Source=LAPTOP-DDRD5UOL;Initial Catalog=FTT;Integrated Security=True");
            obj.Connecter();

            ADO obj1 = new ADO();
            obj1.cmd = new SqlCommand("SELECT IdHotel,NomHotel,TelHotel,EtoileHotel,AdressHotel FROM Hotel", obj.cn);

            obj1.dr = obj1.cmd.ExecuteReader();
            obj1.dt.Load(obj1.dr);
            bunifuCustomDataGrid1.DataSource = obj1.dt;
            bunifuCustomDataGrid1.Refresh();

            obj.DeConnecter();

        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (pictureBox1.Visible==true)
            {
                pictureBox1.Visible = false;
            }
            else
            {
                pictureBox1.Visible = true;
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            test1 test = new test1();
            test.foncT(t);
            test.Show();
        }
    }
}
