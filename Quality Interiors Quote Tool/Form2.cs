using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Quality_Interiors_Quote_Tool
{
    public partial class Form2 : Form
    {
        public string Status;
        public Form2(string status)
        {
            InitializeComponent();
            Status = status;
            setupQuoteTable();
            if (status != "new") {
                loadExistingQuote(status);
            }
            else
            {
                Form2_Load(this, EventArgs.Empty);
            }
        }
        
        public void loadExistingQuote(string Quotename)
        {
            label4.Text = Quotename;
            string Filename = Quotename + ".csv";
            string AdrFilename = Quotename + " Address.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Quotename, Filename);
            string AdrPath = Path.Combine(path, Quotename, AdrFilename);
            string[] lines = File.ReadAllLines(fullPath);
            string[] AdrLines = File.ReadAllLines(AdrPath);
            foreach (var Line in AdrLines)
            {
                string[] split = Line.Split(",");
                if (split[12] == "Active")
                {
                    string[] datagridrow = { $"{split[2]}, {split[1]}", $"{split[3]}, {split[4]}", $"{split[5]}, {split[6]} {split[7]}", split[9], split[10] };
                    if (split[0] == "Sold-to")
                    {
                        appendCustRow(datagridrow, "Sold-to");
                    }
                    else if (split[0] == "Ship-to")
                    {
                        appendCustRow(datagridrow, "Ship-to");
                    }
                }
            }
            foreach (var Line in lines) 
            {
                string[] split = Line.Split(",");
                if (split[0] != "StyleNumber" && split[9] == "Active")
                {
                    string[] datagridrow = { split[6], split[5], split[3], split[8], split[7] };
                    appendRow(datagridrow);
                }
            }
        }

        public string[] readDataSheet()
        {
            string Filename = "Quote Masterlist.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] lines = File.ReadAllLines(fullPath);
            return lines;
        }

        public void createQuoteFolder(string quoteNumber)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes") + "/" + quoteNumber;
            Directory.CreateDirectory(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Quotename = label4.Text;
            string Status = "Sold-to";
            Form3 form3 = new Form3(Quotename, this, Status);
            form3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Quotename = label4.Text;
            Form4 form4 = new Form4(Quotename, this);
            form4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string Quotename = label4.Text;
            Form5 form5 = new Form5(Quotename, this);
            form5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Quotename = label4.Text;
            Form6 form6 = new Form6(Quotename, this);
            form6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Quotename = label4.Text;
            string Status = "Ship-to";
            Form3 form3 = new Form3(Quotename, this, Status);
            form3.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            string[] Quotes = readDataSheet();
            string LatestQuote = Quotes[Quotes.Length - 1];
            string[] parts = LatestQuote.Split(',');
            string OldQuoteNumber = parts[0];
            string OldQuoteTest = parts[1];
            bool partsTest = int.TryParse(OldQuoteNumber, out int n);
            if (!partsTest)
            {
                MessageBox.Show("Error: Quote Number is not a number");
                MessageBox.Show(OldQuoteNumber);
                return;
            }
            int IntQuoteNumber;
            string QuoteNumber;
            if (OldQuoteTest == "null")
            {
                IntQuoteNumber = n;
                QuoteNumber = "QDQ" + IntQuoteNumber.ToString();

            }
            else
            {
                IntQuoteNumber = n + 1;
                QuoteNumber = "QDQ" + IntQuoteNumber.ToString();
                createQuoteFolder(QuoteNumber);
                string QuoteFilename = QuoteNumber + ".csv";
                string Filename = "Quote Masterlist.csv";
                string AddressFilename = QuoteNumber + " Address.csv";
                string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
                string fullPath = Path.Combine(path, Filename);
                string newpath = Path.Combine(path, QuoteNumber, QuoteFilename);
                string adrpath = Path.Combine(path, QuoteNumber, AddressFilename);
                string newRow = $"{IntQuoteNumber},null";
                using (StreamWriter writer = new StreamWriter(fullPath, true))
                {
                    writer.WriteLine(newRow);
                }
                using (StreamWriter writer = new StreamWriter(newpath))
                {
                    writer.WriteLine("StyleNumber,ProductCode,Supplier,Description,Color,UnitofMeasure,Quantity,UnitPrice,UnitCost,Status");
                }
                using (StreamWriter writer = new StreamWriter(adrpath))
                {
                    writer.WriteLine("Type,FirstName,LastName,Address1,Address2,City,State,PostCode,County,Phone,Email,CustomerID,Status");
                }
            }
            label4.Text = QuoteNumber;
            
        }
        public string makeJSONstring(string Header, string Body)
        {
            string JSONobject = $"\"{Header}\": \"{Body}\"";
            return JSONobject;
        }

        public string makeJSONint(string Header, string Body)
        {
            string JSONobject = $"\"{Header}\": {Body}";
            return JSONobject;
        }

        public string encaseinBrackets(string Body)
        {
            string JSONobject = $"{{{Body}}}";
            return JSONobject;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string Filename = "Customer Data.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string[] strings = File.ReadAllLines(fullPath);
            Debug.WriteLine(strings[1]);
            string[] Split = strings[2].Split(",");
            foreach (var entry in Split)
            {
                Debug.WriteLine(entry);
            }
        }
        private void setupQuoteTable()
        {
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ColumnCount = 1;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.ColumnCount = 5;
            dataGridView3.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[0].FillWeight = 10;
            dataGridView3.Columns[0].Name = "Quantity";
            dataGridView3.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[1].FillWeight = 10;
            dataGridView3.Columns[1].Name = "UOM";
            dataGridView3.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[2].FillWeight = 50;
            dataGridView3.Columns[2].Name = "Description";
            dataGridView3.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[3].FillWeight = 15;
            dataGridView3.Columns[3].Name = "Cost";
            dataGridView3.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView3.Columns[4].FillWeight = 15;
            dataGridView3.Columns[4].Name = "Retail";
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void appendRow(string[] row)
        {
            if (dataGridView3.AllowUserToAddRows ? dataGridView3.Rows.Count - 1 == 0 : dataGridView3.Rows.Count == 0)
            {
                denullNewQuote();
            }
            dataGridView3.Rows.Add(row);
        }

        public void appendCustRow(string[] row, string Status)
        {
            if (dataGridView3.AllowUserToAddRows ? dataGridView3.Rows.Count - 1 == 0 : dataGridView3.Rows.Count == 0)
            {
                denullNewQuote();
            }
            if (Status == "Sold-to")
            {
                dataGridView1.Rows.Clear();
                foreach (string cell in row)
                {
                    
                    dataGridView1.Rows.Add(cell);
                }
            }
            else if (Status == "Ship-to")
            {
                dataGridView2.Rows.Clear();
                foreach (string cell in row)
                {
                    
                    dataGridView2.Rows.Add(cell);
                }
            }
        }
        public void denullNewQuote()
        {

            string Filename = "Quote Masterlist.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Filename);
            string quotenumber = label4.Text;
            int lastchar = quotenumber.Length - 1;
            string searchValue = quotenumber.Substring(lastchar, 1);
            Debug.WriteLine("searchvalue is " + searchValue);
            string[] lines = File.ReadAllLines(fullPath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(searchValue))
                {
                    lines[i] = searchValue + ",written";
                    break;
                }
            }
            File.WriteAllLines(fullPath, lines);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Quotename = label4.Text;
            Form7 form7 = new Form7(Quotename, this);
            form7.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string QuoteNumber = label4.Text;
            string DetailsFilename = QuoteNumber + " Details.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string newpath = Path.Combine(path, QuoteNumber, DetailsFilename);
            string Status = label5.Text;
            if (Status == "Currently set")
            {
                File.WriteAllText(newpath, string.Empty);
            }
            using (StreamWriter writer = new StreamWriter(newpath))
            {
                writer.WriteLine("Salesperson1,Salesperson2,InstallType");
            }
            Form8 form8 = new Form8(this);
            form8.Show();
        }

        public void SetJobDetails(string newRow)
        {
            string QuoteNumber = label4.Text;
            string DetailsFilename = QuoteNumber + " Details.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string newpath = Path.Combine(path, QuoteNumber, DetailsFilename);
            using (StreamWriter writer = new StreamWriter(newpath, true))
            {
                writer.WriteLine(newRow);
            }
            label5.Text = "Currently set";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string Quotename = label4.Text;
            string Filename = Quotename + " Address.csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Quotename, Filename);
            string[] lines = File.ReadAllLines(fullPath);
            foreach (string line in lines)
            {
                string[] split = line.Split(',');
                if (split[0] == "Sold-to" && split[12] == "Active")
                {
                    string[] datagridrow = { $"{split[2]}, {split[1]}", $"{split[3]}, {split[4]}", $"{split[5]}, {split[6]} {split[7]}", split[9], split[10] };
                    string newRow = $"Ship-to,{split[1]},{split[2]},{split[3]},{split[4]},{split[5]},{split[6]},{split[7]},{split[8]},{split[9]},{split[10]},{split[11]},Active";
                    appendCustRow(datagridrow, "Ship-to");
                    Filename = Quotename + " Address.csv";
                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
                    fullPath = Path.Combine(path, Quotename, Filename);
                    List<string> linesList = File.ReadAllLines(fullPath).ToList();

                    for (int i = 0; i < linesList.Count; i++)
                    {
                        string[] parts = linesList[i].Split(',');

                        if (parts[0] == "Ship-to" && parts.Length > 12 && parts[12] == "Active")
                        {
                            parts[12] = "Inactive"; // Modify the array directly
                            linesList[i] = string.Join(",", parts); // Reconstruct the line
                        }
                    }
                    linesList.Add(newRow);
                    File.WriteAllLines(fullPath, linesList);
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string Quotename = label4.Text;
          string Filename = Quotename + ".csv";
          string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
          string fullPath = Path.Combine(path, Quotename, Filename);
          string[] Lines = File.ReadAllLines(fullPath);
          List<Product> Products = new List<Product>();
            Random random = new Random();
            int randomNumber = random.Next(1000000, 10000000);
            Order order = new Order() 
            { 
                OrderDate = DateTime.Now.ToString("yyyyMMdd"),
                MeasureDate = DateTime.Now.ToString("yyyyMMdd"),
                PONumber = randomNumber.ToString(),
            };
            if (label5.Text == "Not currently set")
            {
                order.JobTypeID = getInstallType();
            }
            else
            {
                string Detailname = Quotename + " Details.csv";
                string Detailspath = Path.Combine(path, Quotename, Detailname);
                string[] Details = File.ReadAllLines(Detailspath);
                string[] s = Details[1].Split(",");
                order.SalesPerson1 = s[0];
                order.SalesPerson2 = s[1];
                order.JobTypeID = int.Parse(s[2]);
            }
            Filename = Quotename + " Address.csv";
            fullPath = Path.Combine(path, Quotename, Filename);
            string[] AddressLines = File.ReadAllLines(fullPath);
            bool ShipTest = false;
            bool SoldTest = false;
            foreach (string line in AddressLines) 
            {
                string[] split = line.Split(',');
                if (split[12] == "Active")
                {
                    if (split[0] == "Sold-to")
                    {
                        order.SoldToFirstName = split[1];
                        order.SoldToLastName = split[2];
                        order.SoldToAddress1 = split[3];
                        order.SoldToAddress2 = split[4];
                        order.SoldToCity = split[5];
                        order.SoldToState = split[6];
                        order.SoldToPostalCode = split[7];
                        order.SoldToCounty = split[8];
                        order.Phone1 = split[9];
                        order.Email = split[10];
                        order.CustomerID = int.Parse(split[11]);
                        SoldTest = true;
                    }
                    if (split[0] == "Ship-to")
                    {
                        order.ShipToFirstName = split[1];
                        order.ShipToLastName = split[2];
                        order.ShipToAddress1 = split[3];
                        order.ShipToAddress2 = split[4];
                        order.ShipToCity = split[5];
                        order.ShipToState = split[6];
                        order.ShipToPostalCode = split[7];
                        order.ShipToCounty = split[8];
                        order.Phone2 = split[9];
                        ShipTest = true;
                    }
                }
            }
            if (!ShipTest || !SoldTest)
            {
                MessageBox.Show("Error: Ship-to or Sold-to address not found");
                return;
            }
            foreach (string s in Lines)
          {
            string[] split = s.Split(',');
            if (split[0] != "StyleNumber" && split[9] == "Active")
            {
                    string StyleHeader = split[0].Substring(0, 2);
                    Product product = new Product()
                    {
                        ProductCode = split[1],
                        StyleNumber = split[0],
                        StyleName = split[3],
                        Quantity = double.Parse(split[6]),
                        RetailPrice = double.Parse(split[7]),
                        UnitCost = double.Parse(split[8]),
                        SalesUnits = split[5],
                        
                    };
                    if (StyleHeader != "QD")
                    {
                        product.Supplier = split[2];
                        product.ColorName = split[4];
                        product.BillQuantity = double.Parse(split[6]);
                        product.SupplierName = split[2];
                        product.SerialNumber = string.Empty;
                    }
                    if (split[1] == "1")
                    {
                        product.Width = 12;
                    }
                    Products.Add(product);
                }

          }
            order.Lines = Products;
            string json = JsonSerializer.Serialize(order, new JsonSerializerOptions { WriteIndented = true });
            Filename = Quotename+".JSON";
            fullPath = Path.Combine(path, Quotename, Filename);
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(json);
            }

        }
        public int getInstallType()
        {
            //Misc
            int Type = 59;
            string Quotename = label4.Text;
            string Filename = Quotename + ".csv";
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "QD Quotes");
            string fullPath = Path.Combine(path, Quotename, Filename);
            string[] Lines = File.ReadAllLines(fullPath);
            foreach (string s in Lines)
            {
                string[] split = s.Split(',');
                if (split[0] != "StyleNumber" && split[9] == "Active")
                {
                    if (split[1] == "1")
                    {
                        //Carpet
                        Type = 50;
                        return Type;
                    }
                    if (split[1] == "3")
                    {
                        //Hardwood
                        Type = 52;
                        return Type;
                    }
                    if (split[1] == "4")
                    {
                        //Laminate
                        Type = 53;
                        return Type;
                    }
                    if (split[1] == "6")
                    {
                        //Vinyl Plank
                        Type = 56;
                        return Type;
                    }
                    if (split[1] == "7")
                    {
                        //Vinyl Sheet
                        Type = 57;
                        return Type;
                    }
                    if (split[1] == "5")
                    {
                        //Tile
                        Type = 58;
                        return Type;
                    }
                }

            }
            return Type;
        }
    }
    class Product
    {
        public string ProductCode { get; set; } = string.Empty;
        public string RollItemNumber { get; set; } = string.Empty;
        public string? Supplier { get; set; } = null;
        public string StyleNumber { get; set; } = string.Empty;
        public string StyleName { get; set; } = string.Empty;
        public string? ColorName { get; set; } = null;
        public string SalesUnits { get; set; } = string.Empty;
        public string? SupplierName { get; set; } = null;
        public string? SerialNumber { get; set; } = null;
        public double BillQuantity { get; set; } = 0;
        public double Quantity { get; set; } = 0;
        public double RetailPrice { get; set; } = 0;
        public double UnitCost { get; set; } = 0;
        public double Width { get; set; } = 0.0;
        public double Length { get; set; } = 0.0;
    }
    class Order
    {
        public string Secret { get; set; } = "J8;389ZYiq60@e;maU71Dw$Lon0d253sS8aBC4d8HJ18@q1L";
        public int StoreNumber { get; set; } = 54;
        public int UserOrderTypeId { get; set; } = 0;
        public int JobTypeID { get; set; }
        public string OrderDate { get; set; } = string.Empty;
        public string MeasureDate { get; set; } = string.Empty;
        public int CustomerID { get; set; } = 0;
        public string SoldToFirstName { get; set; } = string.Empty;
        public string SoldToLastName { get; set; } = string.Empty;
        public string SoldToAddress1 { get; set; } = string.Empty;
        public string SoldToAddress2 { get; set; } = string.Empty;
        public string SoldToCity { get; set; } = string.Empty;
        public string SoldToState { get; set; } = string.Empty;
        public string SoldToPostalCode { get; set; } = string.Empty;
        public string? SoldToCounty { get; set; } = null;
        public string? JobNumber { get; set; } = null;
        public string PONumber { get; set; } = string.Empty;
        public string? Phone1 { get; set; } = null;
        public string? Phone2 { get; set; } = null;
        public string ShipToFirstName { get; set; } = string.Empty;
        public string ShipToLastName { get; set; } = string.Empty;
        public string ShipToAddress1 { get; set; } = string.Empty;
        public string ShipToAddress2 { get; set; } = string.Empty;
        public string ShipToCity { get; set; } = string.Empty;
        public string ShipToState { get; set; } = string.Empty;
        public string ShipToPostalCode { get; set; } = string.Empty;
        public string? ShipToCounty { get; set; } = null;
        public string SalesPerson1 { get; set; } = "DANA";
        public string? SalesPerson2 { get; set; } = null;
        public string? Email { get; set; } = null;
        public List<Product>? Lines { get; set; }
    }
}
