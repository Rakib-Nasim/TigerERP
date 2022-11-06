using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityBLLManager.ERP.ForDatabaseBackup.Interface
{
    public interface IDatabaseBackupAndRestoreBLLManager
    {
        Task<string> DatabaseBackup(string dbName, string path);
    }
}
