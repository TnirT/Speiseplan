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
        internal List<Vorspeise> Vorspeise = new List<Vorspeise>();
        internal List<Hauptspeise> Hauptspeise = new List<Hauptspeise>();
        internal List<Nachspeise> Nachspeise = new List<Nachspeise>();
        string cn = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Speiseplan.accdb";
        OleDbConnection conn;

        OleDbCommand cmd;
        string sql;
        ListViewItem lvItem;
        private void Form1_Load(object sender, EventArgs e)
        {
            r = new Random();

            
        }


        internal void Planung()
        {
            conn = new OleDbConnection(cn);
            conn.Open();
            sql = "SELECT * FROM Speiseplan";
            cmd = new OleDbCommand(sql, conn);
            dr = cmd.ExecuteReader();

            int count = 0;


            int z = r.Next(0, 6);
            for(int k = 0; k< 7; k++)
            {

            }
        }

    }
}
