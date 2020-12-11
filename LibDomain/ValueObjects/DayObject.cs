using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.ValueObjects
{
    public sealed class DayObject : ValueObject<DayObject>
    {
        public DayObject(string inday) {
            // TODO コンストラクタ
            Day = inday;
        }

        public string Day { get; }

        public string InputDay {
            get {
                string day;

                if (Day.Length == 1)
                {
                    day = "0" + Day;
                }
                else {
                    day = Day;
                }
                return day;
            }
        }

        protected override bool EqualCore(DayObject other)
        {
            return Day == other.Day;
        }
    }
}
