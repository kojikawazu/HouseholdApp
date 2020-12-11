using LibDomain.Entity;
using LibDomain.Repository;
using LibInfrastructure.SQLIte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdAcountApp.ViewModel
{
    class BalanceSheetModel : ViewModelBase
    {
        IHomeRepository _home;
        IReceiveRepository _receive;
        ITypeRepository _type;

        public BalanceSheetModel() :
           this(new HomeSQLite(), new ReceiveSQLite(), new TypeSQLite())
        {
            // TODO コンストラクタ
        }

        public BalanceSheetModel(
            IHomeRepository home,
            IReceiveRepository receive,
            ITypeRepository type)
        {
            // TODO コンストラクタ
            _home = home;
            _receive = receive;
            _type = type;

        }

        public void setBalanceModelLeft(List<MoneyEntity> list)
        {
            // TODO 左のモデルリストの設定
            if (leftModel != null) {
                leftModel.Clear();
            }
            foreach (MoneyEntity entity in list) {
                leftModel.Add(new MoneyEntityModel(entity));
            }
            list.Clear();
        }

        public void setBalanceModelRight(List<MoneyEntity> list)
        {
            // TODO 右のモデルリストの設定
            if (rightModel != null)
            {
                rightModel.Clear();
            }
            foreach (MoneyEntity entity in list)
            {
                rightModel.Add(new MoneyEntityModel(entity));
            }
            list.Clear();
        }

        public BindingList<MoneyEntityModel> leftModel { get; set; }
            = new BindingList<MoneyEntityModel>();

        public BindingList<MoneyEntityModel> rightModel { get; set; }
            = new BindingList<MoneyEntityModel>();
    }
}
