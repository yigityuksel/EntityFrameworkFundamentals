#### Enabling Code-First
1) Install EF - package manager - install-package EntityFramework

2) Create Models

3) Add Context Class and inherit from DbContext

4) Add Models as DbSet&lt;&gt; items

5) Enable Migrations(just once) - package manager -&gt; enable-migrations

6) Create a new Migration. (after each change on model classes or add new model) - package manager -&gt; add-migration related_migration_name

7) After add new Migration - update-database apply changes on database

8) MigrationHistory can be shown at Database’s __MigrationHistory table.

For example, we used a database which already exists.We create code-first model thourgh EF interface (add class - <a href="http://ADO.net">ADO.net</a> - CodeFirstFromDatabase selected) 

For classes comes from database, we will get an error when we try to create initial migration to solve it : 

`add-migration InitalMigration -IgroneChanges -Force`

#### Naming Conventions of Migrations

model centric - `AddCategory`

Database centric - `AddCategoriesTable`

Making Nullable - `AddColumn(“table_name”, “column_name”, c =&gt; c.String(nullable: false));`

Renaming on domain model. If we rename item and create migrations we lose previous column and data.

To Solve :

`RenameColumn(table_name, old_column_name, new_column_name)`

and we will remove Add-Drop Column Methods from Up() method.

`SQL(UPDATE table_name SET new_column_name, old_column_name)`

If we update Up method need to change Down method.

`SQL(UPDATE table_name SET old_column_name, new_column_name)`

##### Downgrading database

First Solution

1) Checkout the older version
2) Change the db name in connection string
3) Update Database

Second Solution

1) downgrade with migrations : update-database target _migration_name
2) make changes,
3) update-database to continue


this is false, because we handling migrations manually, if we make true, migration creates automatically and if model changes apply changes.

`AutomaticMigrationsEnabled = false ;`

MigrationsNamespace = changes migration namespaces. Seed method runs after update-database command. we can add new data.

creates all migrations from 0 scripts
`Update-Database	-Script	-SourceMigration:0`

create migration between source and target
`Update-Database	-Script	-SourceMigration:Migr1	-TargetMigration:Migr2`

## Data Annotations Cheat Sheet


###### Table Names
 
Initially Table names are class names.
 
```
[Table("tbl_Course")]//overrides table name
[Table("tbl_Course", Schema = "Catalog")]
public class Course() {}
```
 
 
###### Column Names
 
Initially table property names are class property names.
 
```
[Column("sName" ,TypeName = "varchar")]
public string Name {get; set;}
```
###### Primary Key
 
Property named ID or [ClassName]ID (int) automatically Primary KEY with Identity.

``` 
[Key]
[DatabaseGenerated(DatabaseGeneratedOption.None)] --> tells that, its not identity column.
public string ISBN {get; set;}
```
 
###### Composite Keys
 
```
[Key]
[Column(Order = 1)]
public int OrderId {get; set;}

[Key]
[Column(Order = 2)]
public int OrderItemId {get; set;}
``` 
###### Nullable

``` 
[Required] //not affect class property, when save it to db throws exception.
public string Name {get; set;}
```
 
###### Length 

```
[MaxLength(255)]
public string Name {get; set;}
```
 
###### Index

``` 
[Index]
public string Name {get; set;}
 
[Index(IsUnique = true)] - ensures that property is unique.
public string Name {get; set;}
 
[Index("IX_AuthorStudentsCount", 1)] //index name, order of column
public int AuthorId {get; set;}
 
[Index("IX_AuthorStudentsCount", 2)]
public int StudentCount {get; set;}
 
```
###### Foreign Keys
 
```
public int AuthorId {get; set;} // creates a new column
 
public Author Author {get; set;} // if we use just this, EF creates foreign key named Author_Id
 
```
we need to link them.
 
First Way :
 
```
public int AuthorId {get; set;}
 
[ForeignKey("AuthorId")]
public Author Author {get; set;}

 ```

Second Way:

``` 
[ForeignKey("Author")]
public int AuthorId {get; set;}
 
public Author Author {get; set;}
 ```

## FluentAPI Cheat Sheet


### Basics
``` 
modelBuilder.Entity<Course>();
``` 

###### Override table name
``` 
modelBuilder.Entity<Course>().ToTable("tbl_Course", "catalog");
``` 

###### Primary Key
```  
modelBuilder.Entity<Course>().HasKey(a => a.Id);
``` 

###### Composite key
``` 
modelBuilder.Entity<Course>().HasKey(t => new { t.Id, t.Level });
``` 

###### Column names
``` 
modelBuilder.Entity<Course>().Property(t => t.Name).HasColumnName("Sname");
``` 

###### Column types
``` 
modelBuilder.Entity<Course>().Property(t => t.Name).HasColumnType("varchar");
``` 

###### Column order
``` 
modelBuilder.Entity<Course>().Property(t => t.Name).HasColumnOrder(2);
``` 

###### Database generated.
``` 
modelBuilder.Entity<Course>().Property(t => t.Id)
.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
``` 

###### Nulls
``` 
modelBuilder.Entity<Course>().Property(t => t.Name).IsRequired();
``` 

###### Length of strings
``` 
modelBuilder.Entity<Course>().Property(t => t.Name).HasMaxLength(255);
``` 

###### Max length
``` 
modelBuilder.Entity<Course>().Property(t => t.Name).IsMaxLength();
``` 

### Relationships

#### One To Many 

Author(1) ----------> Course(*)

``` 
modelBuilder
.Entity<Author>()
.HasMany(a => a.Courses);
``` 

###### reverse direction 

Author(1) <---------- Course(*)

``` 
modelBuilder
.Entity<Author>()
.HasMany(a => a.Courses)
.WithRequired(a => c.Author)
.HasForeignKey(c => c.AuthorId);//has foreign key optionally give. (overrides Author_Id)
``` 

#### Many To Many 

Course(*) ----------> Tag(*)

``` 
modelBuilder
.Entity<Course>()
.HasMany(a => a.Tags);
``` 

###### reverse direction 

Course(*) <---------- Tag(*)

``` 
modelBuilder
.Entity<Course>()
.HasMany(a => a.Tags)
.WithMany(t => t.Courses)
.Map(a => a.ToTable("CourseTags"));//we can override intermediate table.
``` 

When we do it, it create intermediate table with Course_Id and Tag_Id. We do not want this. To solve that,

``` 
//modelBuilder.Entity<Course>()
//    .HasMany(a => a.Tags)
//    .WithMany(a => a.Courses)
//    .Map(a => a.ToTable("CourseTags"));

modelBuilder.Entity<Course>()
    .HasMany(a => a.Tags)
    .WithMany(a => a.Courses)
    .Map(a =>
        {
            a.ToTable("CourseTags");
            a.MapLeftKey("CourseId");
            a.MapRightKey("TagId");
    });
``` 

#### One To Zero to One 

Course(1) ----------> Caption(0..1)

``` 
modelBuilder
.Entity<Course>()
.HasOptional(c => c.Caption);
``` 

###### reverse direction 

Course(1) <---------- Caption(0..1)

``` 
modelBuilder
.Entity<Course>()
.HasMany(a => a.Caption)
.WithRequired(t => t.Course);
``` 

#### One To One 

Course(1) ----------> Cover(1)

``` 
modelBuilder
.Entity<Course>()
.HasRequired(c => c.Cover);
``` 

###### reverse direction 

Course(1) <---------- Cover(1)

principal => parent
dependent => child

EF doesnt know which is parent or not, we need to supply it.

``` 
modelBuilder
.Entity<Course>()
.HasRequired(c => c.Cover)
.WithRequiredPrincipal(c => c.Course);
``` 