namespace wani1
{
    partial class Learn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Learn));
            this.Learn_Group = new System.Windows.Forms.GroupBox();
            this.comboKinds = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.learn_back_button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wani_block = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_title = new System.Windows.Forms.Label();
            this.Learn_Group.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wani_block)).BeginInit();
            this.SuspendLayout();
            // 
            // Learn_Group
            // 
            this.Learn_Group.BackColor = System.Drawing.Color.Transparent;
            this.Learn_Group.Controls.Add(this.comboKinds);
            this.Learn_Group.Controls.Add(this.panel2);
            this.Learn_Group.Controls.Add(this.panel1);
            this.Learn_Group.Controls.Add(this.textBox2);
            this.Learn_Group.Location = new System.Drawing.Point(12, 12);
            this.Learn_Group.Name = "Learn_Group";
            this.Learn_Group.Size = new System.Drawing.Size(1240, 657);
            this.Learn_Group.TabIndex = 3;
            this.Learn_Group.TabStop = false;
            // 
            // comboKinds
            // 
            this.comboKinds.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboKinds.FormattingEnabled = true;
            this.comboKinds.Items.AddRange(new object[] {
            "くりかえし",
            "～するとき",
            "～する"});
            this.comboKinds.Location = new System.Drawing.Point(7, 66);
            this.comboKinds.Name = "comboKinds";
            this.comboKinds.Size = new System.Drawing.Size(340, 32);
            this.comboKinds.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label_title);
            this.panel2.Controls.Add(this.learn_back_button);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(6, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1219, 39);
            this.panel2.TabIndex = 3;
            // 
            // learn_back_button
            // 
            this.learn_back_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.learn_back_button.Location = new System.Drawing.Point(292, -1);
            this.learn_back_button.Name = "learn_back_button";
            this.learn_back_button.Size = new System.Drawing.Size(75, 40);
            this.learn_back_button.TabIndex = 1;
            this.learn_back_button.Text = "もどる";
            this.learn_back_button.UseVisualStyleBackColor = true;
            this.learn_back_button.Click += new System.EventHandler(this.learn_back_button_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 40);
            this.button1.TabIndex = 4;
            this.button1.Text = "すたーと";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.wani_block);
            this.panel1.Location = new System.Drawing.Point(353, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 593);
            this.panel1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(719, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "さいしょから";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(4, 451);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(613, 135);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(607, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = ">";
            // 
            // wani_block
            // 
            this.wani_block.Image = ((System.Drawing.Image)(resources.GetObject("wani_block.Image")));
            this.wani_block.Location = new System.Drawing.Point(29, 26);
            this.wani_block.Name = "wani_block";
            this.wani_block.Size = new System.Drawing.Size(294, 355);
            this.wani_block.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.wani_block.TabIndex = 0;
            this.wani_block.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(7, 65);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(340, 586);
            this.textBox2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(19, 675);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 5;
            this.panel3.Visible = false;
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label_title.Location = new System.Drawing.Point(373, 6);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(0, 24);
            this.label_title.TabIndex = 7;
            // 
            // Learn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Learn_Group);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Learn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "がくしゅうもーど";
            this.Load += new System.EventHandler(this.Learn_Load);
            this.Learn_Group.ResumeLayout(false);
            this.Learn_Group.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wani_block)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Learn_Group;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button learn_back_button;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboKinds;
        private System.Windows.Forms.PictureBox wani_block;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label_title;
    }
}