using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ERP.UtilityManagement
{
    public class DatabaseBackupAndRestore
    {
        public async virtual Task<string> BackUpDatabase(string path, string dbName)
        {
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                string fileName ="dbName"+DateTime.Now.ToString("yyyyMMddhhmmss") + ".bak";
                string sql = $"BACKUP DATABASE[{dbName}] TO DISK = '{path + fileName}'";
                con.Execute(sql, commandTimeout: 300);
                return path + fileName;
            }
        }
    }
}
