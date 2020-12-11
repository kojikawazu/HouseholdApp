namespace HouseholdAcountApp.View
{
    partial class UpdateModelView
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
            this.label1 = new System.Windows.Forms.Label();
            this.ExpendComboBox = new System.Windows.Forms.ComboBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.ReceiveComboBox = new System.Windows.Forms.ComboBox();
            this.MoneyNameTextBox = new System.Windows.Forms.TextBox();
            this.MoneyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "支出/収入更新画面";
            // 
            // ExpendComboBox
            // 
            this.ExpendComboBox.FormattingEnabled = true;
            this.ExpendComboBox.Location = new System.Drawing.Point(63, 90);
            this.ExpendComboBox.Name = "ExpendComboBox";
            this.ExpendComboBox.Size = new System.Drawing.Size(150, 32);
            this.ExpendComboBox.TabIndex = 1;
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(271, 227);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(289, 32);
            this.TypeComboBox.TabIndex = 2;
            // 
            // ReceiveComboBox
            // 
            this.ReceiveComboBox.FormattingEnabled = true;
            this.ReceiveComboBox.Location = new System.Drawing.Point(271, 290);
            this.ReceiveComboBox.Name = "ReceiveComboBox";
            this.ReceiveComboBox.Size = new System.Drawing.Size(289, 32);
            this.ReceiveComboBox.TabIndex = 3;
            // 
            // MoneyNameTextBox
            // 
            this.MoneyNameTextBox.Location = new System.Drawing.Point(271, 175);
            this.MoneyNameTextBox.Name = "MoneyNameTextBox";
            this.MoneyNameTextBox.Size = new System.Drawing.Size(289, 31);
            this.MoneyNameTextBox.TabIndex = 4;
            // 
            // MoneyTextBox
            // 
            this.MoneyTextBox.Location = new System.Drawing.Point(271, 346);
            this.MoneyTextBox.Name = "MoneyTextBox";
            this.MoneyTextBox.Size = new System.Drawing.Size(289, 31);
            this.MoneyTextBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "実施日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "名前";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "ジャンル";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 290);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "支払方法";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 24);
            this.label6.TabIndex = 10;
            this.label6.Text = "金額";
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.Location = new System.Drawing.Point(308, 90);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(252, 31);
            this.DateTimePicker.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 49);
            this.button1.TabIndex = 12;
            this.button1.Text = "更新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdateModelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 516);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DateTimePicker);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MoneyTextBox);
            this.Controls.Add(this.MoneyNameTextBox);
            this.Controls.Add(this.ReceiveComboBox);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.ExpendComboBox);
            this.Controls.Add(this.label1);
            this.Name = "UpdateModelView";
            this.Text = "支出/収入の更新";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateModelView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ExpendComboBox;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.ComboBox ReceiveComboBox;
        private System.Windows.Forms.TextBox MoneyNameTextBox;
        private System.Windows.Forms.TextBox MoneyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Button button1;
    }
}