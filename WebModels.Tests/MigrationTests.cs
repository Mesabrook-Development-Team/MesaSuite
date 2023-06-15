using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebModels.Migrations;

namespace WebModels.Tests
{
    [TestClass]
    public class MigrationTests
    {
        [TestMethod]
        public void VerifyNonDuplicateMigrationNumbers()
        {
            Type migrationType = typeof(IMigration);
            HashSet<int> migrationsUsed = new HashSet<int>();
            HashSet<int> duplicateMigrations = new HashSet<int>();
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    foreach (Type type in assembly.GetTypes().Where(t => t != migrationType && migrationType.IsAssignableFrom(t)))
                    {
                        IMigration migration = (IMigration)Activator.CreateInstance(type);
                        if (!migrationsUsed.Add(migration.MigrationNumber))
                        {
                            duplicateMigrations.Add(migration.MigrationNumber);
                        }
                    }
                }
                catch { }
            }

            Assert.AreEqual(0, duplicateMigrations.Count, "There are duplicate migration numbers: " + String.Join(", ", duplicateMigrations));
        }
    }
}
