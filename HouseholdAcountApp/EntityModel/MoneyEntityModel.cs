using LibDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdAcountApp.ViewModel
{
    class MoneyEntityModel
    {
        private MoneyEntity _entity;
        public MoneyEntityModel(MoneyEntity entity) {
            // TODO コンストラクタ
            _entity = entity;
        }

        public string KindName => _entity.KindName;

        public string MoneySum => _entity.Money.ToString(); 
    }
}
