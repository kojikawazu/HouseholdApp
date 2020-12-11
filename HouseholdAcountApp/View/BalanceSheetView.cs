using HouseholdAcountApp.ViewModel;
using LibDomain.Entity;
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
    public partial class BalanceSheetView : Form
    {
        private BalanceSheetModel _balanceSheetModel = new BalanceSheetModel();

        public BalanceSheetView()
        {
            InitializeComponent();

            leftDataGridView.DataBindings.Add("DataSource",
                _balanceSheetModel, nameof(_balanceSheetModel.leftModel));

            rightDataGridView.DataBindings.Add("DataSource",
                _balanceSheetModel, nameof(_balanceSheetModel.rightModel));
        }

        internal void SetBalanceSheetLeft(List<MoneyEntity> entityListL)
        {
            _balanceSheetModel.setBalanceModelLeft(entityListL);
        }

        internal void SetBalanceSheetRight(List<MoneyEntity> entityListR)
        {
            _balanceSheetModel.setBalanceModelRight(entityListR);
        }
    }
}
