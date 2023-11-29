 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{

    public partial class frmADDOrEdite : Form
    {
       Contact_DBEntities db = new Contact_DBEntities();    

        public int contactId = 0;
        public frmADDOrEdite()
        {
            InitializeComponent();
           
        }

        private void frmADDOrEdite_Load(object sender, EventArgs e)
        {
            if (contactId == 0)
            {
                this.Text = "افزودن شخص جدید ";
            }
            else
            {
                this.Text = " ویرایش شخص";
                MyDataBase database = db.MyDataBases.Find(contactId);
                txtName.Text = database.Name;
                txtFamiliy.Text = database.Family;
                txtMobile.Text = database.Mobile;
                txtEmail.Text = database.Email;
                txtAge.Text = database.Age.ToString();
                txtAdress.Text = database.Adress;
                btnsubmit.Text = " ویزایش";
            }
        }

        bool ValidateInputes()
        {


            if (txtFamiliy.Text == "")
            {

                MessageBox.Show("لطفا نام خانوادگی را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtName.Text == "")
            {

                MessageBox.Show("لطفا نام را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")
            {

                MessageBox.Show("لطفا شماره موبایل  را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtAge.Value == 0)
            {

                MessageBox.Show("لطفا سن را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtEmail.Text == "")
            {

                MessageBox.Show("لطفا ایمیل را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            if (txtAdress.Text == "")
            {

                MessageBox.Show("لطفا آدرس را وارد کنید ", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }


            return true;
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            if (ValidateInputes())

            {
               

                if (contactId == 0)
                {
                    MyDataBase database = new MyDataBase();
                    database.Name = txtName.Text;
                    database.Family = txtFamiliy.Text;
                    database.Age = (int)txtAge.Value;
                    database.Adress = txtAdress.Text;
                    database.Email = txtEmail.Text;
                    database.Mobile = txtMobile.Text;
                    db.MyDataBases.Add(database);
                }
                else
                {
                    var database = db.MyDataBases.Find(contactId);
                    database.Name = txtName.Text;
                    database.Family = txtFamiliy.Text;
                    database.Age = (int)txtAge.Value;
                    database.Adress = txtAdress.Text;
                    database.Email = txtEmail.Text;
                    database.Mobile = txtMobile.Text;

                }

                db.SaveChanges();
                
                    MessageBox.Show("عملیات با خطا مواجه شد ", "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
        }

       
    }
}
