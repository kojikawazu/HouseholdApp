using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Entity
{
    public sealed class ExpendEntity
    {
        public ExpendEntity(
            int expendId,
            string expendName) {
            // TODO コンストラクタ
            ExpendId = expendId;
            ExpendName = expendName;
        }

        public int ExpendId { get; }
        public string ExpendName { get; }
    }
}
