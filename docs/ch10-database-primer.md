**Database Primer**

- [What is a database?](#what-is-a-database)
- [Tables, rows, and columns](#tables-rows-and-columns)
  - [Books table](#books-table)
- [Primary keys](#primary-keys)
- [Understanding SQL](#understanding-sql)

# What is a database?

A **database** is like a digital filing cabinet where you can store, organize, and retrieve data. It's a structured collection of information that can be easily accessed, managed, and manipulated. Think of it as a way to store data in a systematic and efficient manner.

Databases come in various types, including **relational databases** (like SQL Server, MySQL, and PostgreSQL), NoSQL databases (like Cosmos DB, MongoDB, and Cassandra), and more specialized options for specific purposes.

A relational database consists of **tables** that store related data. Each table is made up of **rows** and **columns**, with each row representing a single **record** or **entity**, and each column representing a specific **attribute** or piece of information about that record. For example, if you have a database for a library, you might have a "Books" table with columns for book titles, authors, publication dates, and so on.

One of the key advantages of databases is their ability to perform queries, which are requests for specific information from the data. You can use a query to search for records that meet certain criteria, sort data, calculate statistics, and much more.

Databases are essential for storing and retrieving data in applications, and they play a crucial role in web development, data analysis, and many other fields. 

# Tables, rows, and columns

In a relational database, tables, rows, and columns are fundamental components that structure and organize the data.

**Tables** are the core structure in a relational database. They are like spreadsheets or data containers where you store specific types of data.
Each table is designed to hold data related to a particular entity or concept. For example, in a library database, you might have a "Books" table to store information about books and a "Authors" table to store information about authors. Tables are defined with a name and a set of columns that represent the attributes or properties of the data you want to store.

**Rows**, also known as records or entities, are horizontal entries within a table. Each row in a table represents a single data instance or record. For instance, in a `Books` table, each row might correspond to a specific book with details like title, author, publication date, and so on. Rows contain the actual data, and each row should have a unique identifier, typically referred to as a primary key.

**Columns**, also known as fields or attributes, are vertical elements within a table. Each column represents a specific piece of information or attribute related to the data in the table. For example, in a `Books` table, you might have columns like `Title`, `Author`, `Publication Date`, and `ISBN`. Columns define the structure and data type of the information stored in them. For instance, the `Publication Date` column may be of the `date` data type, while the `ISBN` column may be of the `text` data type.

Here's an example:

## Books table

ISBN|Title|Author|Publication Date
---|---|---|---
978-0451526531|To Kill a Mockingbird|Harper Lee|1960-07-11
978-1982137274|1984|George Orwell|1949-06-08
978-0141187761|The Great Gatsby|F. Scott Fitzgerald|1925-04-10

In this example, `Books` is a table, each row represents a specific book, and each column (`ISBN`, `Title`, `Author`, `Publication Date`) holds different attributes of those books.

This structured organization of data into tables, rows, and columns is what makes relational databases efficient for storing and retrieving information, and it allows for complex queries and relationships between different tables.

# Primary keys

A **primary key** is a unique identifier for each row in a table. It ensures that each record is distinct. In the `Books` table, the `ISBN` column or attribute is the primary key. You can combine multiple columns as a primary key if a single column does not provide unique values.

A **foreign key** is used to establish relationships between tables. A foreign key in one table refers to the primary key in another table, creating a link between them.

# Understanding SQL

**Structured Query Language (SQL)** is a language for working with databases. It's used to create, retrieve, update, and delete data. SQL is primarily associated with relational databases.

There are different dialects of SQL, such as MySQL, PostgreSQL, Oracle SQL, and Transact-SQL (used by SQL Server). While they share common features, there can be slight variations in syntax and functions.

SQL is a fundamental skill for anyone dealing with databases, and it's widely used in web development, data analysis, and various other fields. Learning SQL allows you to interact with and manipulate data efficiently within relational databases. 
