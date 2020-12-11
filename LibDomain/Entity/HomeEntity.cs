using LibDomain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Entity
{
    public sealed class HomeEntity
    {
        public HomeEntity(
            int moneyId,
            string moneyName,
            int typeId,
            int receivceId,
            int expendId,
            int moneyInt,
            DateTime created)
            : this(moneyId, moneyName, typeId, null, receivceId, null, expendId, moneyInt, created)
        {
            // TODO コンストラクタ
        }

        public HomeEntity(
            int moneyId,
            string moneyName,
            int typeId,
            string typeName,
            int receivceId,
            string receiveName,
            int expendId,
            int moneyInt,
            DateTime created){
            // TODO コンストラクタ
            MoneyId = moneyId;
            MoneyName = moneyName;
            Type = new TypeEntity(typeId, typeName);
            Receive = new ReceiveEntity(receivceId, receiveName);
            Expend = new ExpendObject(expendId);
            MoneyInt = moneyInt;
            Created = created;
        }

        public int MoneyId { get;  }
           
        public string MoneyName { get;  }
            
        public TypeEntity Type { get;  }

        public ReceiveEntity Receive{ get;  }

        public ExpendObject Expend { get;  }

        public int MoneyInt { get;  }

        public DateTime Created { get;  }



    }
}
