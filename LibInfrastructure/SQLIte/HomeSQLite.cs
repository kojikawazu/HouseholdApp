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
    public class HomeSQLite : IHomeRepository
    {
        private const string JOIN_STRING = @"left outer join ReceiveTable B 
                on A.ReceiveId = B.ReceiveId
                left outer join TypeTable C
                on A.TypeId = C.TypeId";

        private const string JOIN_STRING_TYPE = @"left outer join TypeTable C 
                on A.TypeId = C.TypeId";

        private const string JOIN_STRING_REC = @"left outer join ReceiveTable B 
                on A.ReceiveId = B.ReceiveId";

        private const string FROM_TABLE = @"from HomeMoneyTable A";

        public IReadOnlyList<HomeEntity> SelectAll()
        {
            // TODO 全選択
            string sql =
                @"select A.MoneyId, A.MoneyName, 
                        A.TypeId, ifnull(C.TypeName, '') as TypeName,
                        A.ReceiveId, ifnull(B.ReceiveName, '') as ReceiveName, 
                        A.ExpendId, 
                        A.MoneyInt, A.Created " +
                FROM_TABLE + " " + JOIN_STRING;
            return in_queryList(sql);
        }

        public IReadOnlyList<HomeEntity> select_byDay(string day, int isExpend)
        {
            // TODO 日付と支出番号による選択
            string sql =
                @"select A.MoneyId, A.MoneyName, 
                        A.TypeId, ifnull(C.TypeName, '') as TypeName,
                        A.ReceiveId, ifnull(B.ReceiveName, '') as ReceiveName, 
                        A.ExpendId, 
                        A.MoneyInt, A.Created " +
                FROM_TABLE + " " + JOIN_STRING +
                @" where (A.Created = @Created or A.Created = @Created_ch) and A.ExpendId = @ExpendId";
            string change_day = day + " 00:00:00";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@Created", day),
                new SQLiteParameter("@Created_ch", change_day),
                new SQLiteParameter("@ExpendId", isExpend),
            };
            return in_queryList(sql, args.ToArray());
        }

        public HomeEntity select_byId(int id)
        {
            // TODO IDによる選択
            // TODO 日付と支出番号による選択
            string sql =
                @"select A.MoneyId, A.MoneyName, 
                        A.TypeId, ifnull(C.TypeName, '') as TypeName,
                        A.ReceiveId, ifnull(B.ReceiveName, '') as ReceiveName, 
                        A.ExpendId, 
                        A.MoneyInt, A.Created " +
                FROM_TABLE + " " + JOIN_STRING +
                @" where A.MoneyId = @MoneyId";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@MoneyId", id),
            };
            return SQLiteHelper.QuerySingle(sql,
                args.ToArray(),
                reader => {
                    return setHomeEntity(reader);
                }, 
                null);
        }

        public void Insert(HomeEntity entity)
        {
            // TODO 天気データの追加 
            string insert = @"insert into HomeMoneyTable(MoneyName, TypeId, ReceiveId, ExpendId, MoneyInt, Created)
                            values
                            (@MoneyName, @TypeId, @ReceiveId, @ExpendId, @MoneyInt, @Created)";
            DateTime change_date = entity.Created.Date;
            var args = new List<SQLiteParameter>
            {
                new SQLiteParameter("@MoneyName", entity.MoneyName),
                new SQLiteParameter("@TypeId",    entity.Type.TypeId),
                new SQLiteParameter("@ReceiveId", entity.Receive.ReceiveId),
                new SQLiteParameter("@ExpendId", entity.Expend.Value),
                new SQLiteParameter("@MoneyInt", entity.MoneyInt),
                new SQLiteParameter("@Created", change_date),
            };
            SQLiteHelper.Execute(insert, args.ToArray());
        }

        public void Update(HomeEntity entity)
        {
            string update = @"update HomeMoneyTable set 
                            MoneyName = @MoneyName, TypeId = @TypeId, ReceiveId = @ReceiveId, 
                            ExpendId = @ExpendId, MoneyInt = @MoneyInt, Created = @Created 
                            where MoneyId = @MoneyId";
            var args = new List<SQLiteParameter>
            {
                new SQLiteParameter("@MoneyName", entity.MoneyName),
                new SQLiteParameter("@TypeId",    entity.Type.TypeId),
                new SQLiteParameter("@ReceiveId", entity.Receive.ReceiveId),
                new SQLiteParameter("@ExpendId", entity.Expend.Value),
                new SQLiteParameter("@MoneyInt", entity.MoneyInt),
                new SQLiteParameter("@Created", entity.Created),
                new SQLiteParameter("@MoneyId", entity.MoneyId),
            };
            SQLiteHelper.Execute(update, args.ToArray());
        }

        public void Delete(List<int> IdList) {
            // TODO 削除
            string sql = @"delete from HomeMoneyTable where MoneyId = @MoneyId";
            foreach (int id in IdList)
            {
                var args = new List<SQLiteParameter>
                {
                    new SQLiteParameter("@MoneyId", id),
                };
                SQLiteHelper.Execute(sql, args.ToArray());
            }
        }

        public MoneyEntity select_MoneySum_byTypeId(int typeId)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(C.TypeName, '') as TypeName " +
                        FROM_TABLE + " " + JOIN_STRING_TYPE +
                        @" where A.TypeId = @TypeId";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@TypeId", typeId),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_typeId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byReceiveId(int receiveId)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(B.ReceiveName, '') as ReceiveName " +
                        FROM_TABLE + " " + JOIN_STRING_REC +
                        @" where A.ReceiveId = @ReceiveId";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@ReceiveId", receiveId),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_reciveId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byTypeId(int typeId, int expendId)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(C.TypeName, '') as TypeName " +
                        FROM_TABLE + " " + JOIN_STRING_TYPE +
                        @" where A.TypeId = @TypeId and A.ExpendId = @ExpendId";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@TypeId", typeId),
                new SQLiteParameter("@ExpendId", expendId),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_typeId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byReceiveId(int receiveId, int expendId)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(B.ReceiveName, '') as ReceiveName " +
                        FROM_TABLE + " " + JOIN_STRING_REC +
                        @" where A.ReceiveId = @ReceiveId and A.ExpendId = @ExpendId";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@ReceiveId", receiveId),
                new SQLiteParameter("@ExpendId", expendId),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_reciveId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byTypeId(int typeId, DateTime created)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(C.TypeName, '') as TypeName " +
                        FROM_TABLE + " " + JOIN_STRING_TYPE +
                        @" where A.TypeId = @TypeId and A.Created = @Created";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@TypeId", typeId),
                new SQLiteParameter("@Created", created),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_typeId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byReceiveId(int receiveId, DateTime created)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(B.ReceiveName, '') as ReceiveName " +
                        FROM_TABLE + " " + JOIN_STRING_REC +
                        @" where A.ReceiveId = @ReceiveId and A.Created = @Created";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@ReceiveId", receiveId),
                new SQLiteParameter("@Created", created),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_reciveId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byTypeId(int typeId, int expendId, DateTime created)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(C.TypeName, '') as TypeName " +
                        FROM_TABLE + " " + JOIN_STRING_TYPE +
                        @" where A.TypeId = @TypeId and A.ExpendId = @ExpendId and A.Created = @Created";
            var args = new List<SQLiteParameter> {
                 new SQLiteParameter("@TypeId", typeId),
                 new SQLiteParameter("@ExpendId", expendId),
                new SQLiteParameter("@Created", created),

            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_typeId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byReceiveId(int receiveId, int expendId, DateTime created)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(B.ReceiveName, '') as ReceiveName " +
                        FROM_TABLE + " " + JOIN_STRING_REC +
                        @" where A.ReceiveId = @ReceiveId and A.ExpendId = @ExpendId and A.Created = @Created";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@ReceiveId", receiveId),
                new SQLiteParameter("@ExpendId", expendId),
                new SQLiteParameter("@Created", created),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_reciveId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byTypeId(int typeId, DateTime stCreated, DateTime edCreated)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(C.TypeName, '') as TypeName " +
                        FROM_TABLE + " " + JOIN_STRING_TYPE +
                        @" where A.TypeId = @TypeId and A.Created between @stCreated and @edCreated";
            var args = new List<SQLiteParameter> {
                 new SQLiteParameter("@TypeId", typeId),
                 new SQLiteParameter("@stCreated", stCreated),
                 new SQLiteParameter("@edCreated", edCreated),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_typeId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byReceiveId(int receiveId, DateTime stCreated, DateTime edCreated)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(B.ReceiveName, '') as ReceiveName " +
                        FROM_TABLE + " " + JOIN_STRING_REC +
                        @" where A.ReceiveId = @ReceiveId and A.Created between @stCreated and @edCreated";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@ReceiveId", receiveId),
                 new SQLiteParameter("@stCreated", stCreated),
                 new SQLiteParameter("@edCreated", edCreated),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_reciveId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byTypeId(int typeId, int expendId, DateTime stCreated, DateTime edCreated)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(C.TypeName, '') as TypeName " +
                        FROM_TABLE + " " + JOIN_STRING_TYPE +
                        @" where A.TypeId = @TypeId and A.ExpendId = @ExpendId and A.Created between @stCreated and @edCreated";
            var args = new List<SQLiteParameter> {
                 new SQLiteParameter("@TypeId", typeId),
                 new SQLiteParameter("@ExpendId", expendId),
                 new SQLiteParameter("@stCreated", stCreated),
                 new SQLiteParameter("@edCreated", edCreated),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_typeId(reader);
               }, null);
        }

        public MoneyEntity select_MoneySum_byReceiveId(int receiveId, int expendId, DateTime stCreated, DateTime edCreated)
        {
            // TODO 金額合計
            string sql = @"select sum(A.MoneyInt) as MoneySum, ifnull(B.ReceiveName, '') as ReceiveName " +
                        FROM_TABLE + " " + JOIN_STRING_REC +
                        @" where A.ReceiveId = @ReceiveId and A.ExpendId = @ExpendId and A.Created between @stCreated and @edCreated";
            var args = new List<SQLiteParameter> {
                new SQLiteParameter("@ReceiveId", receiveId),
                new SQLiteParameter("@ExpendId", expendId),
                 new SQLiteParameter("@stCreated", stCreated),
                 new SQLiteParameter("@edCreated", edCreated),
            };
            return SQLiteHelper.QuerySingle(sql,
               args.ToArray(),
               reader => {
                   return setMoneyEntity_reciveId(reader);
               }, null);
        }

        private IReadOnlyList<HomeEntity> in_queryList(string sql)
        {
            // TODO クエリーリスト
            return SQLiteHelper.Query(sql,
                    reader => {
                        return setHomeEntity(reader);
                    }
                );
        }

        private IReadOnlyList<HomeEntity> in_queryList(string sql, SQLiteParameter[] parameters)
        {
            // TODO クエリーリスト(パラメータ有)
            return SQLiteHelper.Query(sql,
                    parameters,
                    reader => {
                        return setHomeEntity(reader);
                    }
                );
        }

        private HomeEntity setHomeEntity(SQLiteDataReader reader)
        {
            // TODO 取得したデータからエンティティに生成
            return new HomeEntity(
                        Convert.ToInt32(reader["MoneyId"]),
                        Convert.ToString(reader["MoneyName"]),
                        Convert.ToInt32(reader["TypeId"]),
                        Convert.ToString(reader["TypeName"]),
                        Convert.ToInt32(reader["ReceiveId"]),
                        Convert.ToString(reader["ReceiveName"]),
                        Convert.ToInt32(reader["ExpendId"]),
                        Convert.ToInt32(reader["MoneyInt"]),
                        Convert.ToDateTime(reader["Created"])
                        );
        }

        private MoneyEntity setMoneyEntity_typeId(SQLiteDataReader reader)
        {
            // TODO 取得したデータからエンティティに生成
            return new MoneyEntity(
                        Convert.ToString(reader["TypeName"]),
                        Convert.ToInt32(reader["MoneySum"])
                        );
        }

        private MoneyEntity setMoneyEntity_reciveId(SQLiteDataReader reader)
        {
            // TODO 取得したデータからエンティティに生成
            return new MoneyEntity(
                        Convert.ToString(reader["ReceiveName"]),
                        Convert.ToInt32(reader["MoneySum"])
                        );
        }
    }
}
