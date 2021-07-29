using System;
using System.Collections.Generic;
using Anket2.Helpers;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using SmartFormApp.Helpers;
using Guna.UI2.WinForms;

namespace Anket2
{
    public partial class Form1 : Form
    {
        public string Namee { get; set; } = string.Empty;
        public string Surnamee { get; set; } = string.Empty;
        public string Birthh  { get; set; } = string.Empty;
        public string Emaill  { get; set; } = string.Empty;
        public string Phonee { get; set; } = string.Empty;

        FileHelper FH = new FileHelper();


        public Form1()
        {
            InitializeComponent();
            foreach (var item in anketGbox.Controls)
            {
                if(item is Guna2TextBox tx)
                {
                    if((tx.Tag as string)!="nameTag")
                        tx.Enabled = false; 
                }
            }
            //addtoFilebtn.Enabled = false;
            //AddListbtn.Enabled = false;
            //Changebtn.Enabled = false;

            //surnameTxtbox.Enabled = false;
            //birthdayTxtbox.Enabled = false;
            //phoneTxtbox.Enabled = false;
            //emailTxtbox.Enabled = false;

            listBox1.DisplayMember = "Name";

        }

        public void CreatObject()
        {
           
                Namee = nametxtbox.Text;
                Surnamee = surnameTxtbox.Text;
                Birthh = birthdayTxtbox.Text;
                Emaill = emailTxtbox.Text;
                Phonee = phoneTxtbox.Text;
                Questions anket = new Questions
                {
                    Name = Namee,
                    Surname = Surnamee,
                    Birthday = Birthh,
                    Email = Emaill,
                    Phone = Phonee,
                };

                

                string filename = Namee + ".json";
                if (File.Exists(filename))
                {
                    MessageBox.Show("This name has already been used");
                }
                else
                {
                    FH.JsonSerialization(anket, filename);
                    MessageBox.Show("Anket Saved");
                }
                  
        }


        private void Loadbtn_Click(object sender, EventArgs e)
        {
            
            string filename = Filenametxtbox.Text + ".json";
            Questions anket = new Questions();
            if (File.Exists(filename))
            {
                FH.JsonDeserialize(ref anket, filename);
                nametxtbox.Text = anket.Name;
                surnameTxtbox.Text = anket.Surname;
                emailTxtbox.Text = anket.Email;
                phoneTxtbox.Text = anket.Phone;
                birthdayTxtbox.Text = anket.Birthday;
            }
            else
            {
                MessageBox.Show("No files with this name were found");
            }
        }

       

        private void AddListbtn_Click(object sender, EventArgs e)
        {
            var q = new Questions
            {
                Name = nametxtbox.Text,
                Surname = surnameTxtbox.Text,
                Birthday = birthdayTxtbox.Text,
                Email = emailTxtbox.Text,
                Phone = phoneTxtbox.Text
            };

            listBox1.Items.Add(q);
        }

        private void Changebtn_Click(object sender, EventArgs e)
        {
            nametxtbox.Text = Namee;
            surnameTxtbox.Text = Surnamee;
            birthdayTxtbox.Text = Birthh;
            emailTxtbox.Text = Emaill;
            phoneTxtbox.Text = Phonee;
        }

      
       
        private void emailTxtbox_TextChanged(object sender, EventArgs e)
        {
            emailTxtbox.ForeColor = Color.Red;
            var result1 = Validations.IsMailValid(emailTxtbox?.Text);
            var result2 = Validations.IsGmailValid(emailTxtbox?.Text);

            if (result1 || result2) 
            {
                emailTxtbox.ForeColor = Color.Green;
                addtoFilebtn.Enabled = true;
                AddListbtn.Enabled = true;
                Loadbtn.Enabled = true;
            }
        }

        private void Filenametxtbox_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Write only name");
        }

        private void nametxtbox_TextChanged(object sender, EventArgs e)
        {            
            nametxtbox.ForeColor = Color.Red;
            var result = Validations.IsNameValid(nametxtbox?.Text);            
            
            if (result)
            {
                nametxtbox.ForeColor = Color.Green;
                surnameTxtbox.Enabled = true;
            }
            
        }

        private void surnameTxtbox_TextChanged(object sender, EventArgs e)
        {
            surnameTxtbox.ForeColor = Color.Red;
            var result = Validations.IsNameValid(surnameTxtbox?.Text);
           

            if (result)
            {
                surnameTxtbox.ForeColor = Color.Green;
                birthdayTxtbox.Enabled = true;
            }
            
        }

        private void phoneTxtbox_TextChanged(object sender, EventArgs e)
        {
            phoneTxtbox.ForeColor = Color.Red;
            var result = Validations.IsPhoneValid(phoneTxtbox?.Text);

            if (result)
            {
                phoneTxtbox.ForeColor = Color.Green;
                emailTxtbox.Enabled = true;
            }
        }

        private void birthdayTxtbox_TextChanged(object sender, EventArgs e)
        {
            birthdayTxtbox.ForeColor = Color.Red;
            var result = Validations.IsBirthValid(birthdayTxtbox?.Text);

            if (result)
            {
                birthdayTxtbox.ForeColor = Color.Green;
                phoneTxtbox.Enabled = true;
            }
        }

        private void addtoFilebtn_Click(object sender, EventArgs e)
        {
            foreach (var item in anketGbox.Controls)
            {
                if (item is Guna2TextBox tx)
                {
                    tx.Text = String.Empty;
                }
            }
            FH.JsonSerialization(User, User.Name + ".json");
        }
        public Questions User { get; set; }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             User = listBox1.SelectedItem as Questions;
            Filenametxtbox.Text = User.Name;

        }
    }
}
