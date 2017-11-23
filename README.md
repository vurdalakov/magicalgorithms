# MagicAlgorithms

#### Overview

**MagicAlgorithms** is a .NET Core class library that implements some of [The Aggregate Magic Algorithms](http://aggregate.org/MAGIC/) in C# language.

Unit tests exist for all of them.

#### Supported methods

###### IsOnlyOneBitSet

Checks if one single bit is set in a value.

Supported types: `Int32`, `UInt32`, `Int64`, `UInt64` and `enum` with one of the above underlying types.

```
var value = 123;
if (value.IsOnlyOneBitSet)
{
    Console.WriteLine($"Only one bit is set in {value}");
}
```
