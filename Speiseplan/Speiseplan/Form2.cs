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
    public partial class Form2 : Form
    {
        internal static Form2 f2;
        public Form2()
        {
            f2 = this;
            InitializeComponent();

        }

        DatabaseAccess da = new DatabaseAccess();
        OleDbDataReader dr;

        Form1 f1 = new Form1();
        OleDbCommand cmd;
        string sql;
        ListViewItem lvItem;

        internal List<Vorspeise> VorspeiseL = new List<Vorspeise>();
        internal List<Hauptspeise> HauptspeiseL=new List<Hauptspeise>();
        internal List<Nachspeise> NachspeiseL = new List<Nachspeise>();

        string cn = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Speiseplan.accdb";
        OleDbConnection conn;

      
       
        private void Form2_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;

            if (this.Text.Equals("VorspeiseListe"))
            {
                conn = new OleDbConnection(cn);
               
                conn.Open();
                sql = "SELECT * FROM Vorspeise";
                cmd = new OleDbCommand(sql, conn);
             
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lvItem = new ListViewItem(dr[0].ToString());
                    lvItem.SubItems.Add(dr[1].ToString());               
                    listView1.Items.Add(lvItem);

                    VorspeiseL.Add(new Vorspeise(Convert.ToInt64(dr[0].ToString()), (dr[1].ToString())));
                }
                conn.Close();
            }

           else if (this.Text.Equals("HauptspeiseListe"))
            {
                conn = new OleDbConnection(cn);

                conn.Open();
                sql = "SELECT * FROM Hauptspeise";
                cmd = new OleDbCommand(sql, conn);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lvItem = new ListViewItem(dr[0].ToString());
                    lvItem.SubItems.Add(dr[1].ToString());
                    listView1.Items.Add(lvItem);

                    HauptspeiseL.Add(new Hauptspeise(Convert.ToInt64(dr[0].ToString()), (dr[1].ToString())));
                }
                conn.Close();
            }

            else if (this.Text.Equals("NachspeiseListe"))
            {
                conn = new OleDbConnection(cn);

                conn.Open();
                sql = "SELECT * FROM Nachspeise";
                cmd = new OleDbCommand(sql, conn);

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lvItem = new ListViewItem(dr[0].ToString());
                    lvItem.SubItems.Add(dr[1].ToString());
                    listView1.Items.Add(lvItem);

                    NachspeiseL.Add(new Nachspeise(Convert.ToInt64(dr[0].ToString()), (dr[1].ToString())));
                }
                conn.Close();
            }

            else
            {
                MessageBox.Show("wählen Sie bitte ein der Tabellen");
            }
        }

        private void neuAnlegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Text = "Neu anlegen";
            f3.ShowDialog();
        }

        private void bearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Text = "bearbeiten";
            f3.ShowDialog();
        }

        private void löschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Text.Equals("VorspeiseListe"))
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Bitte wählen Sie ein Produkt zum Löschen aus!");
                    return;
                }
                lvItem = listView1.SelectedItems[0];
                long vid = Convert.ToInt64(lvItem.SubItems[0].Text);
                foreach (Vorspeise f in VorspeiseL)
                {
                    if (f.VID == vid)
                    {
                        //MessageBox.Show("gefunden!");
                        sql = "Delete * from Vorspeise where VID = ?;";
                        cmd = new OleDbCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("VID", vid);
                        break;
                    }

                }
            }

            else if (this.Text.Equals("HauptspeiseListe"))
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Bitte wählen Sie ein Produkt zum Löschen aus!");
                    return;
                }
                lvItem = listView1.SelectedItems[0];
                long hid = Convert.ToInt64(lvItem.SubItems[0].Text);
                foreach (Hauptspeise f in HauptspeiseL)
                {
                    if (f.HID == hid)
                    {
                        //MessageBox.Show("gefunden!");
                        sql = "Delete * from Hauptspeise where HID = ?;";
                        cmd = new OleDbCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("HID", hid);
                        break;
                    }

                }
            }

            else if (this.Text.Equals("NachspeiseListe"))
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Bitte wählen Sie ein Produkt zum Löschen aus!");
                    return;
                }
                lvItem = listView1.SelectedItems[0];
                long nid = Convert.ToInt64(lvItem.SubItems[0].Text);
                foreach (Nachspeise f in NachspeiseL)
                {
                    if (f.NID == nid)
                    {
                        //MessageBox.Show("gefunden!");
                        sql = "Delete * from Nachspeise where NID = ?;";
                        cmd = new OleDbCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.AddWithValue("NID", nid);
                        break;
                    }

                }
            }

            else
            {
                MessageBox.Show("Falsche Tabelle");
            }
        }
    }
}
