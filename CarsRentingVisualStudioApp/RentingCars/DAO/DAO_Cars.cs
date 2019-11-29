using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentingCars.Entity;
using System.Data.SqlClient;
using System.Data;
namespace RentingCars.DAO
{
    class DAO_Cars
    {
        Connection cn = new Connection("select * from Cars", "tbl_Cars");
        public void Ajouter(Cars c)
        {

            DataRow r = Connection.ds.Tables["tbl_Cars"].NewRow();
            r[2] = c.AVAILABLE;
            r[0] = c.ID_CAR;
            r[1] = c.MODEL_CAR;
            r[3] = c.IMAGE_URL ;
            r[4] = c.MARK;
            r[5] = c.PRICE_FOR_DAY;
             Connection.ds.Tables["tbl_Cars"].Rows.Add(r);

        }

        public DataTable getAllCars()
        {
            return Connection.ds.Tables["tbl_Cars"];
        }




        public void UpdateCar(Cars c,int idcar)
        {

            DataRow[] rd = Connection.ds.Tables["tbl_Cars"].Select("ID_Car='" + idcar + "'");


            rd[0].BeginEdit();
            rd[0][0] = c.ID_CAR;
            rd[0][1] = c.MODEL_CAR;
            rd[0][2] = c.AVAILABLE;
            rd[0][3] = c.IMAGE_URL;
            rd[0][4] = c.MARK;
            rd[0][5] = c.PRICE_FOR_DAY;
            
            rd[0].EndEdit();



            Enregistrer();

        }



        public void Enregistrer()
        {
            cn.Enregistrer("tbl_Cars");

        }
    }
}
