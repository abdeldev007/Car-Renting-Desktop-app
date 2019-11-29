using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RentingCars.Entity;
using RentingCars.DAO;
using System.Data.SqlClient;
using Message = RentingCars.Entity.Message;

namespace RentingCars.Views
{
    public partial class Form1 : Form
    {


        private void FillCarsdtg()
        {
            dtgCars.DataSource = Connection.ds.Tables["tbl_Cars"];
        }
        private Manager CurrentManager = new Manager();
        private Clients CurrentClient = new Clients();
        DAO_Orders _Orders = new DAO_Orders();
        DAO_Cars _Cars = new DAO_Cars();
        DAO_Clients _Client = new DAO_Clients();
        DAO_Message _Message = new DAO_Message();

        DAO_Manager _Manager = new DAO_Manager();
        private Orders currentclientorder = new Orders();

        public Form1()
        {
            InitializeComponent();
            //DAO_Cars dc = new DAO_Cars();

            txtPasswordAdmin.Enabled = false;
            txtUsenmaeAdmin.Enabled = false;
            DAO_Clients d = new DAO_Clients();
            //  MessageBox.Show(  Connection.ds.Tables["tbl_Clients"].Rows.Find("reccakun")[3].ToString());

            AccessTxtObj(false);
            cardLoginSpace.BringToFront();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInscrUserName.Text != null && txtInscrPassword.Text == txtInscrPassword2.Text)
                {

                    Clients c = new Clients();
                  

                    c.First_Name = txtInscrFirstName.Text;
                    c.Last_Name = txtInscrLastName.Text;

                    c.Gmail = txtInscrEmail.Text;
                    c.UserName = txtInscrUserName.Text;
                    c.Password = txtInscrPassword.Text;
                    c.Phone_Number = txtInscrPhoneNumber.Text;
                    _Client.Ajouter(c);
                    _Client.Enregistrer();
                    MessageBox.Show(" You Signed Up Successfully , Try to Sign In!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                   
                MessageBox.Show("Confirmation Password doesn't match with the password you entered", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception  )
            {
                 MessageBox.Show("User Name is Already Exist !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txt1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {

        }
        private void fillUserProfile(Clients c)
        {
            txtprofilefirstname.Text = c.First_Name;
            txtProfileLastname.Text = c.Last_Name;
            txtprofilepassword.Text = c.Password;
            txtprofilePhone.Text = c.Phone_Number;
            txtprofileusername.Text = c.UserName;
            txtprofileemail.Text = c.Gmail;
        }
        private void fillUserManagerProfile(Manager c)
        {
            txtProfileFirstNameManager.Text = c.First_Name;
            txtProfileLstNameManager.Text = c.Last_Name;
            txtProfilePasswodManager.Text = c.Password;
            txtProfilePhoneManager.Text = c.Phone_Number;
            txtProfileUserManager.Text = c.UserName;
        
        }
        private void btnSignIn_Click(object sender, EventArgs e)
        {
           
            int a = _Client.checkClientLogin(cmbClient.Checked, txtUsername.Text, txtPassword.Text);
            try
            {
                if (a == 0)
                {
                    MessageBox.Show("Not Registred !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (a == 1)
                {

                    _Client.fillCurentClient(txtUsername.Text, CurrentClient);
                      fillUserProfile(CurrentClient);
                  
                    DataView dv = new DataView(_Cars.getAllCars());
                 
                    cmbMark.DataSource = dv.ToTable(true,"Mark");
                                    cmbMark.DisplayMember = "Mark";
                    cmbModel.DataSource = dv.ToTable(true, "Model");
                    cmbModel.DisplayMember = "Model";
                    cmbPrices.DataSource = dv.ToTable(true, "PriceForDay");
                    cmbPrices.DisplayMember = "PriceForDay";
                    FillCarsdtg();
                    dtgmyOrders.DataSource = _Orders.getOrdersByUser(CurrentClient.UserName);
                    dv = new DataView(Connection.ds.Tables["tbl_Messages"]);
                    dv.RowFilter = "username='" + CurrentClient.UserName+"'";
                    
                    lbMessages.DataSource = dv;

                    lbMessages.DisplayMember = "messagecontext";
                
                    lbMessages.ValueMember = "username";
                    cardClientSpace.BringToFront();


                }
                else if (a == -1)
                {
                  int m= _Manager.checkManagerLogin(cmbManager.Checked, txtUsername.Text, txtPassword.Text);
                    if (m == 1)
                    {
                        _Manager.fillCurentManager(txtUsername.Text,CurrentManager);

                        dtgClients.DataSource = Connection.ds.Tables["tbl_Clients"];
                        dtgManagerCars.DataSource = Connection.ds.Tables["tbl_Cars"];
                        fillUserManagerProfile(CurrentManager);
                        cardManagerPanel.BringToFront();
                    }else if (m == -1)
                    {
                        DAO_Admin _Admin = new DAO_Admin();

                        if (_Admin.checkAdminLogin(cmbAdmin.Checked, txtUsername.Text, txtPassword.Text) == 1)
                        {
                        dtgClientsAdminSpace.DataSource = Connection.ds.Tables["tbl_Clients"];
                        dtgManagerAdminspace.DataSource = Connection.ds.Tables["tbl_Managers"];
                            txtUsenmaeAdmin.Text = txtUsername.Text;
                            txtPasswordAdmin.Text = txtPassword.Text;

                        cardAdmin.BringToFront();
                        }
                        else MessageBox.Show("Not Registred !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);



                    }
                }
               
            }
            catch (Exception   )
            {
                throw; //  MessageBox.Show("Not Registred !", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

       

        private void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                AccessTxtObj(false);

                _Client.UpdateClient(CurrentClient.UserName, txtprofilefirstname.Text,
                    txtProfileLastname.Text,
                    txtprofileemail.Text, txtprofileusername.Text, txtprofilepassword.Text, txtprofilePhone.Text);
                _Client.Enregistrer();

                MessageBox.Show("Your Profile has been modified successfully !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Username can't be Updated !", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cardClientSpace_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void dtgCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dtgCars.Columns[e.ColumnIndex].Name== "btnAddToMyOrder")
            {
                DataView dv = new DataView(Connection.ds.Tables["tbl_svorder"]);
               // MessageBox.Show(dtgCars.SelectedRows[0].Cells[1].Value.ToString());
                  dv.RowFilter="ID_Car="+dtgCars.SelectedRows[0].Cells[1].Value;
                try
                {
                    if (dv[0] != null)
                    {
                        MessageBox.Show("This Car is Not Available !");
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    Orders o = new Orders();
                    o.ID_Car = int.Parse(dtgCars.CurrentRow.Cells[1].Value.ToString());
                    o.User_Name = CurrentClient.UserName;
                    o.DateTaken = DateTime.Now.AddDays(1);
                    _Orders.Ajouter(o);
                    dtgmyOrders.DataSource = _Orders.getOrdersByUser(CurrentClient.UserName);


                }

            }
        }

        private void cardLoginSpace_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
           
                cardLoginSpace.BringToFront();
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure !", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                cardLoginSpace.BringToFront();
            }
        }

        private void btnEditeProfile_Click(object sender, EventArgs e)
        {
            AccessTxtObj(true);
        }
        public void AccessTxtObj(bool b)
        {
            txtprofileemail.Enabled = b;
            txtprofilefirstname.Enabled = b;
            txtProfileLastname.Enabled = b;
            txtprofilePhone.Enabled = b;
            txtprofileusername.Enabled = b;
            txtprofilepassword.Enabled = b;
        }
        public void AccessTxtObjManager(bool b)
        {
            txtProfilePhoneManager.Enabled = b;
            txtProfileUserManager.Enabled = b;
            txtProfileFirstNameManager.Enabled = b;
            txtProfileLstNameManager.Enabled = b;
            txtProfilePasswodManager.Enabled = b;
        }
        private void cardManagerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddorder_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are you sure ! ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (d==DialogResult.Yes)
            {
                _Client.deleteClient(CurrentClient.UserName);
                cardLoginSpace.BringToFront();
                dtgCars.Refresh();

            }

        }

        private void cmbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
    

            for (int i = 0; i < dtgCars.Rows.Count; i++)
            {
                if (cmbModel.SelectedValue.ToString().Equals(dtgCars.Rows[i].Cells[2].Value.ToString()))
                {

                    dtgCars.Rows[i].Selected = true;
                    
                    break;
                }
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            float p = 0;
            foreach(DataGridViewRow r in dtgmyOrders.Rows)
            {
                p += float.Parse(r.Cells[3].Value.ToString());
            }
            lblTotalePrices.Text = p + " DH";
        }

        private void btnSaveManagerProfile_Click(object sender, EventArgs e)
        {
            AccessTxtObjManager(false);
            DAO_Manager dc = new DAO_Manager();
            Manager m = new Manager();
            m.First_Name = txtProfileFirstNameManager.Text;
            m.Last_Name = txtProfileLstNameManager.Text;
            m.Phone_Number = txtProfilePhoneManager.Text;
            m.Password = txtProfilePasswodManager.Text;
            m.UserName = txtProfileUserManager.Text;
            dc.UpdateManager(CurrentManager.UserName, m);
            dc.Enregistrer();
            MessageBox.Show("Your Profile has been modified successfully !", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditeManagerProfile_Click(object sender, EventArgs e)
        {
            AccessTxtObjManager(true);
        }

        private void dtgManagerCars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgManagerCars.Columns[e.ColumnIndex].Name == "btnDeleteCar")
            {
                DialogResult d = MessageBox.Show("Are you Syre !", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (d == DialogResult.Yes)
                {

                    dtgManagerCars.Rows.RemoveAt(e.ColumnIndex);

                    _Cars.Enregistrer();
                }


            }
        }

        private void bunifuDropdown7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtgManagerAdminspace_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMaterialTextbox6_OnValueChanged(object sender, EventArgs e)
        {
                    }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'rentCarsDataSet.Messages' table. You can move, or remove it, as needed.

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
         //   MessageBox.Show(dtgClientsAdminSpace.Rows[2].Cells[5].Value.ToString());
            Message m = new Message();
            m.Date_Message = DateTime.Now;
            m.Message_to_Clients = txtMessage.Text;
            for(int i=0;i<dtgClientsAdminSpace.RowCount;i++)  
            {
               m.Username_Message= dtgClientsAdminSpace.Rows[i].Cells[5].Value.ToString();
                _Message.AddMessage(m);
            }
            _Message.Enregistrer();
            txtMessage.Clear();
        }

        private void dtgClientsAdminSpace_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgClientsAdminSpace.Columns[e.ColumnIndex].Name == "btnDeleteClientDTG_Clients")
            {
                DialogResult d = MessageBox.Show("Are you Syre !", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (d == DialogResult.Yes)
                {

                    dtgClientsAdminSpace.Rows.RemoveAt(e.ColumnIndex);

                    _Client.Enregistrer();
                }


            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            _Manager.Enregistrer();
        }

        private void btnAddManager_Click(object sender, EventArgs e)
        {
            if (txtManagerUserName.Text != "" && txtManagerPassword.Text != "")
            {
                Manager m = new Manager();
            m.First_Name = txtManagerFirstName.Text;
            m.Last_Name = txtManagerLastName.Text;
            m.Phone_Number = txtManagerPhoneNumber.Text;
            m.Password = txtManagerPassword.Text;
            m.UserName = txtManagerUserName.Text;
            _Manager.Ajouter(m);
             _Manager.Enregistrer();
        
            MessageBox.Show("Information Added successfully !", "",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
            else MessageBox.Show("Fill At least UserName and Password Fields !", "",
               MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void bunifuShadowPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            cardLoginSpace.BringToFront();
        }

        private void btnEditAdmin_Click(object sender, EventArgs e)
        {
 
        }

        private void btnSaveAdmin_Click(object sender, EventArgs e)
        {
                    }

        private void cardAdmin_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
