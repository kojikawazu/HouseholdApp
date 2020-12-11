using LibDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseholdAcountApp.ViewModel
{
    public class HomeEntityModel
    {
        private HomeEntity _entity;

        public HomeEntityModel(HomeEntity entity) {
            // TODO コンストラクタ
            _entity = entity;
        }

        public string MoneyId => _entity.MoneyId.ToString();

        public string MoneyName => _entity.MoneyName;

        public string TypeId => _entity.Type.TypeName;

        public string ReceiveId => _entity.Receive.ReceiveName;

        public string expendId => _entity.Expend.DisplayValue;

        public string MoneyInt => _entity.MoneyInt.ToString();

        public string Created => _entity.Created.ToShortDateString();

    }
}
