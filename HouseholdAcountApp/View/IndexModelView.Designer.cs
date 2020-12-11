namespace HouseholdAcountApp
{
    partial class IndexModelView
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.select_button = new System.Windows.Forms.Button();
            this.daimei = new System.Windows.Forms.Label();
            this.add_button = new System.Windows.Forms.Button();
            this.homeViewGrid = new System.Windows.Forms.DataGridView();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.monthComboBox = new System.Windows.Forms.ComboBox();
            this.dayComboBox = new System.Windows.Forms.ComboBox();
            this.ExpendComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.alSelect_button = new System.Windows.Forms.Button();
            this.update_button = new System.Windows.Forms.Button();
            this.delete_button = new System.Windows.Forms.Button();
            this.mirror_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.balance_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.homeViewGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "年";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(369, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "月";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(545, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "日";
            // 
            // select_button
            // 
            this.select_button.Location = new System.Drawing.Point(1072, 123);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(167, 41);
            this.select_button.TabIndex = 2;
            this.select_button.Text = "検索";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.select_button_Click);
            // 
            // daimei
            // 
            this.daimei.AutoSize = true;
            this.daimei.Location = new System.Drawing.Point(91, 53);
            this.daimei.Name = "daimei";
            this.daimei.Size = new System.Drawing.Size(190, 24);
            this.daimei.TabIndex = 3;
            this.daimei.Text = "支出/収入一覧表";
            // 
            // add_button
            // 
            this.add_button.Location = new System.Drawing.Point(1273, 62);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(167, 41);
            this.add_button.TabIndex = 4;
            this.add_button.Text = "追加";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // homeViewGrid
            // 
            this.homeViewGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.homeViewGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.homeViewGrid.Location = new System.Drawing.Point(0, 210);
            this.homeViewGrid.Name = "homeViewGrid";
            this.homeViewGrid.RowHeadersWidth = 82;
            this.homeViewGrid.RowTemplate.Height = 33;
            this.homeViewGrid.Size = new System.Drawing.Size(1751, 669);
            this.homeViewGrid.TabIndex = 5;
            // 
            // yearComboBox
            // 
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Location = new System.Drawing.Point(33, 135);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(139, 32);
            this.yearComboBox.TabIndex = 6;
            // 
            // monthComboBox
            // 
            this.monthComboBox.FormattingEnabled = true;
            this.monthComboBox.Location = new System.Drawing.Point(228, 135);
            this.monthComboBox.Name = "monthComboBox";
            this.monthComboBox.Size = new System.Drawing.Size(122, 32);
            this.monthComboBox.TabIndex = 7;
            // 
            // dayComboBox
            // 
            this.dayComboBox.FormattingEnabled = true;
            this.dayComboBox.Location = new System.Drawing.Point(418, 137);
            this.dayComboBox.Name = "dayComboBox";
            this.dayComboBox.Size = new System.Drawing.Size(121, 32);
            this.dayComboBox.TabIndex = 8;
            // 
            // ExpendComboBox
            // 
            this.ExpendComboBox.FormattingEnabled = true;
            this.ExpendComboBox.Location = new System.Drawing.Point(595, 137);
            this.ExpendComboBox.Name = "ExpendComboBox";
            this.ExpendComboBox.Size = new System.Drawing.Size(121, 32);
            this.ExpendComboBox.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(734, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "収入/支出";
            // 
            // alSelect_button
            // 
            this.alSelect_button.Location = new System.Drawing.Point(1072, 64);
            this.alSelect_button.Name = "alSelect_button";
            this.alSelect_button.Size = new System.Drawing.Size(167, 38);
            this.alSelect_button.TabIndex = 11;
            this.alSelect_button.Text = "全選択";
            this.alSelect_button.UseVisualStyleBackColor = true;
            this.alSelect_button.Click += new System.EventHandler(this.alSelect_button_Click);
            // 
            // update_button
            // 
            this.update_button.Location = new System.Drawing.Point(1283, 123);
            this.update_button.Name = "update_button";
            this.update_button.Size = new System.Drawing.Size(157, 41);
            this.update_button.TabIndex = 13;
            this.update_button.Text = "更新";
            this.update_button.UseVisualStyleBackColor = true;
            this.update_button.Click += new System.EventHandler(this.update_button_Click);
            // 
            // delete_button
            // 
            this.delete_button.Location = new System.Drawing.Point(1476, 123);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(157, 41);
            this.delete_button.TabIndex = 13;
            this.delete_button.Text = "削除";
            this.delete_button.UseVisualStyleBackColor = true;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // mirror_button
            // 
            this.mirror_button.Location = new System.Drawing.Point(1476, 61);
            this.mirror_button.Name = "mirror_button";
            this.mirror_button.Size = new System.Drawing.Size(157, 41);
            this.mirror_button.TabIndex = 13;
            this.mirror_button.Text = "複製";
            this.mirror_button.UseVisualStyleBackColor = true;
            this.mirror_button.Click += new System.EventHandler(this.mirror_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(901, 61);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(131, 42);
            this.clear_button.TabIndex = 14;
            this.clear_button.Text = "クリア";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // balance_button
            // 
            this.balance_button.Location = new System.Drawing.Point(884, 127);
            this.balance_button.Name = "balance_button";
            this.balance_button.Size = new System.Drawing.Size(165, 37);
            this.balance_button.TabIndex = 15;
            this.balance_button.Text = "貸借対照表";
            this.balance_button.UseVisualStyleBackColor = true;
            this.balance_button.Click += new System.EventHandler(this.balance_button_Click);
            // 
            // IndexModelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1751, 879);
            this.Controls.Add(this.balance_button);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.mirror_button);
            this.Controls.Add(this.delete_button);
            this.Controls.Add(this.update_button);
            this.Controls.Add(this.alSelect_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ExpendComboBox);
            this.Controls.Add(this.dayComboBox);
            this.Controls.Add(this.monthComboBox);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.homeViewGrid);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.daimei);
            this.Controls.Add(this.select_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IndexModelView";
            this.Text = "支出/収入一覧表";
            ((System.ComponentModel.ISupportInitialize)(this.homeViewGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button select_button;
        private System.Windows.Forms.Label daimei;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.DataGridView homeViewGrid;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.ComboBox monthComboBox;
        private System.Windows.Forms.ComboBox dayComboBox;
        private System.Windows.Forms.ComboBox ExpendComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button alSelect_button;
        private System.Windows.Forms.Button update_button;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button mirror_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button balance_button;
    }
}

