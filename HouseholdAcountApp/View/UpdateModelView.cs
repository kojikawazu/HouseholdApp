using HouseholdAcountApp.ViewModel;
using LibDomain.Entity;
using LibDomain.ValueObjects;
using NLog;
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
    public partial class UpdateModelView : Form
    {
        private UpdateFormModel _updateViewModel = new UpdateFormModel();
        private IndexViewModel _indexViewModel = null; 

        public UpdateModelView()
        {
            InitializeComponent();

            // 支出/収入のコンボボックス
            this.ExpendComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ExpendComboBox.DataBindings.Add(
                "selectedValue", _updateViewModel, nameof(_updateViewModel.SelectedExpend));
            this.ExpendComboBox.DataBindings.Add(
                "DataSource", _updateViewModel, nameof(_updateViewModel.Expend));
            this.ExpendComboBox.ValueMember = nameof(ExpendObject.Value);
            this.ExpendComboBox.DisplayMember = nameof(ExpendObject.DisplayValue);

            // 日付のセレクトボックス
            this.DateTimePicker.DataBindings.Add(
                "Value", _updateViewModel, nameof(_updateViewModel.SelectedDay));

            // 名前のテキストボックス
            this.MoneyNameTextBox.DataBindings.Add(
                "Text", _updateViewModel, nameof(_updateViewModel.MoneyNameText));

            // ジャンルのコンボボックス
            this.TypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.TypeComboBox.DataBindings.Add(
                "selectedValue", _updateViewModel, nameof(_updateViewModel.SelectedType));
            this.TypeComboBox.DataBindings.Add(
                "DataSource", _updateViewModel, nameof(_updateViewModel.Type));
            this.TypeComboBox.ValueMember = nameof(TypeEntity.TypeId);
            this.TypeComboBox.DisplayMember = nameof(TypeEntity.TypeName);

            // 方法のコンボボックス
            this.ReceiveComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ReceiveComboBox.DataBindings.Add(
                "selectedValue", _updateViewModel, nameof(_updateViewModel.SelectedReceived));
            this.ReceiveComboBox.DataBindings.Add(
                "DataSource", _updateViewModel, nameof(_updateViewModel.Receive));
            this.ReceiveComboBox.ValueMember = nameof(ReceiveEntity.ReceiveId);
            this.ReceiveComboBox.DisplayMember = nameof(ReceiveEntity.ReceiveName);

            // 金額のテキストボックス
            this.MoneyTextBox.DataBindings.Add(
                "Text", _updateViewModel, nameof(_updateViewModel.MoneyText));
        }

        public void SetHomeEntityId(int id) {
            _updateViewModel.SetHomeEntityId(id);
        }

        public void SetIndexView(IndexViewModel indexView) {
            _indexViewModel = indexView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _updateViewModel.IsCheckForm();
                _updateViewModel.Update();
                MessageBox.Show("更新しました。");
                if (_indexViewModel != null) {
                    _indexViewModel.UpdateView();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateModelView_FormClosing(object sender, FormClosingEventArgs e)
        {
            _indexViewModel = null;
        }
    }
}
