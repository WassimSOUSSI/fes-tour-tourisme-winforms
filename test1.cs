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
    public partial class test1 : Form
    {

        ADO obj = new ADO();

        int t;
        public void foncT(int k)
        {
            t = k;
        }


        public test1()
        {
            InitializeComponent();
        }
        double latitude_start;
        double longitude_ystart;

        private void test1_Load(object sender, EventArgs e)
        {
            obj.cn = new SqlConnection(@"Data Source=LAPTOP-DDRD5UOL;Initial Catalog=FTT;Integrated Security=True");

            obj.Connecter();


            ADO obj1 = new ADO();
            obj1.cmd = new SqlCommand("SELECT LatitDprt,LogitDprt FROM Depart WHERE IdDprt="+t+"",obj.cn);
            obj1.dr = obj1.cmd.ExecuteReader();
            obj1.dt.Load(obj1.dr);

            DataRow row = obj1.dt.Rows[0];

            latitude_start = double.Parse(row["LatitDprt"].ToString());
            longitude_ystart = double.Parse(row["LogitDprt"].ToString());

            /*Chargement De la map :*/
            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            map.SetPositionByKeywords("Fez, Morocco");

            /*Parametres Souris :*/
            map.DragButton = MouseButtons.Left;

            /*Initialisation de la map :*/

       
            double latutude_xend = 34.0435157;
            double longitude_yend = -4.9921345;
            PointLatLng point_start = new PointLatLng(latitude_start, longitude_ystart);
            PointLatLng point_end = new PointLatLng(latutude_xend, longitude_yend);
            map.ShowCenter = false;
            map.Zoom = 75;
            map.MinZoom = 5;
            map.MaxZoom = 100;



            /*Creation de marker :*/
            // Point Depart
            GMapOverlay markers1 = new GMapOverlay("markers");
            GMapMarker marker1 = new GMarkerGoogle(new PointLatLng(latitude_start, longitude_ystart), GMarkerGoogleType.blue_pushpin);
            markers1.Markers.Add(marker1);
            map.Overlays.Add(markers1);
            //Point finale
            GMapOverlay markers2 = new GMapOverlay("markers");
            GMapMarker marker2 = new GMarkerGoogle(new PointLatLng(latutude_xend, longitude_yend), GMarkerGoogleType.blue_pushpin);
            markers2.Markers.Add(marker2);
            map.Overlays.Add(markers2);


            /*Geolocalisation de deux points :*/
            List<PointLatLng> _point = new List<PointLatLng>();
            _point.Add(new PointLatLng(latitude_start, longitude_ystart));
            _point.Add(new PointLatLng(latutude_xend, longitude_yend));

            //Creer une instance d'une route
            MapRoute route = GMap.NET.MapProviders.GoogleMapProvider.Instance.GetRoute(point_start, point_end,false,true,15);

            //Affichage de la route
            GMapRoute r = new GMapRoute(_point,"route");//Convertion de la route en une ligne
            r.Stroke.Width = 5;
            r.Stroke.Color = Color.Black;
            GMapOverlay routesOverlay = new GMapOverlay("routes");//Affichage de la route dans la map
            routesOverlay.Routes.Add(r);
            map.ZoomAndCenterRoute(r);//Affichage de laroute au milieu
            map.Overlays.Add(routesOverlay);
            //Affichage de kilometrage et le prix
            double p = r.Distance * 6;
            getDistance.Text = "Distance :" +r.Distance+" km";
            prix.Text = "Le prix par Taxi :" + p + " DH";
           
        }

      

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
