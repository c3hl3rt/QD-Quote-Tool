namespace Quality_Interiors_Quote_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Status = "new";
            Form2 form2 = new Form2(Status);
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
        }
    }
}
