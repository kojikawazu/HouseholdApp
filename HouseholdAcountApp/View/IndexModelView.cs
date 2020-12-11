using HouseholdAcountApp.View;
using HouseholdAcountApp.ViewModel;
using LibDomain.Entity;
using LibDomain.Exceptions;
using LibDomain.ValueObjects;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace HouseholdAcountApp
{
    public partial class IndexModelView : Form
    {
        private Logger Test_logger = LogManager.GetCurrentClassLogger();

        private IndexViewModel _indexViewModel = new IndexViewModel();

        public IndexModelView()
        {
            InitializeComponent();

            // ------------------------------------------------------------

            // 年のセレクトボックス
            this.yearComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.yearComboBox.DataBindings.Add(
                "selectedValue", _indexViewModel, nameof(_indexViewModel.SelectedYear));
            this.yearComboBox.DataBindings.Add(
                "DataSource", _indexViewModel, nameof(_indexViewModel.Years));
            this.yearComboBox.ValueMember = nameof(CreatedDay.Value);
            this.yearComboBox.DisplayMember = nameof(CreatedDay.DisplayValue);

            // 月のセレクトボックス
            this.monthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.monthComboBox.DataBindings.Add(
                "selectedValue", _indexViewModel, nameof(_indexViewModel.SelectedMonth));
            this.monthComboBox.DataBindings.Add(
                "DataSource", _indexViewModel, nameof(_indexViewModel.Months));
            this.monthComboBox.ValueMember = nameof(CreatedDay.Value);
            this.monthComboBox.DisplayMember = nameof(CreatedDay.DisplayValue);

            // 日のセレクトボックス
            this.dayComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.dayComboBox.DataBindings.Add(
                "selectedValue", _indexViewModel, nameof(_indexViewModel.SelectedDay));
            this.dayComboBox.DataBindings.Add(
                "DataSource", _indexViewModel, nameof(_indexViewModel.Days));
            this.dayComboBox.ValueMember = nameof(CreatedDay.Value);
            this.dayComboBox.DisplayMember = nameof(CreatedDay.DisplayValue);

            // 支出 / 収入のセレクトボックス
            this.ExpendComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ExpendComboBox.DataBindings.Add(
                "selectedValue", _indexViewModel, nameof(_indexViewModel.SelectedExpend));
            this.ExpendComboBox.DataBindings.Add(
                "DataSource", _indexViewModel, nameof(_indexViewModel.Expend));
            this.ExpendComboBox.ValueMember = nameof(ExpendObject.Value);
            this.ExpendComboBox.DisplayMember = nameof(ExpendObject.DisplayValue);

            this.yearComboBox.SelectedIndex= -1;
            this.monthComboBox.SelectedIndex = -1;
            this.dayComboBox.SelectedIndex = -1;
            this.ExpendComboBox.SelectedIndex = -1;

            // ------------------------------------------------------------

            // 一覧表示
            homeViewGrid.DataBindings.Add("DataSource",
                _indexViewModel, nameof(_indexViewModel.HomeEntityModel));
        }

        private void select_button_Click(object sender, EventArgs e)
        {
            // TODO 日付と支出/収入項目選択
            try
            {
                // エラーチェック
                _indexViewModel.IsCheckForm();
                // 検索
                _indexViewModel.Search();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //Test_logger.Error(ex.Message.ToString);
            }
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            // TODO 追加
            using (var f = new SaveModelView()) 
            {
                f.ShowDialog();
            }
        }

        private void alSelect_button_Click(object sender, EventArgs e)
        {
            // TODO 全て選択
            _indexViewModel.SearchToTest();
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            // TODO 更新
            // 選択件数チェック
            try
            {
                // 1件選択されてるかチェック
                int count = homeViewGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                _indexViewModel.IsCheckCount(count, 1);

                using (var f = new UpdateModelView())
                {
                    f.SetHomeEntityId(Convert.ToInt32(homeViewGrid.CurrentRow.Cells[0].Value));
                    f.SetIndexView(_indexViewModel);
                    f.ShowDialog();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void mirror_button_Click(object sender, EventArgs e)
        {
            // TODO 複製ボタンクリック処理
            try
            {
                // 選択件数チェック
                int count = homeViewGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                _indexViewModel.IsCheckZero(count);
                if (_indexViewModel.IsCheckDialog("選択している行を複製します。本当によろしいですか？")) {
                    // はい
                    // 複製処理
                    _indexViewModel.CopyObject(homeViewGrid.SelectedRows);
                    _indexViewModel.UpdateView();
                    MessageBox.Show("複製完了しました。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            // TODO 削除ボタンクリック処理
            try {
                // 選択件数チェック
                int count = homeViewGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
                _indexViewModel.IsCheckZero(count);
                
                if (_indexViewModel.IsCheckDialog("選択している行を削除します。本当によろしいですか？")) {
                    // はい
                    // 削除処理
                    _indexViewModel.Delete(homeViewGrid.SelectedRows);
                    _indexViewModel.UpdateView();
                    MessageBox.Show("削除完了しました。");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            // コンボボックスクリア
            yearComboBox.SelectedIndex = -1;
            monthComboBox.SelectedIndex = -1;
            dayComboBox.SelectedIndex = -1;
            ExpendComboBox.SelectedIndex = -1;
            _indexViewModel.ClearSelectCombobox();
        }

        private void balance_button_Click(object sender, EventArgs e)
        {
            // TODO 貸借対照表の表示
            using (var f = new BalanceSheetView())
            {
                // プラス側、マイナス側にリスト追加
                List<MoneyEntity> listL = _indexViewModel.setBalancePage(true);
                List<MoneyEntity> listR = _indexViewModel.setBalancePage(false);
                f.SetBalanceSheetLeft(listL);
                f.SetBalanceSheetRight(listR);
                // 表示
                f.ShowDialog();

            }
        }
    }
}
