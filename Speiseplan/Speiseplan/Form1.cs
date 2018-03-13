using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Speiseplan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
       
        Random r;
        DatabaseAccess da = new DatabaseAccess();
        OleDbDataReader dr;
        internal List<Vorspeise> VorspeiseL = new List<Vorspeise>();
        internal List<Hauptspeise> HauptspeiseL = new List<Hauptspeise>();
        internal List<Nachspeise> NachspeiseL = new List<Nachspeise>();
        string cn = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Speiseplan.accdb";
        OleDbConnection conn;

        OleDbCommand cmd;
        string sql;
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
            r = new Random();
            readVorspeiseintoList();
            PlanungV();
            readHauptspeiseintoList();
            PlanungH();
            readNachspeiseintoList();
            PlanungN();




        }
 internal void readVorspeiseintoList()
        {
            VorspeiseL = new List<Vorspeise>();
            dr = da.readData("Select * from Vorspeise");
            while (dr.Read())
            {
                VorspeiseL.Add(new Vorspeise(Convert.ToInt32(dr[0]), dr[1].ToString()));

            }
        }

        internal void PlanungV()
        {
            conn = new OleDbConnection(cn);
            conn.Open();
            sql = "SELECT * FROM Vorspeise";
            cmd = new OleDbCommand(sql, conn);
            dr = cmd.ExecuteReader();

           


           
            int b = 0;
          

                int j = 1;

                     for (int i = 1; i < 8; i++)
                    {
                       
              
                        
                 
                         int z = r.Next(0, 8);

                            Label lb = new Label();
                            lb.Name = b.ToString();
                            lb.Text = VorspeiseL[z].VName.ToString();
                            tableLayoutPanel1.Controls.Add(lb, i, j);
                            lb.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
                            b++;                    

            }
        }
  internal void readHauptspeiseintoList()
        {
            HauptspeiseL = new List<Hauptspeise>();
            dr = da.readData("Select * from Hauptspeise");
            while (dr.Read())
            {
                HauptspeiseL.Add(new Hauptspeise(Convert.ToInt32(dr[0]), dr[1].ToString()));

            }
        }
        internal void PlanungH()
        {
            conn = new OleDbConnection(cn);
            conn.Open();
            sql = "SELECT * FROM Hauptspeise";
            cmd = new OleDbCommand(sql, conn);
            dr = cmd.ExecuteReader();





            int b = 0;


            int j = 2;

            for (int i = 1; i < 8; i++)
            {




                int z = r.Next(0, 8);

                Label lb = new Label();
                lb.Name = b.ToString();
                lb.Text = HauptspeiseL[z].HName.ToString();
                tableLayoutPanel1.Controls.Add(lb, i, j);
                lb.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
                b++;

            }
        }



       
  internal void readNachspeiseintoList()
        {
            NachspeiseL = new List<Nachspeise>();
            dr = da.readData("Select * from Nachspeise");
            while (dr.Read())
            {
                NachspeiseL.Add(new Nachspeise(Convert.ToInt32(dr[0]), dr[1].ToString()));

            }
        }
      


        internal void PlanungN()
        {
            conn = new OleDbConnection(cn);
            conn.Open();
            sql = "SELECT * FROM Nachspeise";
            cmd = new OleDbCommand(sql, conn);
            dr = cmd.ExecuteReader();





            int b = 0;


            int j = 3;

            for (int i = 1; i < 8; i++)
            {




                int z = r.Next(0, 8);

                Label lb = new Label();
                lb.Name = b.ToString();
                lb.Text = NachspeiseL[z].NName.ToString();
                tableLayoutPanel1.Controls.Add(lb, i, j);
                lb.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
                b++;

            }
        }

        private void vorspeisenListeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Text = "VorspeiseListe";
            f2.ShowDialog();
        }

        private void hauptspeisenListeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Text = "HauptspeiseListe";
            f2.ShowDialog();
        }

        private void nachspeisenListeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Text = "NachspeiseListe";
            f2.ShowDialog();
        }
    }
}
