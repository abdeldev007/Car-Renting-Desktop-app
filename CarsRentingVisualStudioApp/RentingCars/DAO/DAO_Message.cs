using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RentingCars.Entity;

namespace RentingCars.DAO
{
    class DAO_Message
    {
        Connection cn = new Connection("select * from Messages", "tbl_Messages");
        public void AddMessage(Message m)
        {

            DataRow r = Connection.ds.Tables["tbl_Messages"].NewRow();
            r[3] = m.Date_Message;
            r[2] = m.Username_Message;
            r[1] = m.Message_to_Clients;

            Connection.ds.Tables["tbl_Messages"].Rows.Add(r);

        }
        public string RecieveLatestMessage()
        {
          return  Connection.ds.Tables["tbl_Messages"].Rows[0][0].ToString();
        }
        public void Enregistrer()
        {
            cn.Enregistrer("tbl_Messages");

        }

    }
}
