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
    class DAO_Admin
    {
        Connection cn = new Connection("select * from Admins", "tbl_Admin");
         




        public void UpdateManager(string username, Manager m)
        {

            DataRow[] rd = Connection.ds.Tables["tbl_Managers"].Select("Username_manager='" + username + "'");


            rd[0].BeginEdit();
            rd[0][2] = m.First_Name;
            rd[0][3] = m.Last_Name;
            rd[0][0] = m.UserName;
            rd[0][1] = m.Password;
            rd[0][4] = m.Phone_Number;
            rd[0].EndEdit();



            Enregistrer();

        }



        public int checkAdminLogin(bool check, string user, string password)
        {


            if (check == true)
            {
                DAO_Admin dc = new DAO_Admin();  
                DataView dv = new DataView(Connection.ds.Tables["tbl_Admin"]);
                dv.RowFilter = "Username_Admin='" + user + "' AND Password_Admin='" + password + "'";
                try
                {
                    if (dv[0] != null && user != "" && password != "")
                    {
                        return 1;

                    }
                    else return 0;
                }
                catch (Exception)
                {
                    return 0;

                }


            }
            else return -1;

        }

        public void fillCurentAdmin(string user, Admin c)
        {

            DataRow dr = Connection.ds.Tables["tbl_Admins"].Rows.Find(user);
            c.UserName = dr[0].ToString();
            c.Password = dr[1].ToString();
             
        }

        public void Enregistrer()
        {
            cn.Enregistrer("tbl_Managers");

        }

    }
}
