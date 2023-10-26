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
    public partial class FrCnx : Form
    {
        ADO obj = new ADO();

        int x;

        private void FrCnx_Load(object sender, EventArgs e)
        {
            obj.cn = new SqlConnection(@"Data Source=LAPTOP-DDRD5UOL;Initial Catalog=FTT;Integrated Security=True");

            obj.Connecter();

            ADO obj1 = new ADO();
            obj1.cmd = new SqlCommand("SELECT * FROM Depart",obj.cn);
            obj1.dr = obj1.cmd.ExecuteReader();
            obj1.dt.Load(obj1.dr);

            comboBox1.DataSource = obj1.dt;
            comboBox1.DisplayMember = "NomDprt";
            comboBox1.ValueMember = "IdDprt";

            obj.DeConnecter();
        }


        public FrCnx()
        {
            InitializeComponent();
        }
        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void bunifuMaterialTextbox1_Click(object sender, EventArgs e)
        {
            label1.Hide();
        }

        private void bunifuMaterialTextbox2_Click(object sender, EventArgs e)
        {
            label2.Hide();
            txtMdp.isPassword = true;
        }

        private void bunifuMaterialTextbox3_Click(object sender, EventArgs e)
        {
            label3.Hide();
            txtConfirmMdp.isPassword = true;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            txtConfirmMdp.Visible = true;
            if (btnCreer.Text== "Greer")
            {
                btnCreer.Text = "Ajouter";
                label4.Visible = false;
                comboBox1.Visible = false;
            }
            else if(btnCreer.Text == "Ajouter")
            {
                btnCreer.Text = "Greer";
                label3.Visible = false;
                txtConfirmMdp.Visible = false;
                label4.Visible = true;
                comboBox1.Visible = true;
            }

            if (txtMdp.Text == txtConfirmMdp.Text && txtUsr.Text != "" && txtMdp.Text != "" && txtConfirmMdp.Text != "") 
            {
                ADO obj3 = new ADO();
                obj.Connecter();
                obj3.cmd = new SqlCommand("INSERT INTO Touriste (IdTouriste,MotDepasse) VALUES(" + txtUsr.Text + "," + txtMdp.Text + ")",obj.cn);
                obj3.cmd.ExecuteNonQuery();
                MessageBox.Show("Utilisateur ajoute");
            }
            else if (txtMdp.Text != txtConfirmMdp.Text)
            {
                MessageBox.Show("Mot de passe incorrect");
                label1.Visible = true;
                label2.Visible = true;
                txtUsr.Text = "";
                txtMdp.Text = "";
                txtConfirmMdp.Text = "";
            }
            else if ( txtUsr.Text == "" || txtMdp.Text == "" || txtConfirmMdp.Text == "")
            {
                MessageBox.Show("Saissir les Donnees");

            }
            
            

            obj.DeConnecter();
            
        }

        private void btnConnecter_Click(object sender, EventArgs e)
        {
            
            obj.Connecter();
            obj.cmd = new SqlCommand("SELECT IdTouriste, MotDepasse From Touriste",obj.cn);
            obj.dr = obj.cmd.ExecuteReader();
            obj.dt.Load(obj.dr);

            DataRow row;
            int p = 0;
            for (int i = 0; i < obj.dt.Rows.Count; i++)
            {
                row = obj.dt.Rows[i];
                if (txtUsr.Text==row["IdTouriste"].ToString() && txtMdp.Text== row["MotDepasse"].ToString())
                {
                    string nom = txtUsr.Text;

                    x = int.Parse(comboBox1.SelectedValue.ToString());
                    p = 1;
                    FrMain main = new FrMain();
                    main.Nom(nom);
                    main.fonc(x);
                    main.Show();
                    
                }
            }

            if (p==0)
            {
                MessageBox.Show("Donnees Incorrecte","Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            obj.DeConnecter();
        }

        
    }
}
