using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Entity
{
    public sealed class MoneyEntity
    {
        public MoneyEntity(string kindName, int money) {
            KindName = kindName;
            Money = money;
        }

        public string KindName { get; }
        public int Money { get; }
    }
}
