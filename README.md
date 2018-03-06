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

### LINQ Cheat Sheet

###### Restrictions
``` 
var query = from tempVariable in context.Courses
            where tempVariable.Level == 1
            select tempVariable;
``` 

###### Ordering
``` 
var query = from tempVariable in context.Courses
            where tempVariable.Author.Id == 1
            orderbt tempVariable.Level descending, tempVariable.Name
            select tempVariable;
``` 

###### Projection
``` 
var query = from tempVariable in context.Courses
            where tempVariable.Author.Id == 1
            orderbt tempVariable.Level descending, tempVariable.Name
            select new { Name = c.Name, Author = c.Author };
``` 

###### Groupping
``` 
var query = from tempVariable in context.Courses
            group c by c.Level into tempGroupVariable
            select g
``` 

###### Joining

Inner Join:

Use when there is no relationship between your entities and you need to link them based on a key.

1) It has navigation property, so we can easily use it
``` 
var query = from tempVariable in context.Courses
            select new { CourseName = tempVariable.Name, AuthorName = tempVariable.Author.Name }
``` 

2) Without navigation property
``` 
var query = from tempVariable in context.Courses
            join tempAuthorVariable in context.Authors on tempVariable.AuthorId equals tempAuthorVariable.Id
            select new { CourseName = tempVariable.Name, AuthorName = tempAuthorVariable.Name }
``` 

Group Join:

Useful when you need to group objects by a property and count the number of objects in each group. In SQL we do this with LEFT JOIN, COUNT(*) and GROUP BY. In LINQ, we use group join.

``` 
var query = from tempAuthorVariable in context.Authors
            join tempVariable in context.Courses on tempAuthorVariable.Id equals tempVariable.Id
            into groupVariable
            select new { AuthorName = tempAuthorVariable.Name, Courses = g.Count() }
``` 

CrossJoin:

To get full combinations of all objects on the left and the ones on the right. 

``` 
var query = from tempAuthorVariable in context.Authors
            from tempVariable in context.Courses
            select new { AuthorName = tempAuthorVariable.Name, Courses = tempVariable.Name }
``` 

### LINQ Extension Cheat Sheet

###### Restrictions
``` 
var query = context
            .Where(C => c.Level == 1);
``` 

###### Ordering
``` 
var query = context
            .Where(C => c.Level == 1)
            .OrderByDescending(c => c.Name)
            .ThenBy(c => c.Level);
``` 

###### Projection
``` 
var query = context
            .Where(C => c.Level == 1)
            .OrderByDescending(c => c.Name)
            .ThenBy(c => c.Level)
            .Select(c => new {
                CourseName = c.Name,
                AuthorName = c.Author.Name              
            });

var query = context
            .Where(C => c.Level == 1)
            .OrderByDescending(c => c.Name)
            .ThenBy(c => c.Level)
            .SelectMany(c => c.Tags);

var query = context
            .Where(C => c.Level == 1)
            .OrderByDescending(c => c.Name)
            .ThenBy(c => c.Level)
            .SelectMany(c => c.Tags).Distinct();
``` 

###### Groupping
``` 
var query = context.Courses.GroupBy(c => c.Level);
``` 

###### Joining

Inner Join:

Use when there is no relationship between your entities and you need to link them based on a key.

1) It has navigation property, so we can easily use it
``` 
var query = from tempVariable in context.Courses
            select new { CourseName = tempVariable.Name, AuthorName = tempVariable.Author.Name }
``` 

2) Without navigation property
``` 
var query = context.Courses.Join(context.Authors,
    c => c.AuthorId,
    a => a.Id,
    (course, author) => new
        {
        CourseName = course.Name,
        AuthorName = author.Name
    });
``` 

Group Join:

Useful when you need to group objects by a property and count the number of objects in each group. In SQL we do this with LEFT JOIN, COUNT(*) and GROUP BY. In LINQ, we use group join.

``` 
var query = context.Authors.GroupJoin(
    context.Courses,
    a => a.Id, 
    c => c.AuthorId, 
    (author, courses) => new {
        Author = author,
        Courses = courses   
    });
``` 

CrossJoin:

To get full combinations of all objects on the left and the ones on the right. 

``` 
var query = context.Authors.SelectMany(
    a => context.Courses, 
    (author, course) => new {
        AuthorName = author.Name,
        CourseName =	course.Name	 
    });
``` 

#### Methods that are not Supported by LINQ Syntax but in Extension Methods

###### Partitioning
``` 
var query = context.Courses.Skip(10).Take(10);
``` 

###### Element Operators
``` 
//throws an exception if no elements found		
context.Courses.First();	
context.Courses.First(c => c.Level == 1);	

//returns null if no elements found		
context.Courses.FirstOrDefault();

//not supported by SQL	Server	
context.Courses.Last();	
context.Courses.LastOrDefault();

context.Courses.Single(c=>c.Id == 1);
context.Courses.SingleOrDefault(c=> c.Id == 1);
```

###### Quantifying
``` 
bool allInLevel1 = context.Courses.All(c=> c.Level == 1);	

bool anyInLevel1 = context.Courses.Any(c=> c.Level == 1);	
``` 

###### Aggregating
``` 
int count = context.Courses.Count();	
int count = context.Courses.Count(c=> c.Level == 1);	

var max = context.Courses.Max(c	=> c.Price);	
var min = context.Courses.Min(c	=> c.Price);	
var avg = context.Courses.Average(c=> c.Price);	
var sum = context.Courses.Sum(c	=> c.Price);	
```  

#### Deferred Execution

Queries are not executed immediately.

Queries executed after : 
ToList, ToArray, ToDictionary
First, Last, Single, Count, Max, Min, Average.

#### IQueryable<> vs IEnumerable<>

In IQueryable<> queries added to end of queries(REAL SQL QUERY)
``` 
IQueryable<Course> res = context.Courses;
var filtered = res.Where(c => c.Level == 1).toList();	
```

In IEnumerable<> first fetch all data and then applies filter.
``` 
IEnumerable<Course> res = context.Courses;
var filtered = res.Where(c => c.Level == 1).toList();	
```  

#### Loading Related Objects

###### N+1 Problem :

When to use eager loading

1) In "one side" of one-to-many relations that you sure are used every where with main entity. like User property of an Article. Category property of a Product.
2) Generally When relations are not too much and eager loading will be good practice to reduce further queries on server.

When to use lazy loading

1) Almost on every "collection side" of one-to-many relations. like Articles of User or Products of a Category
2) You exactly know that you will not need a property instantly.

###### Lazy Loading

The virtual keywords, indicates lazy loading.

``` 
public virtual ICollection<Tag> Tags {get; set;}
``` 

Disable : 

On DbContext ctor.

``` 
this.Configuration.LazyLoadingEnabled = false;
``` 

This piece of code points N+1 Problem,the problem says that we fetching all course List(N) when we need to get author, fetching author with new query (+1)

```
var courses = context.Courses.ToList();
 
foreach (var course in courses)
    Console.WriteLine("{0} by {1}", course.Name, course.Author.Name);
``` 

###### Eager Loading

Eager Loading Bad Example, Magic String Used

``` 
var courseList = context.Courses.Include("Author").ToList();
``` 

object

``` 
var course_list = context.Courses.Include(a => a.Author).ToList();
``` 


single property

``` 
context.Courses.Include(a => a.Author.Name);
``` 

for collection property

``` 
context.Courses.Include(a => a.Tags);
``` 

collection bottom level loads.

``` 
context.Courses.Include(a => a.Tags.Select(t => t.Name));
``` 

###### Explicit Loading

``` 
var author = context.Authors.Include(a => a.Courses).Single(a => a.Id == 1).ToList();

foreach (var course in author.Courses)
    Console.WriteLine("{0}", course.Name);
``` 

convert to Explict Loading 

``` 
var author = context.Authors.Single(a => a.Id == 1).ToList();

//MSDN Way - works for only one object.
context.Entry(author).Collection(a => a.Courses).Load();

//Best Approach
context.Courses.Where(c => c.AuthorId == author.Id).Load();

foreach (var course in author.Courses)
    Console.WriteLine("{0}", course.Name);
``` 