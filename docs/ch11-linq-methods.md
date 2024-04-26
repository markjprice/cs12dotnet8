**LINQ extension methods**

Method(s)|Description
---|---
`First`, `FirstOrDefault`, `Last`, `LastOrDefault`|Get the first or last item in the sequence or throw an exception, or return the default value for the type, for example, `0` for an `int` and `null` for a reference type, if there is not a first or last item.
`Where`|Return a sequence of items that match a specified filter.
`Single`, `SingleOrDefault`|Return an item that matches a specific filter or throw an exception, or return the default value for the type if there is not exactly one match.
`ElementAt`, `ElementAtOrDefault`|Return an item at a specified index position or throw an exception, or return the default value for the type if there is not an item at that position. New in .NET 6 are overloads that can be passed an Index instead of an `int`, which is more efficient when working with `Span<T>` sequences.
`DefaultIfEmpty`|Returns the elements of an `IEnumerable<T>`, or a default valued singleton collection if the sequence is empty. For example, if the sequence is an empty `IEnumerable<int>`, it will return an `IEnumerable<int>` containing a single item `0`.
`SequenceEqual`|Returns `true` or `false` depending on whether two sequences are equal according to an equality comparer.
`Select`, `SelectMany`|Project items into a different shape, that is, a different type, and flatten a nested hierarchy of items.
`OrderBy`, `OrderByDescending`, `ThenBy`, `ThenByDescending`|Sort items by a specified field or property.
`Order`, `OrderDescending`|Sort items by the item itself.
`Reverse`|Reverse the order of the items.
`GroupBy`, `GroupJoin`, `Join`|Group and/or join two sequences.
`Skip`, `SkipWhile`, `SkipLast`|Skip a number of items; or skip when an expression is true; or the elements from source with the last count elements of the source collection omitted.
`Take`, `TakeWhile`, `TakeLast`|Take a number of items; or take items while an expression is true; or the last count elements from source. Introduced in .NET 6 is an overload that can be passed a Range, for example, `Take(range: 3..^5)`, meaning take a subset starting 3 items in from the start and ending 5 items in from the end, or instead of `Skip(4)` you could use `Take(4..)`.
`Aggregate`, `Average`, `Count`, `LongCount`, `Max`, `Min`, `Sum`|Calculate aggregate values.
`TryGetNonEnumeratedCount`|`Count()` checks if a `Count` property is implemented on the sequence and returns its value, or it enumerates the entire sequence to count its items. Introduced in .NET 6, this method only checks for `Count`; if it is missing, it returns `false` and sets the `out` parameter to `0` to avoid a potentially poor-performing operation.
`All`, `Any`, `Contains`|Returns `true` if all or any of the items match the filter, or if the sequence contains a specified item.
`Cast<T>`|Cast items into a specified type. It is useful to convert non-generic objects to a generic type in scenarios where the compiler would otherwise complain.
`OfType<T>`|Remove items that do not match a specified type.
`Distinct`|Remove duplicate items.
`Except`, `Intersect`, `Union`|Perform operations that return sets. Sets cannot have duplicate items. Although the inputs can be any sequence and so the inputs can have duplicates, the result is always a set.
`DistinctBy`, `ExceptBy`, `IntersectBy`, `UnionBy`, `MinBy`, `MaxBy`|Allow the comparison to be performed on a subset of the items rather than the entire items. For example, instead of removing duplicates with `Distinct` by comparing an entire `Person` object, you could remove duplicates with `DistinctBy` by comparing just their `LastName` and `DateOfBirth`.
`Chunk`|Divide a sequence into sized batches. The `size` parameter specified the number of items in each chunk. The last chunk will contain the remaining items and could be less than `size`.
`Append`, `Concat`, `Prepend`|Perform sequence-combining operations.
`Zip`|Perform a match operation on two or three sequences based on the position of items, for example, the item at position 1 in the first sequence matches the item at position 1 in the second sequence.
`ToArray`, `ToList`, `ToDictionary`, `ToHashSet`, `ToLookup`|Convert the sequence into an array or collection. These are the only extension methods that force the execution of a LINQ expression immediately rather than wait for deferred execution, which you will learn about shortly.
`AsEnumerable`|Returns the input sequence typed as `IEnumerable<T>`. This is useful when the type has its own implementation of any of the LINQ extension methods like `Where` and you want to call the standard LINQ `Where` method instead.

