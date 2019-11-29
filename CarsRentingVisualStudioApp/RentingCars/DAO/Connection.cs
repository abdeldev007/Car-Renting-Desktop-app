using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace RentingCars.DAO
{
    class Connection
    {
        
        public static string cs = ConfigurationManager.ConnectionStrings["cn1"].ConnectionString;
        public static DataSet ds= new DataSet();
        public SqlConnection cn;
        private SqlDataAdapter da;
        private SqlCommandBuilder sb;
         
        public Connection(string cmd,string tblName)
        {
            cn = new SqlConnection(cs);
            da = new SqlDataAdapter(cmd, cn);
            sb = new SqlCommandBuilder(da);
            
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.FillSchema(ds, SchemaType.Source, tblName);
            da.Fill(ds, tblName);
            
        }
        public void Enregistrer(string tblName)
        {
            DataSet changes = ds.GetChanges();
            if (changes != null) { 
            da.Update(changes, tblName);
            ds.AcceptChanges();}
           
        }
  
    }
}
