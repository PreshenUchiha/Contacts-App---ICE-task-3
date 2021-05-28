using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts_App
{
    public partial class Form1 : Form
    {
        List<Contact> contacts = new List<Contact>();
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            contacts.Clear();
            string line;

            try
            {
                StreamReader file = new StreamReader("Contacts.txt");
                while ((line = file.ReadLine()) != null)
                {
                    var lineParts = line.Split(",");
                    Contact temp = new Contact(lineParts[0], lineParts[1], lineParts[2], lineParts[3]);
                    contacts.Add(temp);
                }
                file.Close();
            }
              catch(FileNotFoundException)
            {
                StreamWriter sw = new StreamWriter("Contacts.txt");
                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            lstContacts.Items.Clear();
            foreach (Contact contact in contacts)
            {
                lstContacts.Items.Add(contact.Name + "" + contact.Surname);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedName = lstContacts.SelectedItem.ToString();

            Contact selectedContact = new Contact();

            foreach (Contact contact in contacts)
            {
                if ((contact.Name + "" + contact.Surname).Equals(selectedName))
                {
                    selectedContact = contact;
                    break;
                }
            }

            List<string> contactInfo = new List<string>();
            contactInfo.Add("Details");
            contactInfo.Add("-------------------------");
            contactInfo.Add("Name: " + selectedContact.Name);
            contactInfo.Add("Surname" + selectedContact.Surname);
            contactInfo.Add("Cell" + selectedContact.Cellphone);
            contactInfo.Add("Email" + selectedContact.Email);

            txbDetails.Lines = contactInfo.ToArray<string>();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txbName.Text;
            string surname = txbSurname.Text;
            string email = txbEmail.Text;
            string cellphone = txbCellphone.Text;

            Contact newContact = new Contact(name, surname, cellphone, email);
            contacts.Add(newContact);

            try
            {
                StreamWriter sw = new StreamWriter("Contacts.txt", true);
                foreach (Contact c in contacts)
                {
                    sw.WriteLine(newContact.Name + "," + newContact.Surname + "," + newContact.Cellphone + newContact.Email);
                }
                sw.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            txbName.Clear();
            txbSurname.Clear();
            txbEmail.Clear();
            txbCellphone.Clear();

            lstContacts.Items.Clear();
            foreach (Contact contact in contacts)
            {
                lstContacts.Items.Add(contact.Name + "" + contact.Surname);
            }
        }
    }
}
