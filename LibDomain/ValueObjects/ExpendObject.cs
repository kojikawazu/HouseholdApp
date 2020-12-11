using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.ValueObjects
{
    public sealed class ExpendObject : ValueObject<ExpendObject>
    {
        public static readonly ExpendObject Spend = new ExpendObject(1);
        public static readonly ExpendObject Income = new ExpendObject(2);
        public static readonly ExpendObject Other = new ExpendObject(3);

        public ExpendObject(int inExpend) {
            // TODO コンストラクタ
            if ( inExpend == 1 || inExpend == 2 )
            {
                Value = inExpend;
            }
            else {
                Value = 3;
            }
        }

        public int Value { get; }

        public string DisplayValue
        {
            get
            {
                if (this == Spend)
                {
                    return "支出";
                }
                else if (this == Income)
                {
                    return "収入";
                }
                else {
                    return "その他";
                }
            }
        }

        protected override bool EqualCore(ExpendObject other)
        {
            return Value == other.Value;
        }

        public static IList<ExpendObject> ToList() {
            return new List<ExpendObject>
            {
                Spend,
                Income,
                Other,
            };
        }


    }
}
