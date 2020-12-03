namespace wani1
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Main_Group = new System.Windows.Forms.Panel();
            this.challenge_button = new System.Windows.Forms.Button();
            this.learn_button = new System.Windows.Forms.Button();
            this.review_button = new System.Windows.Forms.Button();
            this.PictureBook = new System.Windows.Forms.PictureBox();
            this.Main_Group.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBook)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_Group
            // 
            this.Main_Group.AutoSize = true;
            this.Main_Group.Controls.Add(this.challenge_button);
            this.Main_Group.Controls.Add(this.learn_button);
            this.Main_Group.Controls.Add(this.review_button);
            this.Main_Group.Location = new System.Drawing.Point(293, 122);
            this.Main_Group.Name = "Main_Group";
            this.Main_Group.Size = new System.Drawing.Size(695, 493);
            this.Main_Group.TabIndex = 4;
            // 
            // challenge_button
            // 
            this.challenge_button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.challenge_button.Location = new System.Drawing.Point(139, 346);
            this.challenge_button.Name = "challenge_button";
            this.challenge_button.Size = new System.Drawing.Size(406, 58);
            this.challenge_button.TabIndex = 1;
            this.challenge_button.Text = "ちゃれんじもーど";
            this.challenge_button.UseVisualStyleBackColor = true;
            this.challenge_button.Click += new System.EventHandler(this.challenge_button_Click_1);
            // 
            // learn_button
            // 
            this.learn_button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.learn_button.Location = new System.Drawing.Point(139, 89);
            this.learn_button.Name = "learn_button";
            this.learn_button.Size = new System.Drawing.Size(406, 58);
            this.learn_button.TabIndex = 2;
            this.learn_button.Text = "ようじむけ";
            this.learn_button.UseVisualStyleBackColor = true;
            this.learn_button.Click += new System.EventHandler(this.learn_button_Click_1);
            // 
            // review_button
            // 
            this.review_button.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.review_button.Location = new System.Drawing.Point(139, 211);
            this.review_button.Name = "review_button";
            this.review_button.Size = new System.Drawing.Size(406, 58);
            this.review_button.TabIndex = 3;
            this.review_button.Text = "しょうがくせいむけ";
            this.review_button.UseVisualStyleBackColor = true;
            this.review_button.Click += new System.EventHandler(this.review_button_Click_1);
            // 
            // PictureBook
            // 
            this.PictureBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBook.BackColor = System.Drawing.Color.White;
            this.PictureBook.Image = ((System.Drawing.Image)(resources.GetObject("PictureBook.Image")));
            this.PictureBook.Location = new System.Drawing.Point(1188, 605);
            this.PictureBook.Name = "PictureBook";
            this.PictureBook.Size = new System.Drawing.Size(64, 64);
            this.PictureBook.TabIndex = 5;
            this.PictureBook.TabStop = false;
            this.PictureBook.Click += new System.EventHandler(this.PictureBook_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.PictureBook);
            this.Controls.Add(this.Main_Group);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Main_Group.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel Main_Group;
        private System.Windows.Forms.Button challenge_button;
        private System.Windows.Forms.Button learn_button;
        private System.Windows.Forms.Button review_button;
        private System.Windows.Forms.PictureBox PictureBook;
    }
}

