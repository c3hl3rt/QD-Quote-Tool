using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Quality_Interiors_Quote_Tool
{
    public partial class Form3 : Form
    {
        private string Quotename;
        private Form2 parentForm;
        private string Status;
        public Form3(string Quotename, Form2 parentForm, string status)
        {
            InitializeComponent();
            this.Quotename = Quotename;
            this.parentForm = parentForm;
            this.Status = status;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string FirstName = textBox1.Text;
            string LastName = textBox2.Text;
            string Address = textBox3.Text;
            string Address2 = textBox4.Text;
            string City = textBox5.Text;
            string State = textBox6.Text;
            string Zip = textBox7.Text;
            string Email = textBox8.Text;
            string Phone = textBox9.Text;
            if (FirstName == null || FirstName == "")
            {
                MessageBox.Show("Please enter a First Name");
                textBox1.Focus();
                return;
            }
            if (LastName == null || LastName == "")
            {
                MessageBox.Show("Please enter a Last Name");
                textBox2.Focus();
                return;
            }
            if (Address == null || Address == "")
            {
                MessageBox.Show("Please enter an Address");
                textBox3.Focus();
                return;
            }
            if (City == null || City == "")
            {
                MessageBox.Show("Please enter a City");
                textBox5.Focus();
                return;
            }
            if (State == null || State == "")
            {
                MessageBox.Show("Please enter a State");
                textBox6.Focus();
                return;
            }
            if (Zip == null || Zip == "")
            {
                MessageBox.Show("Please enter a Zip Code");
                textBox7.Focus();
                return;
            }
            if (Email == null || Email == "")
            {
                MessageBox.Show("Please enter an Email");
                textBox8.Focus();
                return;
            }
            if (Phone == null || Phone == "")
            {
                MessageBox.Show("Please enter a Phone Number");
                textBox9.Focus();
                return;
            }
            string newRow = $"{Status},{FirstName},{LastName},{Address},{Address2},{City},{State},{Zip},,{Phone},{Email},0,Active";
            string Filename = Quotename + " Address.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Quotename, Filename);
            List<string> linesList = File.ReadAllLines(fullPath).ToList();

            for (int i = 0; i < linesList.Count; i++)
            {
                string[] parts = linesList[i].Split(',');

                if (parts[0] == Status && parts.Length > 12 && parts[12] == "Active")
                {
                    parts[12] = "Inactive"; // Modify the array directly
                    linesList[i] = string.Join(",", parts); // Reconstruct the line
                }
            }
            linesList.Add(newRow);
            File.WriteAllLines(fullPath, linesList);
            string CSZ = $"{City}, {State}, {Zip}";
            string[] datagridrow = { $"{LastName}, {FirstName}", $"{Address}, {Address2}", $"{City}, {State} {Zip}",Phone,Email };
            parentForm.appendCustRow(datagridrow,Status);
            this.Close();
        }
    }
}
