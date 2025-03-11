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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            string Filename = "Quote Masterlist.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] lines = File.ReadAllLines(fullPath);
            foreach (var line in lines)
            {
                string[] values = line.Split(',');
                comboBox1.Items.Add("QDQ"+values[0]);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? Quotename = comboBox1.SelectedItem!.ToString();
            if (Quotename == null || Quotename == "")
            {
                MessageBox.Show("Please select a quote to load.");
                return;
            }
            Form2 form2 = new Form2(Quotename);
            form2.Show();
            this.Close();
        }
    }
}
