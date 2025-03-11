namespace Quality_Interiors_Quote_Tool
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            label2 = new Label();
            button3 = new Button();
            button4 = new Button();
            dataGridView3 = new DataGridView();
            label3 = new Label();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            button8 = new Button();
            label4 = new Label();
            button10 = new Button();
            label5 = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(label1, 2, 1);
            tableLayoutPanel1.Controls.Add(button1, 1, 2);
            tableLayoutPanel1.Controls.Add(button2, 1, 3);
            tableLayoutPanel1.Controls.Add(dataGridView1, 2, 2);
            tableLayoutPanel1.Controls.Add(dataGridView2, 5, 2);
            tableLayoutPanel1.Controls.Add(label2, 6, 1);
            tableLayoutPanel1.Controls.Add(button3, 7, 2);
            tableLayoutPanel1.Controls.Add(button4, 7, 3);
            tableLayoutPanel1.Controls.Add(dataGridView3, 2, 7);
            tableLayoutPanel1.Controls.Add(label3, 2, 6);
            tableLayoutPanel1.Controls.Add(button5, 2, 9);
            tableLayoutPanel1.Controls.Add(button6, 4, 9);
            tableLayoutPanel1.Controls.Add(button7, 3, 9);
            tableLayoutPanel1.Controls.Add(button8, 6, 9);
            tableLayoutPanel1.Controls.Add(label4, 6, 6);
            tableLayoutPanel1.Controls.Add(button10, 4, 2);
            tableLayoutPanel1.Controls.Add(label5, 4, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 11;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.66666651F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.66666651F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.66666651F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.333333F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.66666651F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.66666651F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.66666651F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 6.66666651F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(966, 542);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(155, 20);
            label1.Name = "label1";
            label1.Size = new Size(126, 33);
            label1.TabIndex = 0;
            label1.Text = "Customer Info";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(23, 56);
            button1.Name = "button1";
            button1.Size = new Size(126, 27);
            button1.TabIndex = 1;
            button1.Text = "New...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(23, 89);
            button2.Name = "button2";
            button2.Size = new Size(126, 27);
            button2.TabIndex = 2;
            button2.Text = "Existing...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dataGridView1, 2);
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(155, 56);
            dataGridView1.Name = "dataGridView1";
            tableLayoutPanel1.SetRowSpan(dataGridView1, 4);
            dataGridView1.Size = new Size(258, 159);
            dataGridView1.TabIndex = 3;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dataGridView2, 2);
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(551, 56);
            dataGridView2.Name = "dataGridView2";
            tableLayoutPanel1.SetRowSpan(dataGridView2, 4);
            dataGridView2.Size = new Size(258, 159);
            dataGridView2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(683, 20);
            label2.Name = "label2";
            label2.Size = new Size(126, 33);
            label2.TabIndex = 5;
            label2.Text = "Delivering to";
            label2.TextAlign = ContentAlignment.BottomRight;
            // 
            // button3
            // 
            button3.Dock = DockStyle.Fill;
            button3.Location = new Point(815, 56);
            button3.Name = "button3";
            button3.Size = new Size(126, 27);
            button3.TabIndex = 6;
            button3.Text = "New...";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Dock = DockStyle.Fill;
            button4.Location = new Point(815, 89);
            button4.Name = "button4";
            button4.Size = new Size(126, 27);
            button4.TabIndex = 7;
            button4.Text = "Customer";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel1.SetColumnSpan(dataGridView3, 5);
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView3.Location = new Point(155, 254);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.Size = new Size(654, 194);
            dataGridView3.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(155, 218);
            label3.Name = "label3";
            label3.Size = new Size(126, 33);
            label3.TabIndex = 9;
            label3.Text = "Quote Summary";
            label3.TextAlign = ContentAlignment.BottomLeft;
            // 
            // button5
            // 
            button5.Dock = DockStyle.Fill;
            button5.Location = new Point(155, 487);
            button5.Name = "button5";
            button5.Size = new Size(126, 27);
            button5.TabIndex = 10;
            button5.Text = "Add Material";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Dock = DockStyle.Fill;
            button6.Location = new Point(419, 487);
            button6.Name = "button6";
            button6.Size = new Size(126, 27);
            button6.TabIndex = 11;
            button6.Text = "Add Labor";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Dock = DockStyle.Fill;
            button7.Location = new Point(287, 487);
            button7.Name = "button7";
            button7.Size = new Size(126, 27);
            button7.TabIndex = 12;
            button7.Text = "Add Custom Labor";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // button8
            // 
            button8.Dock = DockStyle.Fill;
            button8.Location = new Point(683, 487);
            button8.Name = "button8";
            button8.Size = new Size(126, 27);
            button8.TabIndex = 13;
            button8.Text = "Send to RFMS";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Location = new Point(683, 218);
            label4.Name = "label4";
            label4.Size = new Size(126, 33);
            label4.TabIndex = 14;
            label4.TextAlign = ContentAlignment.BottomRight;
            // 
            // button10
            // 
            button10.Location = new Point(419, 56);
            button10.Name = "button10";
            button10.Size = new Size(126, 27);
            button10.TabIndex = 16;
            button10.Text = "Set Order Details";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(419, 86);
            label5.Name = "label5";
            label5.Size = new Size(126, 33);
            label5.TabIndex = 17;
            label5.Text = "Not currently set";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 542);
            Controls.Add(tableLayoutPanel1);
            Name = "Form2";
            Text = "Form2";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label label2;
        private Button button3;
        private Button button4;
        private DataGridView dataGridView3;
        private Label label3;
        private Button button5;
        private Button button6;
        private Button button7;
        private Button button8;
        private Label label4;
        private Button button10;
        private Label label5;
    }
}