using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quality_Interiors_Quote_Tool
{
    public partial class Form4 : Form
    {
        private string Quotename;
        private Form2 parentForm;
        public Form4(string Quotename, Form2 parentForm)
        {
            InitializeComponent();
            this.Quotename = Quotename;
            getMaterialTypes();
            getDistributors();
            this.parentForm = parentForm;
            comboBox3.Items.Add("EA");
            comboBox3.Items.Add("SF");
            comboBox3.Items.Add("SY");
            comboBox1.Focus();
        }
        private void getMaterialTypes()
        {
            string Filename = "Product Codes.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] lines = File.ReadAllLines(fullPath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                comboBox2.Items.Add(parts[0]);
            }
        }
        private void getDistributors()
        {
            string Filename = "Suppliers.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] lines = File.ReadAllLines(fullPath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                comboBox1.Items.Add(parts[0]);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string? Distributor = comboBox1.SelectedItem?.ToString();
            string? MaterialType = comboBox2.SelectedItem?.ToString();
            string Quantity = textBox3.Text;
            string? UOM = comboBox3.SelectedItem?.ToString();
            string ProductName = textBox5.Text;
            string Color = textBox6.Text;
            string SKU = textBox7.Text;
            string Cost = textBox8.Text;
            string Retail = textBox9.Text;
            if (Distributor == null|| Distributor == "")
            {
                MessageBox.Show("Please select a distributor");
                comboBox1.Focus();
                return;
            }
            if (MaterialType == null || MaterialType == "")
            {
                MessageBox.Show("Please select a material type");
                comboBox2.Focus();
                return;
            }
            if (Quantity == null || Quantity == "")
            {
                MessageBox.Show("Please enter a quantity");
                textBox3.Focus();
                return;
            }
            if (UOM == null || UOM == "")
            {
                MessageBox.Show("Please select a unit of measure");
                comboBox3.Focus();
                return;
            }
            if (ProductName == null || ProductName == "")
            {
                MessageBox.Show("Please enter a product name");
                textBox5.Focus();
                return;
            }
            if (Color == null || Color == "")
            {
                MessageBox.Show("Please enter a color");
                textBox6.Focus();
                return;
            }
            if (SKU == null || SKU == "")
            {
                MessageBox.Show("Please enter a SKU");
                textBox7.Focus();
                return;
            }
            if (Cost == null || Cost == "")
            {
                MessageBox.Show("Please enter a cost");
                textBox8.Focus();
                return;
            }
            if (Retail == null || Retail == "")
            {
                MessageBox.Show("Please enter a retail price");
                textBox9.Focus();
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
            string ProductCode = getProductCode(MaterialType);
            if (ProductCode == "null")
            {
                MessageBox.Show("Error: Material type not found");
                return;
            }
            string newRow = $"{SKU},{ProductCode},{Distributor},{ProductName},{Color},{UOM},{Quantity},{RetailDouble},{CostDouble},Active";
            string Filename = Quotename+".csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Quotename, Filename);
            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
                writer.WriteLine(newRow);
            }
            string[] datagridrow = { Quantity, UOM, ProductName,Cost,Retail};
            parentForm.appendRow(datagridrow);
            this.Close();
        }
        public string getProductCode(string MaterialType) 
        {
            string Filename = "Product Codes.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] lines = File.ReadAllLines(fullPath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] == MaterialType)
                {
                    return parts[1];
                }
            }
            return "null";
        }
    }
}
