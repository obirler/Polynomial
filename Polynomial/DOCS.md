# Polynomial Documentation

## Class: ConjugateTerm

### Description of ConjugateTerm

The ConjugateTerm class represents a term in a polynomial expression. It stores the power and coefficient of the term.

### Methods of ConjugateTerm

- `ConjugateTerm(double power, string coefficient)`: Constructs a new instance of the ConjugateTerm class with the specified power and coefficient.
- `ConjugateTerm(string termExpression)`: Constructs a new instance of the ConjugateTerm class by parsing the term expression.

### Example of ConjugateTerm

```csharp
ConjugateTerm term = new ConjugateTerm(2, "3x");
```

## Class: TermCollection

### Description of TermCollection

The TermCollection class represents a collection of terms in a polynomial expression. It provides methods for sorting and manipulating the terms.

### Methods of TermCollection

- `void Sort(SortType order)`: Sorts the terms in the collection in ascending or descending order.

### Example of TermCollection

```csharp
TermCollection collection = new TermCollection();
collection.Add(new Term(2, "3x"));
collection.Add(new Term(1, "2x"));
collection.Sort(SortType.ASC);
```
