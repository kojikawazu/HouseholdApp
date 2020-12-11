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
    public class ExpendSQLite : IExpendRepository
    {
        public IReadOnlyList<ExpendEntity> selectAll()
        {
            // TODO 全選択
            string sql =
                @"select ExpendId, ExpendName from ExpendTable";
            return SQLiteHelper.Query(sql,
                    reader => {
                        return new ExpendEntity(
                            Convert.ToInt32(reader["ExpendId"]),
                            Convert.ToString(reader["ExpendName"])
                            );
                    }
                );
        }

        public ExpendEntity select_byName(string name)
        {
            string sql =
                @"select ExpendId, ExpendName from ExpendTable where ExpendName = @ExpendName";
            return SQLiteHelper.QuerySingle(sql,
                    new List<SQLiteParameter> {  
                        new SQLiteParameter("@ExpendName", name),
                    }.ToArray(),
                    reader => {
                        return new ExpendEntity(
                            Convert.ToInt32(reader["ExpendId"]),
                            Convert.ToString(reader["ExpendName"])
                            );
                    },
                    null
                );
        }
    }
}
