using LibDomain.Entity;
using LibDomain.Repository;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibInfrastructure.SQLIte
{
    public class TypeSQLite : ITypeRepository
    {
        public IReadOnlyList<TypeEntity> selectAll()
        {
            // TODO 全選択
            string sql = @"select TypeId, TypeName from TypeTable";
            return SQLiteHelper.Query(sql,
                    reader => {
                        return new TypeEntity(
                            Convert.ToInt32(reader["TypeId"]),
                            Convert.ToString(reader["TypeName"])
                            );
                    }
                );
        }

        public TypeEntity Select_byName(string name)
        {
            // TODO 名前による選択
            string sql = @"select TypeId, TypeName from TypeTable where TypeName = @TypeName";
            return SQLiteHelper.QuerySingle(sql,
                    new List<SQLiteParameter>
                    {
                        new SQLiteParameter("@TypeName", name),
                    }.ToArray(),
                    reader => {
                        return new TypeEntity(
                            Convert.ToInt32(reader["TypeId"]),
                            Convert.ToString(reader["TypeName"])
                            );
                    },
                    null
                );
        }
    }
}
