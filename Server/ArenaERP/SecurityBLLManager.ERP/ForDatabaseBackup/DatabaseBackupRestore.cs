using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ERP.UtilityManagement;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SecurityBLLManager.ERP.ForDatabaseBackup.Interface;

namespace SecurityBLLManager.ERP.ForDatabaseBackup
{
    public class DatabaseBackupRestore: IDatabaseBackupAndRestoreBLLManager
    {
        //private readonly IConfiguration _config;

        public DatabaseBackupRestore()
        {
            //_config= config;
        }

        public async Task<string> DatabaseBackup(string dbName,string path)
        {
            using (var con = new SqlConnection(Connection.ConnectionString()))
            {
                string fileName = dbName + DateTime.Now.ToString("yyyyMMddhhmmss") + ".bak";
                string sql = $"BACKUP DATABASE[{dbName}] TO DISK = '{path + fileName}'";
                con.Execute(sql, commandTimeout: 300);
                return path + fileName;
            }
        }
    }
}
