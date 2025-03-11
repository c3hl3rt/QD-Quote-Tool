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
    public partial class Form8 : Form
    {
        public Form2 parentForm;
        public Form8(Form2 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
            comboBox1.Items.Add("DANA");
            comboBox1.Items.Add("HOUSE");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("");
            comboBox2.Items.Add("CARL DUBER");
            comboBox2.Items.Add("DANA");
            comboBox2.Items.Add("HOUSE");
            comboBox2.SelectedIndex = 0;
            string Filename = "Install Types.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] lines = File.ReadAllLines(fullPath);
            foreach (string line in lines)
            {
                string[] split = line.Split(',');
                comboBox3.Items.Add(split[0]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Salesperson1 = comboBox1.Text;
            string Salesperson2 = comboBox2.Text;
            string InstallTypeRaw = comboBox3.Text;
            if(InstallTypeRaw == "")
            {
                MessageBox.Show("Please select an install type.");
                return;
            }
            if (Salesperson1 == "")
            {
                MessageBox.Show("Please select a salesperson.");
                return;
            }
            string? InstallType = null;
            string Filename = "Install Types.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] lines = File.ReadAllLines(fullPath);
            foreach (string line in lines)
            {
                string[] split = line.Split(',');
                if(split[0] == InstallTypeRaw)
                {
                    InstallType = split[1];
                }
            }
            if (InstallType == null)
            {
                MessageBox.Show("Install type not found.");
                return;
            }
            string NewRow = $"{Salesperson1},{Salesperson2},{InstallType}";
            parentForm.SetJobDetails(NewRow);
            this.Close();
        }
    }
}
