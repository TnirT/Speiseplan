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
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Globalization;
using System.Collections;


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
       // private List<Wert> werte;
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
                            //wert.Add(b);

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

        private void druckenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drucken();
        }

        private void drucken()
        {
            Microsoft.Office.Interop.Word.Application wordapp = new Microsoft.Office.Interop.Word.Application();
            if (wordapp == null)
            {
                MessageBox.Show("Es konnte keine Verbindung zu Word hergestellt werden!");
                return;
            }

            wordapp.Visible = true;
           
            try
            {
               
                wordapp.Documents.Open(System.Windows.Forms.Application.StartupPath + "\\Speiseplan.docx");
                wordapp.ActiveDocument.FormFields["Text1"].Result = VorspeiseL[0].VName.ToString();
                 wordapp.ActiveDocument.FormFields["Text2"].Result = VorspeiseL[1].VName.ToString();
                wordapp.ActiveDocument.FormFields["Text3"].Result = VorspeiseL[2].VName.ToString();
                wordapp.ActiveDocument.FormFields["Text4"].Result = VorspeiseL[3].VName.ToString();
                wordapp.ActiveDocument.FormFields["Text5"].Result = VorspeiseL[4].VName.ToString();
                wordapp.ActiveDocument.FormFields["Text6"].Result = VorspeiseL[5].VName.ToString();
                wordapp.ActiveDocument.FormFields["Text7"].Result = VorspeiseL[6].VName.ToString();
                wordapp.ActiveDocument.FormFields["Text8"].Result = HauptspeiseL[0].HName.ToString();
               wordapp.ActiveDocument.FormFields["Text9"].Result = HauptspeiseL[1].HName.ToString();
               wordapp.ActiveDocument.FormFields["Text10"].Result =HauptspeiseL[2].HName.ToString();
                wordapp.ActiveDocument.FormFields["Text11"].Result =HauptspeiseL[3].HName.ToString();
                wordapp.ActiveDocument.FormFields["Text12"].Result =HauptspeiseL[4].HName.ToString();
                wordapp.ActiveDocument.FormFields["Text13"].Result =HauptspeiseL[5].HName.ToString();
                wordapp.ActiveDocument.FormFields["Text14"].Result =HauptspeiseL[6].HName.ToString();
                wordapp.ActiveDocument.FormFields["Text15"].Result = NachspeiseL[0].NName.ToString();
                wordapp.ActiveDocument.FormFields["Text16"].Result = NachspeiseL[1].NName.ToString();
                wordapp.ActiveDocument.FormFields["Text17"].Result = NachspeiseL[2].NName.ToString();
                wordapp.ActiveDocument.FormFields["Text18"].Result = NachspeiseL[3].NName.ToString();
                wordapp.ActiveDocument.FormFields["Text19"].Result = NachspeiseL[4].NName.ToString();
                wordapp.ActiveDocument.FormFields["Text20"].Result = NachspeiseL[5].NName.ToString();
                wordapp.ActiveDocument.FormFields["Text21"].Result = NachspeiseL[6].NName.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
