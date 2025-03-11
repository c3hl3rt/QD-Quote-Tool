using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quality_Interiors_Quote_Tool
{
    public partial class Form5 : Form
    {
        private string Quotename;
        private Form2 parentForm;
        public Form5(string Quotename, Form2 parentForm)
        {
            InitializeComponent();
            this.Quotename = Quotename;
            this.parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Description = "QD-CUSTOM LABOR";
            string StyleNumber = "QD-1000";
            string UOM = "EA";
            string Color = "";
            string Supplier = "QUALITY INTERIORS";
            string Quantity = textBox2.Text;
            string SubDescription = textBox3.Text;
            string Cost = textBox5.Text;
            string Retail = textBox6.Text;
            bool test = int.TryParse(Quantity, out int QuantityInt);
            if (Quantity == null || Quantity == "" || !test)
            {
                MessageBox.Show("Please enter a Quantity");
                textBox2.Focus();
                return;
            }
            if (SubDescription == null || SubDescription == "")
            {
                MessageBox.Show("Please enter a Description");
                textBox3.Focus();
                return;
            }
            if (Cost == null || Cost == "")
            {
                MessageBox.Show("Please enter a cost");
                textBox5.Focus();
                return;
            }
            if (Retail == null || Retail == "")
            {
                MessageBox.Show("Please enter a retail price");
                textBox6.Focus();
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
            string ProductCode = "78";
            string newRow = $"{StyleNumber},{ProductCode},{Supplier},{Description},{Color},{UOM},{Quantity},{RetailDouble},{CostDouble},Active";
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
