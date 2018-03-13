using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Speiseplan
{
    class DatabaseAccess
    {
        public string cn;
        public OleDbConnection conn;
        public OleDbCommand cmd;

        public DatabaseAccess()
        {
            cn = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = Speiseplan.accdb";
            conn = new OleDbConnection(cn);
            conn.Open();

        }

        public OleDbDataReader readData(string sql)
        {
            try
            {
                conn.Close();
                conn.Open();
                cmd = new OleDbCommand(sql, conn);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Einlesen " + ex.Message);
            }
        }



        internal void executeQuery(OleDbCommand cmd)
        {
            try
            {
                cmd.Connection = conn;
                conn.Close();
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Ausführen " + ex.Message);

            }
        }

        internal Int64 executeScalar(string sql)
        {
            try
            {

                conn.Close();
                conn.Open();
                cmd = new OleDbCommand(sql, conn);
                Int64 z = Convert.ToInt64(cmd.ExecuteScalar());
                return z;
            }
            catch (Exception ex)
            {
                throw new Exception("Fehler beim Berechnen der Funktion " + ex.Message);
            }
        }
    }
}

