namespace wani1
{
    partial class Challenge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Challenge));
            this.Challenge_Group = new System.Windows.Forms.GroupBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.challenge_back_button = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listView3 = new System.Windows.Forms.ListView();
            this.Challenge_Group.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // Challenge_Group
            // 
            this.Challenge_Group.Controls.Add(this.panel6);
            this.Challenge_Group.Controls.Add(this.panel7);
            this.Challenge_Group.Controls.Add(this.label7);
            this.Challenge_Group.Controls.Add(this.listView3);
            this.Challenge_Group.Location = new System.Drawing.Point(12, 12);
            this.Challenge_Group.Name = "Challenge_Group";
            this.Challenge_Group.Size = new System.Drawing.Size(1240, 657);
            this.Challenge_Group.TabIndex = 6;
            this.Challenge_Group.TabStop = false;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.Controls.Add(this.challenge_back_button);
            this.panel6.Controls.Add(this.textBox4);
            this.panel6.Controls.Add(this.button4);
            this.panel6.Location = new System.Drawing.Point(6, 19);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1219, 39);
            this.panel6.TabIndex = 3;
            // 
            // challenge_back_button
            // 
            this.challenge_back_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.challenge_back_button.Location = new System.Drawing.Point(292, -1);
            this.challenge_back_button.Name = "challenge_back_button";
            this.challenge_back_button.Size = new System.Drawing.Size(75, 40);
            this.challenge_back_button.TabIndex = 1;
            this.challenge_back_button.Text = "もどる";
            this.challenge_back_button.UseVisualStyleBackColor = true;
            this.challenge_back_button.Click += new System.EventHandler(this.challenge_back_button_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox4.Location = new System.Drawing.Point(373, 0);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(846, 39);
            this.textBox4.TabIndex = 5;
            this.textBox4.Text = "――――――――――――――ここが問題文―――――――――――[時間]";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Default;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(0, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 40);
            this.button4.TabIndex = 4;
            this.button4.Text = "すたーと";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.label6);
            this.panel7.Location = new System.Drawing.Point(379, 64);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(846, 593);
            this.panel7.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(58, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(330, 37);
            this.label8.TabIndex = 1;
            this.label8.Text = "ちゃれんじもーど画面";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(294, 232);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "ここが組み立て部分";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(66, 296);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "ここが部品選択";
            // 
            // listView3
            // 
            this.listView3.HideSelection = false;
            this.listView3.Location = new System.Drawing.Point(6, 64);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(316, 587);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // Challenge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.Challenge_Group);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Challenge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ちゃれんじもーど";
            this.Load += new System.EventHandler(this.Challenge_Load);
            this.Challenge_Group.ResumeLayout(false);
            this.Challenge_Group.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Challenge_Group;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button challenge_back_button;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listView3;
    }
}