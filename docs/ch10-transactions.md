**Working with transactions**

- [Understanding transactions](#understanding-transactions)
- [Implicit transactions](#implicit-transactions)
- [Controlling transactions using isolation levels](#controlling-transactions-using-isolation-levels)
- [Defining an explicit transaction](#defining-an-explicit-transaction)

# Understanding transactions

Transactions maintain the integrity of your database by applying locks to prevent reads and writes while a sequence of changes is occurring.

Transactions are **ACID**, which is an acronym explained in the following list:
- **A** is for *atomic*. Either all the operations in the transaction commit, or none of them do.
- **C** is for *consistent*. The state of the database before and after a transaction is consistent. This is dependent on your code logic; for example, when transferring money between bank accounts, it is up to your business logic to ensure that if you debit $100 in one account, you credit $100 in the other account.
- **I** is for *isolated*. During a transaction, changes are hidden from other processes. There are multiple isolation levels that you can pick from (refer to the following table). The stronger the level, the better the integrity of the data. However, more locks must be applied, which will negatively affect other processes. Snapshot is a special case because it creates multiple copies of rows to avoid locks, but this will increase the size of your database while transactions occur.
- **D** is for *durable*. If a failure occurs during a transaction, it can be recovered. This is often implemented as a two-phase commit and transaction logs. Once the transaction is committed, it is guaranteed to endure even if there are subsequent errors. The opposite of durable is volatile.

# Implicit transactions

Every time you call the `SaveChanges` method, an implicit transaction is started so that if something goes wrong, it will automatically roll back all the changes. If the multiple changes within the transaction succeed, then the transaction and all changes are committed.

# Controlling transactions using isolation levels

A developer can control transactions by setting an isolation level, as described in the following table:

Isolation level|Lock(s)|Integrity problems allowed
---|---|---
ReadUncommitted|None|Dirty reads, non-repeatable reads, and phantom data.
ReadCommitted|When editing, it applies read lock(s) to block other users from reading the record(s) until the transaction ends.|Non-repeatable reads and phantom data.
RepeatableRead|When reading, it applies edit lock(s) to block other users from editing the record(s) until the transaction ends|Phantom data.
Serializable|It applies key-range locks to prevent any action that would affect the results, including inserts and deletes|None
Snapshot|None|None

# Defining an explicit transaction

You can control explicit transactions using the Database property of the database context:

1.	In `Program.Modifications.cs`, import the EF Core storage namespace to use the `IDbContextTransaction` interface, as shown in the following code:
```cs
using Microsoft.EntityFrameworkCore.Storage; // To use IDbContextTransaction.
```

2.	In the `DeleteProducts` method, after the instantiation of the `db` variable, add statements to start an explicit transaction and output its isolation level. At the bottom of the method, commit the transaction, and close the brace, as shown in the following code:
```cs
static int DeleteProducts(string productNameStartsWith)
{
  using (Northwind db = new())
  {
    using (IDbContextTransaction t = db.Database.BeginTransaction())
    {
      WriteLine("Transaction isolation level: {0}",
        arg0: t.GetDbTransaction().IsolationLevel);

      IQueryable<Product>? products = db.Products?.Where(
        p => p.ProductName.StartsWith(productNameStartsWith));

      if ((products is null) || (!products.Any()))
      {
        WriteLine("No products found to delete.");
        return 0;
      }
      else
      {
        db.Products.RemoveRange(products);
      }

      int affected = db.SaveChanges();
      t.Commit();
      return affected;
    }
  }
}
```
2.	Run the code and view the result using SQLite, as shown in the following output:
```
Transaction isolation level: Serializable
```
If you were to use SQL Server, you would see the following output: 
```
Transaction isolation level: ReadCommitted
```
