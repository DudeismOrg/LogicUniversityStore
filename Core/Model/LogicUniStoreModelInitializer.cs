using System;
using System.Data.Entity;
using System.IO;

namespace LogicUniversityStore.Model
{
    public class LogicUniStoreModelInitializer : DropCreateDatabaseAlways<LogicUniStoreModel>
    {
        public override void InitializeDatabase(LogicUniStoreModel context)
        {
            base.InitializeDatabase(context);

            string[] fileNames = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.sql");
            foreach (string file in fileNames)
            {
                context.Database.ExecuteSqlCommand(File.ReadAllText(file));
            }
        }
    }
}