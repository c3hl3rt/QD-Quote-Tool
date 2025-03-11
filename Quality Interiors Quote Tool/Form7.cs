using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace Quality_Interiors_Quote_Tool
{
    public partial class Form7 : Form
    {
        private string Quotename;
        private Form2 parentForm;
        public Form7(string Quotename, Form2 parentForm)
        {
            InitializeComponent();
            this.Quotename = Quotename;
            this.parentForm = parentForm;
            populatecomboBox();
        }
        private void populatecomboBox()
        {
            string Filename = "Customer Data.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] strings = File.ReadAllLines(fullPath);
            foreach (string s in strings)
            {
                string[] split = ParseCsvLine(s);
                if (split[0] != "Cust_Name")
                {
                    split[0] = split[0].Trim('"');
                    comboBox1.Items.Add(split[0]);
                }
                
            }
        }
        static string[] ParseCsvLine(string csvLine)
        {
            using (var reader = new StringReader(csvLine))
            using (var parser = new TextFieldParser(reader))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                if (!parser.EndOfData)
                {
                    return parser.ReadFields();
                }
            }
            return Array.Empty<string>(); // Return an empty array if no data is found
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string? Name = comboBox1.SelectedItem!.ToString();
            if (Name == null || Name == "")
            {
                MessageBox.Show("Please select a customer");
                return;
            }
            string Filename = "Customer Data.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] strings = File.ReadAllLines(fullPath);
            foreach (string s in strings)
            {
                string[] split = ParseCsvLine(s);
                split[0] = split[0].Trim('"');
                if (split[0] == Name)
                {
                    string? FirstName = null;
                    string? LastName = null;
                    string[] namesplit = Name.Split(',');
                    if(namesplit.Length == 2)
                    {
                        FirstName = namesplit[1];
                        LastName = namesplit[0];
                    }
                    else
                    {
                        LastName = namesplit[0];
                        FirstName = "";
                    }
                    string [] AdrSplit = split[3].Split(',');
                    string Address1 = "";
                    string Address2 = "";
                    if (AdrSplit.Length == 2)
                    {
                        Address1 = AdrSplit[0];
                        Address2 = AdrSplit[1];
                    }
                    else
                    {
                        Address1 = AdrSplit[0];
                        Address2 = split[4];
                    }
                        Debug.WriteLine(split[3]);
                    string newRow = $"Sold-to,{FirstName},{LastName},{Address1},{Address2},{split[5]},{split[6]},{split[7]},,{split[9]},{split[8]},{split[2]},Active";
                    Filename = Quotename + " Address.csv";
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
                    fullPath = Path.Combine(path, Quotename, Filename);
                    List<string> linesList = File.ReadAllLines(fullPath).ToList();

                    for (int i = 0; i < linesList.Count; i++)
                    {
                        string[] parts = linesList[i].Split(',');

                        if (parts[0] == "Sold-to" && parts.Length > 12 && parts[12] == "Active")
                        {
                            parts[12] = "Inactive"; // Modify the array directly
                            linesList[i] = string.Join(",", parts); // Reconstruct the line
                        }
                    }
                    linesList.Add(newRow);
                    File.WriteAllLines(fullPath, linesList);
                    string[] datagridrow = { $"{LastName}, {FirstName}", $"{split[3]}, {split[4]}", $"{split[5]}, {split[6]} {split[7]}", split[9], split[8] };
                    parentForm.appendCustRow(datagridrow, "Sold-to");
                    this.Close();
                }
            }
        }
    }
}
