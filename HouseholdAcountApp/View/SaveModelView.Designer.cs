namespace HouseholdAcountApp.View
{
    partial class SaveModelView
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
            this.DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ExpendComboBox = new System.Windows.Forms.ComboBox();
            this.name = new System.Windows.Forms.Label();
            this.tag = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.yens = new System.Windows.Forms.Label();
            this.MoneyNameTextBox = new System.Windows.Forms.TextBox();
            this.MoneyTextBox = new System.Windows.Forms.TextBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.ReceiveComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.CustomFormat = "yyyy/mm/dd";
            this.DateTimePicker.Location = new System.Drawing.Point(316, 93);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(272, 31);
            this.DateTimePicker.TabIndex = 1;
            this.DateTimePicker.Value = new System.DateTime(2020, 11, 11, 0, 0, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "実施日";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "購入or支払";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "収入/支出入力画面";
            // 
            // ExpendComboBox
            // 
            this.ExpendComboBox.FormattingEnabled = true;
            this.ExpendComboBox.Location = new System.Drawing.Point(49, 92);
            this.ExpendComboBox.Name = "ExpendComboBox";
            this.ExpendComboBox.Size = new System.Drawing.Size(158, 32);
            this.ExpendComboBox.TabIndex = 6;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(49, 180);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(58, 24);
            this.name.TabIndex = 7;
            this.name.Text = "名前";
            // 
            // tag
            // 
            this.tag.AutoSize = true;
            this.tag.Location = new System.Drawing.Point(49, 236);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(84, 24);
            this.tag.TabIndex = 8;
            this.tag.Text = "ジャンル";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 293);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "支払い方法";
            // 
            // yens
            // 
            this.yens.AutoSize = true;
            this.yens.Location = new System.Drawing.Point(53, 353);
            this.yens.Name = "yens";
            this.yens.Size = new System.Drawing.Size(58, 24);
            this.yens.TabIndex = 10;
            this.yens.Text = "金額";
            // 
            // MoneyNameTextBox
            // 
            this.MoneyNameTextBox.Location = new System.Drawing.Point(280, 180);
            this.MoneyNameTextBox.Name = "MoneyNameTextBox";
            this.MoneyNameTextBox.Size = new System.Drawing.Size(308, 31);
            this.MoneyNameTextBox.TabIndex = 11;
            // 
            // MoneyTextBox
            // 
            this.MoneyTextBox.Location = new System.Drawing.Point(280, 350);
            this.MoneyTextBox.Name = "MoneyTextBox";
            this.MoneyTextBox.Size = new System.Drawing.Size(308, 31);
            this.MoneyTextBox.TabIndex = 11;
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(280, 236);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(308, 32);
            this.TypeComboBox.TabIndex = 12;
            // 
            // ReceiveComboBox
            // 
            this.ReceiveComboBox.FormattingEnabled = true;
            this.ReceiveComboBox.Location = new System.Drawing.Point(280, 293);
            this.ReceiveComboBox.Name = "ReceiveComboBox";
            this.ReceiveComboBox.Size = new System.Drawing.Size(308, 32);
            this.ReceiveComboBox.TabIndex = 12;
            // 
            // SaveModelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 528);
            this.Controls.Add(this.ReceiveComboBox);
            this.Controls.Add(this.TypeComboBox);
            this.Controls.Add(this.MoneyTextBox);
            this.Controls.Add(this.MoneyNameTextBox);
            this.Controls.Add(this.yens);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tag);
            this.Controls.Add(this.name);
            this.Controls.Add(this.ExpendComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DateTimePicker);
            this.Name = "SaveModelView";
            this.Text = "支出/収入の追加";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker DateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ExpendComboBox;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label tag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label yens;
        private System.Windows.Forms.TextBox MoneyNameTextBox;
        private System.Windows.Forms.TextBox MoneyTextBox;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.ComboBox ReceiveComboBox;
    }
}