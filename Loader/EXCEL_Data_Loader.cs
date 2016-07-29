using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace Loader
{
    public class EXCEL_Data_Loader
    {
        public OleDbDataReader LoadData(string path, string sheet)
        {
            var cs = "provider=Microsoft.Jet.OLEDB.4.0; Data Source='" + path + "'; Extended Properties=Excel 8.0;";
            var c = new OleDbConnection(cs);
            c.Open();
            var cmd = c.CreateCommand();
            cmd.CommandText = "select * from  [" + sheet + "]";
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DataTable LoadSchema(string path)
        {
            var cs = "provider=Microsoft.Jet.OLEDB.4.0; Data Source='" + path + "'; Extended Properties=Excel 8.0;";
            var c = new OleDbConnection(cs);
            c.Open();
            try
            {
                return c.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            }
            finally
            {
                c.Close();
            }
        }
    }
}
