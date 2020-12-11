using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LibInfrastructure.SQLIte
{
    internal class SQLiteHelper
    {
        internal const string connectionString = @"Data Source=C:\Users\nanai\source\repos\HouseholdAcountApp\home.db;Version=3;";

        internal static IReadOnlyList<T> Query<T>(
           string sql,
           Func<SQLiteDataReader, T> CreateEntity)
        {
            // TODO パラメータ無しクエリー
            return Query<T>(sql, null, CreateEntity);
        }

        internal static IReadOnlyList<T> Query<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> CreateEntity)
        {
            // TODO パラメータ有りクエリー
            var result = new List<T>();
            using (var connection = new SQLiteConnection(SQLiteHelper.connectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                if (parameters != null)
                {
                    // パラメータ設定
                    command.Parameters.AddRange(parameters);
                }
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // エンティティリストの作成
                        result.Add(CreateEntity(reader));
                    }
                }
            }
            return result;
        }

        internal static T QuerySingle<T>(
            string sql,
            Func<SQLiteDataReader, T> CreateEntity,
            T nullEntity)
        {
            // パラメータ無しクエリーシングル
            return QuerySingle<T>(sql, null, CreateEntity, nullEntity);
        }

        internal static T QuerySingle<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> CreateEntity,
            T nullEntity)
        {
            // パラメータ有りクエリーシングル
            using (var connection = new SQLiteConnection(SQLiteHelper.connectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                if (parameters != null)
                {
                    // パラメータ設定
                    command.Parameters.AddRange(parameters);
                }
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // エンティティ作成
                        if (reader.IsDBNull(0)) {
                            return nullEntity;
                        }
                        else
                        {
                            return CreateEntity(reader);
                        }
                        
                    }
                }
            }
            return nullEntity;
        }

        internal static void Execute(
            string insert, string update,
            SQLiteParameter[] parameters)
        {
            // 追加、更新処理
            using (var connection = new SQLiteConnection(SQLiteHelper.connectionString))
            using (var command = new SQLiteCommand(update, connection))
            {
                connection.Open();
                if (parameters != null)
                {
                    // パラメータ設定
                    command.Parameters.AddRange(parameters);
                }
                // 更新処理
                if (command.ExecuteNonQuery() < 1)
                {
                    // 追加処理
                    command.CommandText = insert;
                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void Execute(
           string sql,
           SQLiteParameter[] parameters)
        {
            // TODO 追加処理
            using (var connection = new SQLiteConnection(SQLiteHelper.connectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                if (parameters != null)
                {
                    // パラメータ設定
                    command.Parameters.AddRange(parameters);
                }
                // 追加処理
                command.ExecuteNonQuery();
            }
        }
    }
}
