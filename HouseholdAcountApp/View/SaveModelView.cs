using HouseholdAcountApp.ViewModel;
using LibDomain.Entity;
using LibDomain.Exceptions;
using LibDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdAcountApp.View
{
    public partial class SaveModelView : Form
    {
        private SaveFormModel _saveFormModel = new SaveFormModel();

        public SaveModelView()
        {
            InitializeComponent();

            // 支出/収入のコンボボックス
            this.ExpendComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ExpendComboBox.DataBindings.Add(
                "selectedValue", _saveFormModel, nameof(_saveFormModel.SelectedExpend));
            this.ExpendComboBox.DataBindings.Add(
                "DataSource", _saveFormModel, nameof(_saveFormModel.Expend));
            this.ExpendComboBox.ValueMember = nameof(ExpendObject.Value);
            this.ExpendComboBox.DisplayMember = nameof(ExpendObject.DisplayValue);

            // 日付のセレクトボックス
            this.DateTimePicker.DataBindings.Add(
                "Value", _saveFormModel, nameof(_saveFormModel.SelectedDay));

            // 名前のテキストボックス
            this.MoneyNameTextBox.DataBindings.Add(
                "Text", _saveFormModel, nameof(_saveFormModel.MoneyNameText));

            // ジャンルのコンボボックス
            this.TypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.TypeComboBox.DataBindings.Add(
                "selectedValue", _saveFormModel, nameof(_saveFormModel.SelectedType));
            this.TypeComboBox.DataBindings.Add(
                "DataSource", _saveFormModel, nameof(_saveFormModel.Type));
            this.TypeComboBox.ValueMember = nameof(TypeEntity.TypeId);
            this.TypeComboBox.DisplayMember = nameof(TypeEntity.TypeName);

            // 方法のコンボボックス
            this.ReceiveComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ReceiveComboBox.DataBindings.Add(
                "selectedValue", _saveFormModel, nameof(_saveFormModel.SelectedReceived));
            this.ReceiveComboBox.DataBindings.Add(
                "DataSource", _saveFormModel, nameof(_saveFormModel.Receive));
            this.ReceiveComboBox.ValueMember = nameof(ReceiveEntity.ReceiveId);
            this.ReceiveComboBox.DisplayMember = nameof(ReceiveEntity.ReceiveName);

            // 金額のテキストボックス
            this.MoneyTextBox.DataBindings.Add(
                "Text", _saveFormModel, nameof(_saveFormModel.MoneyText));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                _saveFormModel.IsCheckForm();
                _saveFormModel.Save();
                MessageBox.Show("追加しました。");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
