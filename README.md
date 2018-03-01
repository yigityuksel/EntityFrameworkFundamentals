<ol>
<li>Install EF - package manager -&gt; install-package EntityFramework</li>
<li>Create Models</li>
<li>Add Context Class and inherit from DbContext</li>
<li>Add Models as DbSet&lt;&gt; items</li>
<li>Enable Migrations(just once) - package manager -&gt; enable-migrations</li>
<li>Create a new Migration. (after each change on model classes or add new model) - package manager -&gt; add-migration related_migration_name</li>
<li>After add new Migration - update-database apply changes on database</li>
<li>MigrationHistory can be shown at Database’s __MigrationHistory table.</li>
</ol>
<p>For example, we used a database which already exists.We create code-first model thourgh EF interface (add class - <a href="http://ADO.net">ADO.net</a> - CodeFirstFromDatabase selected)<br>
For classes comes from database, we will get an error when we try to create initial migration<br>
to solve it : add-migration InitalMigration -IgroneChanges -Force</p>
<p>Naming Conventions of Migrations<br>
model centric - AddCategory<br>
Database centric - AddCategoriesTable</p>
<p>Making Nullable : AddColumn(“table_name”, “column_name”, c =&gt; c.String(nullable: false));</p>
<p>Renaming on domain model. IF we rename item and create migrations we lose previous column and data.<br>
To Solve :</p>
<ol>
<li>RenameColumn(table_name, old_column_name, new_column_name) and we will remove Add-Drop Column Methods from Up() method.</li>
<li>SQL(UPDATE table_name SET new_column_name, old_column_name)</li>
</ol>
<p>IF we update Up method need to change Down method.</p>
<ol start="2">
<li>SQL(UPDATE table_name SET old_column_name, new_column_name)</li>
</ol>
<p>Downgrading database<br>
First Solution</p>
<ol>
<li>Checkout the older version</li>
<li>Change the db name in connection string</li>
<li>Update Database<br>
Second Solution</li>
<li>downgrade with migrations : update-database target _migration_name</li>
<li>make changes,</li>
<li>update-database to continue</li>
</ol>
<p>AutomaticMigrationsEnabled = false ;<br>
this is false, because we handling migrations manually, if we make true, migration creates automatically and if model changes apply changes.<br>
MigrationsNamespace = changes migration namespaces.</p>
<p>Seed method runs after update-database command. we can add new data.</p>
<p>Update-Database	-Script	-SourceMigration:0 creates all migrations from 0 scripts</p>
<p>Update-Database	-Script	-SourceMigration:Migr1	-TargetMigration:Migr2	create migration between source and target</p>