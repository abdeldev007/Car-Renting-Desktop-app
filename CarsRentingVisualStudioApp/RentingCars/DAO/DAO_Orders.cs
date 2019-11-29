using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentingCars.DAO;
using RentingCars.Entity;
using System.Data.SqlClient;

namespace RentingCars.DAO
{
    class DAO_Orders
    {
        Connection cn = new Connection("select  * from Orders  ", "tbl_svorder");
        //  Connection cnsave;  = new Connection("select Distinct  * from Orders ", "tbl_OrdersSave");
        private string tb;
        public void creatconnection(string con,string tbl)
        {
              cn = new Connection(con,tbl);

            this.tb = tbl;
        }
        public void Ajouter(Orders o)
        {
            
          
            DataRow r = Connection.ds.Tables["tbl_svorder"].NewRow();
            r[2] = o.User_Name;
            r[0] = o.ID_Car;
            r[1] = o.DateTaken;
             
           
            Connection.ds.Tables["tbl_svorder"].Rows.Add(r);

            Enregistrer("tbl_svorder");
        }

 
         public DataTable getOrdersByUser(string user)
        {

     

            SqlCommand c = new SqlCommand();
            c.Connection = cn.cn;
            c.CommandType = CommandType.Text;
            c.CommandText = "select Orders.Takethecar_at as [Taken at ], Cars.Mark as Mark,Cars.Model as Model,Cars.PriceForDay as [Price For a day]  from Orders inner join Cars  on Cars.ID_Car=Orders.ID_Car where Orders.Username_Client='" + user+"'";

 
            DataTable dvOrder = new DataTable();
            cn.cn.Open();
            dvOrder.Load(c.ExecuteReader());
            cn.cn.Close();
            
            return dvOrder;


        }





        public void Enregistrer(string tb)
        {
            cn.Enregistrer(tb);

        }
    }
}
