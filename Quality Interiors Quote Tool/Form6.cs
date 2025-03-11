using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Quality_Interiors_Quote_Tool
{
    public partial class Form6 : Form
    {
        private string Quotename;
        private Form2 parentForm;
        public Form6(string Quotename, Form2 parentForm)
        {
            InitializeComponent();
            this.Quotename = Quotename;
            this.parentForm = parentForm;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.Text;
            string[] lines = readDataSheet();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[1] == selected)
                {
                    string UOM = parts[8];
                    string Cost = parts[2];
                    string Retail = parts[4];
                    textBox2.Text = UOM;
                    textBox3.Text = Cost;
                    textBox4.Text = Retail;
                    button1.Enabled = true;
                    return;
                }
            }
            Debug.WriteLine("Error: UOM not found");
        }

        public string[] readDataSheet()
        {
            string Filename = "QD Install Datasheet.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] lines = File.ReadAllLines(fullPath);
            return lines;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string[] lines = readDataSheet();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                string name = parts[1];
                string namefirstchar = name.Substring(0, 1);
                if (namefirstchar == "\"")
                {
                    name = name.Trim('"');
                }
                if (name != "Supplier_Style")
                {
                    comboBox1.Items.Add(name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selected = comboBox1.Text;
            string UOM = textBox2.Text;
            string Cost = textBox3.Text;
            string Retail = textBox4.Text;
            string Quantity = textBox1.Text;
            string? StyleNum = null;
            string Supplier = "QUALITY INTERIORS";
            string? ProductCode = null;
            string Color = "";
            bool test = int.TryParse(Quantity, out int QuantityInt);
            if (Quantity == null || Quantity == "" || !test)
            {
                MessageBox.Show("Please enter a Quantity");
                textBox1.Focus();
                return;
            }
            string[] lines = readDataSheet();
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[1] == selected)
                {
                    StyleNum = parts[5];
                    ProductCode = parts[3];
                }
            }
            if (StyleNum == null || StyleNum == "" || ProductCode == null || ProductCode == "")
            {
                MessageBox.Show("Error");
                return;
            }
            bool costTest = double.TryParse(Cost, out double CostDouble);
            if (!costTest)
            {
                MessageBox.Show("Error: Cost is not a number");
                return;
            }
            bool retailTest = double.TryParse(Retail, out double RetailDouble);
            if (!retailTest)
            {
                MessageBox.Show("Error: Retail is not a number");
                return;
            }
            string newRow = $"{StyleNum},{ProductCode},{Supplier},{selected},{Color},{UOM},{Quantity},{RetailDouble},{CostDouble},Active";
            string Filename = Quotename + ".csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Quotename, Filename);
            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
                writer.WriteLine(newRow);
            }
            string[] datagridrow = { Quantity, UOM, ProductName, Cost, Retail };
            parentForm.appendRow(datagridrow);
            this.Close();
        }
    }
}
