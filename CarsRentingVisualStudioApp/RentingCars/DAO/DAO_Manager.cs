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
    class DAO_Manager
    {

        Connection cn = new Connection("select * from Managers", "tbl_Managers");
        public void Ajouter(Manager c)
        {

            DataRow r = Connection.ds.Tables["tbl_Managers"].NewRow();
             r[2] = c.First_Name;
            r[3] = c.Last_Name;
             r[0] = c.UserName;
            r[1] = c.Password;
            r[4] = c.Phone_Number;
            Connection.ds.Tables["tbl_Managers"].Rows.Add(r);

        }


       


        public void UpdateManager(string username,Manager m)
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



        public int checkManagerLogin(bool check, string user, string password)
        {
            
             
            if (check == true)
            {
                DAO_Manager dc = new DAO_Manager();
                DataView dv = new DataView(Connection.ds.Tables["tbl_Managers"]);
                dv.RowFilter = "Username_manager='" + user + "' AND Password_manager='" + password + "'";
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

        public DataRow findManager(string user)
        {

            return Connection.ds.Tables["tbl_Managers"].Rows.Find(user);


        }
        public void fillCurentManager(string user, Manager c)
        {

            DataRow dr = Connection.ds.Tables["tbl_Managers"].Rows.Find(user);
            c.First_Name = dr[0].ToString();
            c.Last_Name = dr[1].ToString();
             c.UserName = dr[2].ToString();
            c.Password = dr[3].ToString();
            c.Phone_Number = dr[4].ToString();

        }


        public void Enregistrer()
        {
            cn.Enregistrer("tbl_Managers");

        }

    }
}
 
