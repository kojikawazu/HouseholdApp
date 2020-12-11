
using System.Collections;
using System.Collections.Generic;

namespace LibDomain.ValueObjects
{
    public sealed class CreatedDay : ValueObject<CreatedDay>
    {
        public CreatedDay(int inday) {
            Value = inday;
        }

        public int Value{ get;  }

        public string DisplayValue {
            get {
                return Value.ToString();
            }
        }

        protected override bool EqualCore(CreatedDay other)
        {
            return Value == other.Value;
        }

        public static IList<CreatedDay> ToList(int mode) {
            var list = new List<CreatedDay>();
            switch (mode) {
                case 1:
                    for (int idx=2000; idx <= 2030; idx++) {
                        list.Add(new CreatedDay(idx));
                    }
                    break;
                case 2:
                    for (int idx = 1; idx <= 12; idx++)
                    {
                        list.Add(new CreatedDay(idx));
                    }
                    break;
                case 3:
                    for (int idx = 1; idx <= 31; idx++)
                    {
                        list.Add(new CreatedDay(idx));
                    }
                    break;
            }
            return list;
        }
    }
}
