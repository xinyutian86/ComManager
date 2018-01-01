namespace ComManager
{
    partial class Form13
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
        //    private void InitializeComponent()
        //    {
        //        this.label1 = new System.Windows.Forms.Label();
        //        this.label2 = new System.Windows.Forms.Label();
        //        this.textBox1 = new System.Windows.Forms.TextBox();
        //        this.textBox2 = new System.Windows.Forms.TextBox();
        //        this.button1 = new System.Windows.Forms.Button();
        //        this.button2 = new System.Windows.Forms.Button();
        //        this.SuspendLayout();
        //        // 
        //        // label1
        //        // 
        //        this.label1.AutoSize = true;
        //        this.label1.Location = new System.Drawing.Point(55, 34);
        //        this.label1.Name = "label1";
        //        this.label1.Size = new System.Drawing.Size(53, 12);
        //        this.label1.TabIndex = 0;
        //        this.label1.Text = "类别名称";
        //        // 
        //        // label2
        //        // 
        //        this.label2.AutoSize = true;
        //        this.label2.Location = new System.Drawing.Point(55, 84);
        //        this.label2.Name = "label2";
        //        this.label2.Size = new System.Drawing.Size(53, 12);
        //        this.label2.TabIndex = 1;
        //        this.label2.Text = "隶属关系";
        //        // 
        //        // textBox1
        //        // 
        //        this.textBox1.Location = new System.Drawing.Point(129, 33);
        //        this.textBox1.Name = "textBox1";
        //        this.textBox1.Size = new System.Drawing.Size(143, 21);
        //        this.textBox1.TabIndex = 2;
        //        // 
        //        // textBox2
        //        // 
        //        this.textBox2.Location = new System.Drawing.Point(129, 75);
        //        this.textBox2.Name = "textBox2";
        //        this.textBox2.Size = new System.Drawing.Size(143, 21);
        //        this.textBox2.TabIndex = 3;
        //        // 
        //        // button1
        //        // 
        //        this.button1.Location = new System.Drawing.Point(57, 144);
        //        this.button1.Name = "button1";
        //        this.button1.Size = new System.Drawing.Size(75, 23);
        //        this.button1.TabIndex = 4;
        //        this.button1.Text = "确定";
        //        this.button1.UseVisualStyleBackColor = true;
        //        // 
        //        // button2
        //        // 
        //        this.button2.Location = new System.Drawing.Point(197, 144);
        //        this.button2.Name = "button2";
        //        this.button2.Size = new System.Drawing.Size(75, 23);
        //        this.button2.TabIndex = 5;
        //        this.button2.Text = "取消";
        //        this.button2.UseVisualStyleBackColor = true;
        //        // 
        //        // Form13
        //        // 
        //        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //        this.ClientSize = new System.Drawing.Size(341, 193);
        //        this.Controls.Add(this.button2);
        //        this.Controls.Add(this.button1);
        //        this.Controls.Add(this.textBox2);
        //        this.Controls.Add(this.textBox1);
        //        this.Controls.Add(this.label2);
        //        this.Controls.Add(this.label1);
        //        this.Name = "Form13";
        //        this.Text = "客户类别添加";
        //        this.ResumeLayout(false);
        //        this.PerformLayout();

        //    }

        //    #endregion

        //    private System.Windows.Forms.Label label1;
        //    private System.Windows.Forms.Label label2;
        //    private System.Windows.Forms.TextBox textBox1;
        //    private System.Windows.Forms.TextBox textBox2;
        //    private System.Windows.Forms.Button button1;
        //    private System.Windows.Forms.Button button2;
        //}
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typename = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类别名称";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "隶属关系";
            // 
            // typename
            // 
            this.typename.Location = new System.Drawing.Point(111, 65);
            this.typename.Name = "typename";
            this.typename.Size = new System.Drawing.Size(191, 21);
            this.typename.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(192, 226);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(111, 113);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 20);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(111, 149);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(191, 20);
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(110, 183);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(192, 20);
            this.comboBox3.TabIndex = 8;
            // 
            // Form13
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 263);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.typename);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form13";
            this.Text = "添加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox typename;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox3;
    }
}