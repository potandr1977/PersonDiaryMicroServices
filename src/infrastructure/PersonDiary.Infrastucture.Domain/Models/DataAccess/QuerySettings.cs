using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace PersonDiary.Infrastucture.Domain.Models.DataAccess
{
    public class QuerySetting
    {
        public QuerySetting() : this(null, null)
        {
        }

        public QuerySetting(DbTransaction transaction = null, int? timeout = null)
        {
            Transaction = transaction;
            Timeout = timeout;
        }

        public DbTransaction Transaction { get; set; }

        public int? Timeout { get; set; }
    }
}
