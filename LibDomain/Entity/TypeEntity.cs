using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDomain.Entity
{
    public sealed class TypeEntity
    {
        public TypeEntity(
            int typeId,
            string typeName)
        {
            // TODO コンストラクタ
            TypeId = typeId;
            TypeName = typeName;
        }

        public int TypeId { get; }
        public string TypeName { get; }
    }
}
