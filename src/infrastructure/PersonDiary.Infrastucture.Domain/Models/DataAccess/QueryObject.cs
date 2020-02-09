using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PersonDiary.Infrastucture.Domain.Models.DataAccess
{
    public class QueryObject
    {
        public QueryObject(string sql, object queryParams, CommandType? commandType = null)
        {
            if (string.IsNullOrEmpty(sql)) throw new ArgumentNullException(nameof(sql));
            Sql = sql;
            QueryParams = queryParams;
            CommandType = commandType;
        }
        public string Sql { get; private set; }
        public object QueryParams { get; private set; }
        public CommandType? CommandType { get; private set; }
    }
}
