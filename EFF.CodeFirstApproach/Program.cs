using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFF.CodeFirstApproach
{
    class Program
    {
        /*
         *
         * 1) Install EF - package manager -> install-package EntityFramework
         * 2) Create Models
         * 3) Add Context Class and inherit from DbContext
         * 4) Add Models as DbSet<> items
         * 5) Enable Migrations (just once) - package manager -> enable-migrations
         * 6) Create a new Migration. (after each change on model classes or add new model) - package manager -> add-migration related_migration_name
         * 7) After add new Migration - update-database apply changes on database
         * 8) MigrationHistory can be shown at Database's __MigrationHistory table.
         */

        /*
         * For example, we used a database which already exists. We create code-first model thourgh EF interface (add class - ADO.net - CodeFirstFromDatabase selected)
         * For classes comes from database, we will get an error when we try to create initial migration
         * to solve it : add-migration InitalMigration -IgroneChanges -Force
         */
        static void Main(string[] args)
        {
        }
    }
}
