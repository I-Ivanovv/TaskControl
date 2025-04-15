namespace TaskControl
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            CBCat = new ComboBox();
            CBPrio = new ComboBox();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            TBDueDate = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            TBPhone = new TextBox();
            TBAge = new TextBox();
            TBLastName = new TextBox();
            button2 = new Button();
            TBFirstName = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button1 = new Button();
            TBTask = new TextBox();
            label11 = new Label();
            tabPage2 = new TabPage();
            TBKeyword = new TextBox();
            listBox1 = new ListBox();
            label3 = new Label();
            button3 = new Button();
            tabPage3 = new TabPage();
            button4 = new Button();
            label5 = new Label();
            label4 = new Label();
            listBox3 = new ListBox();
            listBox2 = new ListBox();
            tabPage4 = new TabPage();
            label7 = new Label();
            label6 = new Label();
            listBox5 = new ListBox();
            listBox4 = new ListBox();
            button6 = new Button();
            button5 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 12F);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(940, 410);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(CBCat);
            tabPage1.Controls.Add(CBPrio);
            tabPage1.Controls.Add(label15);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(TBDueDate);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(TBPhone);
            tabPage1.Controls.Add(TBAge);
            tabPage1.Controls.Add(TBLastName);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(TBFirstName);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(TBTask);
            tabPage1.Controls.Add(label11);
            tabPage1.Location = new Point(4, 37);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(932, 369);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Create Tasks and People";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // CBCat
            // 
            CBCat.FormattingEnabled = true;
            CBCat.Items.AddRange(new object[] { "Work", "Personal", "Home" });
            CBCat.Location = new Point(121, 184);
            CBCat.Name = "CBCat";
            CBCat.Size = new Size(288, 36);
            CBCat.TabIndex = 21;
            // 
            // CBPrio
            // 
            CBPrio.FormattingEnabled = true;
            CBPrio.Items.AddRange(new object[] { "Low", "Medium", "High" });
            CBPrio.Location = new Point(121, 127);
            CBPrio.Name = "CBPrio";
            CBPrio.Size = new Size(288, 36);
            CBPrio.TabIndex = 20;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 13F);
            label15.Location = new Point(9, 236);
            label15.Name = "label15";
            label15.Size = new Size(108, 30);
            label15.TabIndex = 19;
            label15.Text = "Due Date:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 13F);
            label14.Location = new Point(9, 184);
            label14.Name = "label14";
            label14.Size = new Size(107, 30);
            label14.TabIndex = 18;
            label14.Text = "Category:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 13F);
            label13.Location = new Point(28, 129);
            label13.Name = "label13";
            label13.Size = new Size(87, 30);
            label13.TabIndex = 17;
            label13.Text = "Priority:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13F);
            label12.Location = new Point(56, 78);
            label12.Name = "label12";
            label12.Size = new Size(59, 30);
            label12.TabIndex = 16;
            label12.Text = "Task:";
            // 
            // TBDueDate
            // 
            TBDueDate.Location = new Point(121, 236);
            TBDueDate.Multiline = true;
            TBDueDate.Name = "TBDueDate";
            TBDueDate.Size = new Size(288, 30);
            TBDueDate.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13F);
            label10.Location = new Point(587, 181);
            label10.Name = "label10";
            label10.Size = new Size(57, 30);
            label10.TabIndex = 11;
            label10.Text = "Age:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13F);
            label9.Location = new Point(525, 129);
            label9.Name = "label9";
            label9.Size = new Size(119, 30);
            label9.TabIndex = 10;
            label9.Text = "Last Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13F);
            label8.Location = new Point(522, 73);
            label8.Name = "label8";
            label8.Size = new Size(122, 30);
            label8.TabIndex = 9;
            label8.Text = "First Name:";
            // 
            // TBPhone
            // 
            TBPhone.Location = new Point(650, 236);
            TBPhone.Name = "TBPhone";
            TBPhone.Size = new Size(264, 34);
            TBPhone.TabIndex = 8;
            // 
            // TBAge
            // 
            TBAge.Location = new Point(650, 184);
            TBAge.Name = "TBAge";
            TBAge.Size = new Size(264, 34);
            TBAge.TabIndex = 7;
            // 
            // TBLastName
            // 
            TBLastName.Location = new Point(650, 132);
            TBLastName.Name = "TBLastName";
            TBLastName.Size = new Size(264, 34);
            TBLastName.TabIndex = 6;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button2.Location = new Point(495, 298);
            button2.Name = "button2";
            button2.Size = new Size(419, 70);
            button2.TabIndex = 5;
            button2.Text = "Add Person";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // TBFirstName
            // 
            TBFirstName.Location = new Point(650, 73);
            TBFirstName.Multiline = true;
            TBFirstName.Name = "TBFirstName";
            TBFirstName.Size = new Size(264, 30);
            TBFirstName.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.Location = new Point(576, 18);
            label2.Name = "label2";
            label2.Size = new Size(266, 37);
            label2.TabIndex = 3;
            label2.Text = "Person Information";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(98, 18);
            label1.Name = "label1";
            label1.Size = new Size(235, 37);
            label1.TabIndex = 2;
            label1.Text = "Task Information";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button1.Location = new Point(9, 298);
            button1.Name = "button1";
            button1.Size = new Size(400, 70);
            button1.TabIndex = 1;
            button1.Text = "Create Task";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // TBTask
            // 
            TBTask.Location = new Point(121, 78);
            TBTask.Multiline = true;
            TBTask.Name = "TBTask";
            TBTask.Size = new Size(288, 30);
            TBTask.TabIndex = 0;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13F);
            label11.Location = new Point(483, 233);
            label11.Name = "label11";
            label11.Size = new Size(161, 30);
            label11.TabIndex = 12;
            label11.Text = "Phone number:";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(TBKeyword);
            tabPage2.Controls.Add(listBox1);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(button3);
            tabPage2.Location = new Point(4, 37);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(932, 369);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Search Tasks";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // TBKeyword
            // 
            TBKeyword.Location = new Point(206, 24);
            TBKeyword.Multiline = true;
            TBKeyword.Name = "TBKeyword";
            TBKeyword.Size = new Size(234, 30);
            TBKeyword.TabIndex = 3;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 28;
            listBox1.Location = new Point(465, 17);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(459, 340);
            listBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F);
            label3.Location = new Point(8, 17);
            label3.Name = "label3";
            label3.Size = new Size(192, 37);
            label3.TabIndex = 1;
            label3.Text = "Enter keyword:";
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 20F);
            button3.Location = new Point(53, 148);
            button3.Name = "button3";
            button3.Size = new Size(360, 129);
            button3.TabIndex = 0;
            button3.Text = "Search Task";
            button3.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(button4);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(listBox3);
            tabPage3.Controls.Add(listBox2);
            tabPage3.Location = new Point(4, 37);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(932, 369);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Assign Task to Person";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button4.Location = new Point(378, 156);
            button4.Name = "button4";
            button4.Size = new Size(177, 75);
            button4.TabIndex = 4;
            button4.Text = "Assign Task";
            button4.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label5.Location = new Point(670, 14);
            label5.Name = "label5";
            label5.Size = new Size(188, 37);
            label5.TabIndex = 3;
            label5.Text = "Select Person";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.Location = new Point(81, 14);
            label4.Name = "label4";
            label4.Size = new Size(157, 37);
            label4.TabIndex = 2;
            label4.Text = "Select Task";
            // 
            // listBox3
            // 
            listBox3.FormattingEnabled = true;
            listBox3.ItemHeight = 28;
            listBox3.Location = new Point(599, 65);
            listBox3.Name = "listBox3";
            listBox3.Size = new Size(325, 284);
            listBox3.TabIndex = 1;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 28;
            listBox2.Location = new Point(8, 65);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(325, 284);
            listBox2.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(label7);
            tabPage4.Controls.Add(label6);
            tabPage4.Controls.Add(listBox5);
            tabPage4.Controls.Add(listBox4);
            tabPage4.Controls.Add(button6);
            tabPage4.Controls.Add(button5);
            tabPage4.Location = new Point(4, 37);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(932, 369);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Remove Task or Person";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label7.Location = new Point(663, 19);
            label7.Name = "label7";
            label7.Size = new Size(188, 37);
            label7.TabIndex = 5;
            label7.Text = "Select Person";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label6.Location = new Point(93, 19);
            label6.Name = "label6";
            label6.Size = new Size(157, 37);
            label6.TabIndex = 4;
            label6.Text = "Select Task";
            // 
            // listBox5
            // 
            listBox5.FormattingEnabled = true;
            listBox5.ItemHeight = 28;
            listBox5.Location = new Point(581, 73);
            listBox5.Name = "listBox5";
            listBox5.Size = new Size(343, 200);
            listBox5.TabIndex = 3;
            // 
            // listBox4
            // 
            listBox4.FormattingEnabled = true;
            listBox4.ItemHeight = 28;
            listBox4.Location = new Point(8, 73);
            listBox4.Name = "listBox4";
            listBox4.Size = new Size(343, 200);
            listBox4.TabIndex = 2;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button6.Location = new Point(581, 319);
            button6.Name = "button6";
            button6.Size = new Size(343, 49);
            button6.TabIndex = 1;
            button6.Text = "Remove Person";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            button5.Location = new Point(8, 319);
            button5.Name = "button5";
            button5.Size = new Size(343, 49);
            button5.TabIndex = 0;
            button5.Text = "Remove Task";
            button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 410);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Button button1;
        private TextBox TBTask;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private Button button2;
        private TextBox TBFirstName;
        private Label label2;
        private TextBox TBKeyword;
        private ListBox listBox1;
        private Label label3;
        private Button button3;
        private Button button4;
        private Label label5;
        private Label label4;
        private ListBox listBox3;
        private ListBox listBox2;
        private Label label7;
        private Label label6;
        private ListBox listBox5;
        private ListBox listBox4;
        private Button button6;
        private Button button5;
        private Label label12;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox TBPhone;
        private TextBox TBAge;
        private TextBox TBLastName;
        private Label label11;
        private Label label15;
        private Label label14;
        private Label label13;
        private TextBox TBDueDate;
        private ComboBox CBCat;
        private ComboBox CBPrio;
    }
}
