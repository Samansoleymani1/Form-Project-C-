
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyContacts
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
             
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void bindGrid()
        {
            using (Contact_DBEntities db = new Contact_DBEntities())
            {

                dgContacts.AutoGenerateColumns = false;
                dgContacts.Columns[0].Visible = false;
                dgContacts.DataSource = db.MyDataBases.ToList();
            }
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            bindGrid();
        }

        private void btnnewContact_Click(object sender, EventArgs e)
        {
            frmADDOrEdite frm = new frmADDOrEdite();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)

            {
                bindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string name = dgContacts.CurrentRow.Cells[1].Value.ToString();
            string family = dgContacts.CurrentRow.Cells[2].Value.ToString();
            string fullname = name + " " + family;


            if (dgContacts.CurrentRow!= null)
            {
                if (MessageBox.Show($"آیا از حذف {fullname} مطمعن هستید ؟", "توجه",MessageBoxButtons.YesNo )==DialogResult.Yes)

                {
                    int contactsId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                    using (Contact_DBEntities db = new Contact_DBEntities())
                    {

                        MyDataBase database = db.MyDataBases.Single(c => c.ContactID == contactsId);
                        db.MyDataBases.Remove(database);
                        db.SaveChanges();
                    }

                    bindGrid(); 
                }
            }
            else
            {

                MessageBox.Show("یک کاربر را از لیست انتخاب کنید ");

            }


        }

        private void btnEdite_Click(object sender, EventArgs e)
        {
            if (dgContacts.CurrentRow!= null)
            {
                int contactId = int.Parse(dgContacts.CurrentRow.Cells[0].Value.ToString());
                frmADDOrEdite frm = new frmADDOrEdite();
                frm.contactId = contactId;
                if (frm.ShowDialog()==DialogResult.OK)
                {
                    bindGrid();
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            using (Contact_DBEntities db = new Contact_DBEntities())
            {
            dgContacts.DataSource =db.MyDataBases.Where(c=>c.Name.Contains(txtSearch.Text)|| c.Family.Contains(txtSearch.Text)).ToList();

            }
        }
    }
}
    

