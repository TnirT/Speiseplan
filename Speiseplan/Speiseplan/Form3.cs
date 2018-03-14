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
    public partial class Form3 : Form
    {
        internal static Form3 f3;
        public Form3()
        {
            f3 = this;
            InitializeComponent();
        }
        string cn = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Speiseplan.accdb";
        OleDbConnection conn;
        DatabaseAccess da;
        OleDbDataReader dr;
        OleDbCommand cmd;
        internal long pid;
        Form2 f2 = new Form2();
        int test = 1;
        string sql;

        //internal List<Vorspeise> VorspeiseL = new List<Vorspeise>();
        //internal List<Hauptspeise> HauptspeiseL = new List<Hauptspeise>();
        //internal List<Nachspeise> NachspeiseL = new List<Nachspeise>();
        private void Form3_Load(object sender, EventArgs e)
        {
            f2.ReadIntoListView();
            da = new DatabaseAccess();
            

            if (this.Text.Equals("neu anlegen"))
            {
                lbID.Visible = false;
                txtID.Visible = false;
            }

            //Bearbeiten
           else
            {
                
               for (int i = 0; i < f2.VorspeiseL.Count; i++)
                {
                    MessageBox.Show("hallo");
                    if (pid == f2.VorspeiseL[i].VID)
                    {
                        MessageBox.Show("hallo");
                            txtID.Text = f2.VorspeiseL[i].VID.ToString();
                            txtN.Text = f2.VorspeiseL[i].VName;

                    }
              }
                

           }
        }

        private void speichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtN.Text.Equals(""))
            {
                MessageBox.Show("Bitte geben Sie den Namen ein!");
                return;
            }

            if (this.Text.Equals("neu anlegen"))
            {
                // In Tabelle einfügen
                sql = "Insert into Vorspeise (VName) values (?)";
                cmd = new OleDbCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add(new OleDbParameter("VName", txtN.Text));
               
                da.executeQuery(cmd);

               
                sql = "Select Max(VID) from Vorspeise;";
                long pid = da.executeScalar(sql);


                MessageBox.Show("erfolgreich angelegt!");

            }
            else  //Bearbeiten
            {

                sql = "Update Vorspeise set VName = ?";
                cmd = new OleDbCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add(new OleDbParameter("VName", txtN.Text));
               
                da.executeQuery(cmd);



                MessageBox.Show("Das Produkt wurde erfolgreich bearbeitet!");

            }
            MessageBox.Show("Nach neu einlesen!");
            this.Close();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
