using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Entity
{
    public sealed class ReceiveEntity
    {
        public ReceiveEntity(
            int receiveId,
            string receiveName
            ) {
            // TODO コンストラクタ
            ReceiveId = receiveId;
            ReceiveName = receiveName;
        }

        public int ReceiveId { get; }
        public string ReceiveName { get; }
    }
}
