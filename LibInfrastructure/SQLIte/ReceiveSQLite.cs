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
    public class ReceiveSQLite : IReceiveRepository
    {
        public IReadOnlyList<ReceiveEntity> selectAll()
        {
            // TODO 全選択
            string sql =
                @"select ReceiveId, ReceiveName from ReceiveTable";
            return SQLiteHelper.Query(sql,
                    reader => {
                        return new ReceiveEntity(
                            Convert.ToInt32(reader["ReceiveId"]),
                            Convert.ToString(reader["ReceiveName"])
                            );
                    }
                );
        }

        public ReceiveEntity select_byName(string name)
        {
            // TODO 全選択
            string sql =
                @"select ReceiveId, ReceiveName from ReceiveTable where ReceiveName = @ReceiveName";
            return SQLiteHelper.QuerySingle(sql,
                    new List<SQLiteParameter> { 
                        new SQLiteParameter("@ReceiveName", name),
                    }.ToArray(),
                    reader => {
                        return new ReceiveEntity(
                            Convert.ToInt32(reader["ReceiveId"]),
                            Convert.ToString(reader["ReceiveName"])
                            );
                    },
                    null
                );
        }
    }
}
