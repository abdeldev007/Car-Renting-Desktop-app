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
     class DAO_Clients
    {

          
        Connection cn = new Connection("select * from Clients", "tbl_Clients");
            public void Ajouter( Clients c)
            {

                DataRow r = Connection.ds.Tables["tbl_Clients"].NewRow();
 
            r[0] = c.First_Name;
            r[1] = c.Last_Name;
            r[2] = c.Gmail;
            r[3] = c.UserName;
            r[4] = c.Password;
            r[5] = c.Phone_Number;
            Connection.ds.Tables["tbl_Clients"].Rows.Add(r);
            
            }

            public DataTable getAllClients()
            {
                return Connection.ds.Tables["tbl_Clients"];
            }


        public DataRow findClient(string user)
        {

            return  Connection.ds.Tables["tbl_Clients"].Rows.Find(user) ;


        }
        public void fillCurentClient(string user,Clients c)
        {

             DataRow dr= Connection.ds.Tables["tbl_Clients"].Rows.Find(user);
            c.First_Name = dr[0].ToString();
            c.Last_Name = dr[1].ToString();
            c.Gmail = dr[2].ToString();
            c.UserName = dr[3].ToString();
            c.Password = dr[4].ToString();
            c.Phone_Number = dr[5].ToString();

        }



        public void UpdateClient(string username, string fn, string ln,string em,string user, string passw,string phn)
        {
        
            DataRow[] rd = Connection.ds.Tables["tbl_Clients"].Select("Username='" + username+ "'");

           
            rd[0].BeginEdit();
            rd[0][0] =  fn;
            rd[0][1] =  ln;
         
            rd[0][2] = em;
            rd[0][3] = user;
            rd[0][4] = passw;
            rd[0][5]=phn;
            rd[0].EndEdit();

            

           Enregistrer();
            
        }


        public void  deleteClient(string user)
        {
           Connection.ds.Tables["tbl_Clients"].Rows.Find(user).Delete();
            Enregistrer();
        }


        public int checkClientLogin(bool check , string user,string password)
        {
            

            if (check==true)
            {
                DAO_Clients dc = new DAO_Clients();
                DataView dv = new DataView(Connection.ds.Tables["tbl_Clients"]);
                dv.RowFilter = "Username='" + user + "' AND Password='" + password + "'";

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
               

            } else return -1;
            
        }


            public void Enregistrer()
            {
                cn.Enregistrer("tbl_Clients");
            
            }

        }
    }
 
