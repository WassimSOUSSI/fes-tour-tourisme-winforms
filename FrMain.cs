using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System.Data;
using System.Data.SqlClient;


namespace FesTourTourisme
{
    public partial class FrMain : Form
    {
        ADO obj = new ADO();
        string b;
        public void Nom(string a)
        {
             b= a;
        }

        int t;
        public void fonc(int k)
        {
            t = k;
        }
        public FrMain()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void FrMain_Load(object sender, EventArgs e)
        {
            obj.cn = new SqlConnection(@"Data Source=LAPTOP-DDRD5UOL;Initial Catalog=FTT;Integrated Security=True");
            lblNom.Text = b;
            
        }


        public void customizeDesing()
        {
            PnlSubMenu1.Visible = false;
            PnlSubMenu2.Visible = false;
            PnlSubMenu3.Visible = false;
            PnlSubMenu4.Visible = false;
            PnlSubMenu5.Visible = false;
        }

        public void hideSubMenu()
        {
            if (PnlSubMenu1.Visible==true)
            {
                PnlSubMenu1.Visible = false;
                
            }
        }

        public void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(PnlSubMenu1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            showSubMenu(PnlSubMenu2);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(PnlSubMenu3);
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSrvTrns_Click(object sender, EventArgs e)
        {
            showSubMenu(PnlSubMenu4);
        }

        private void btnSrvTour_Click(object sender, EventArgs e)
        {
            showSubMenu(PnlSubMenu5);
        }

 

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            
            //----Chargemment de la map
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;           
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            
            //----Initialisation de la map
            map.SetPositionByKeywords("Fez,Morocco");
            PointLatLng point = new PointLatLng(34.0371500, -4.9998000);
            map.Zoom = 10;
            map.MinZoom = 2;
            map.MaxZoom = 100;
            map.DragButton = MouseButtons.Left;
            map.ShowCenter = false;

            //----Les markers
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_pushpin);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);

        }

        private void btnHotel_Click(object sender, EventArgs e)
        {
            map.Visible = false;
            FrSrvHeberg frSrv = new FrSrvHeberg();
            frSrv.foncH(t);
            frSrv.MdiParent = this;
            frSrv.Dock = DockStyle.Fill;
            frSrv.Show();

        }
    }
}
