
namespace HouseholdAcountApp.View
{
    partial class BalanceSheetView
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
            this.leftDataGridView = new System.Windows.Forms.DataGridView();
            this.rightDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.leftDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // leftDataGridView
            // 
            this.leftDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.leftDataGridView.Location = new System.Drawing.Point(1, 170);
            this.leftDataGridView.Name = "leftDataGridView";
            this.leftDataGridView.RowHeadersWidth = 82;
            this.leftDataGridView.RowTemplate.Height = 33;
            this.leftDataGridView.Size = new System.Drawing.Size(556, 441);
            this.leftDataGridView.TabIndex = 0;
            // 
            // rightDataGridView
            // 
            this.rightDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.rightDataGridView.Location = new System.Drawing.Point(563, 170);
            this.rightDataGridView.Name = "rightDataGridView";
            this.rightDataGridView.RowHeadersWidth = 82;
            this.rightDataGridView.RowTemplate.Height = 33;
            this.rightDataGridView.Size = new System.Drawing.Size(559, 441);
            this.rightDataGridView.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "貸借対照表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "プラス";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(601, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "マイナス";
            // 
            // BalanceSheetView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 610);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rightDataGridView);
            this.Controls.Add(this.leftDataGridView);
            this.Name = "BalanceSheetView";
            this.Text = "貸借対照表";
            ((System.ComponentModel.ISupportInitialize)(this.leftDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView leftDataGridView;
        private System.Windows.Forms.DataGridView rightDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}