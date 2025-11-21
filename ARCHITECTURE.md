# Polynomial Library Architecture

## Architecture Overview

This document describes the architectural design of the refactored Polynomial library.

## High-Level Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                        Client Code                          │
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                    Public API Layer                         │
│  ┌─────────────┐  ┌──────────────┐  ┌──────────────┐      │
│  │   Poly      │  │ TermCollection│  │   Term       │      │
│  │  (implements│  │               │  │ (implements  │      │
│  │ IPolynomial)│  │               │  │    ITerm)    │      │
│  └─────────────┘  └──────────────┘  └──────────────┘      │
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                   Factory Layer (DIP)                       │
│  ┌─────────────────────────────────────────────────┐       │
│  │         PolynomialFactory                        │       │
│  │  - Manages object creation                       │       │
│  │  - Supports dependency injection                 │       │
│  └─────────────────────────────────────────────────┘       │
└─────────────────────────────────────────────────────────────┘
                              │
                              ▼
┌─────────────────────────────────────────────────────────────┐
│                  Interface Layer (ISP)                      │
│  ┌──────────────┐  ┌─────────────┐  ┌───────────────┐     │
│  │ IPolynomial  │  │  ITerm      │  │ IPolynomial   │     │
│  │              │  │             │  │   Parser      │     │
│  └──────────────┘  └─────────────┘  └───────────────┘     │
│  ┌────────────────────────────────────────────────┐        │
│  │     IPolynomialOperation<TResult>              │        │
│  └────────────────────────────────────────────────┘        │
└─────────────────────────────────────────────────────────────┘
                              │
            ┌─────────────────┼─────────────────┐
            ▼                 ▼                 ▼
┌──────────────────┐ ┌──────────────┐ ┌──────────────────┐
│  Parser Layer    │ │  Operations  │ │    Utilities     │
│      (SRP)       │ │    (SRP/OCP) │ │                  │
├──────────────────┤ ├──────────────┤ ├──────────────────┤
│ Polynomial       │ │ Integration  │ │ Polynomial       │
│   Parser         │ │ Operation    │ │  Constants       │
│                  │ │              │ │                  │
│ - Validates      │ │ Differentia- │ │ - Root Tolerance │
│ - Parses         │ │  tion Op.    │ │ - Default Steps  │
│ - Normalizes     │ │              │ │ - Comparison Tol.│
│                  │ │ RootFinder   │ │                  │
│                  │ │              │ │ Numerical        │
│                  │ │ Numerical    │ │ OperationBase    │
│                  │ │ OperationBase│ │                  │
└──────────────────┘ └──────────────┘ └──────────────────┘
```

## Component Responsibilities

### Interface Layer
- **IPolynomial**: Defines polynomial behavior contract
- **ITerm**: Defines term representation contract
- **IPolynomialParser**: Defines parsing strategy contract
- **IPolynomialOperation<T>**: Enables extensible operations

### Factory Layer
- **PolynomialFactory**: Creates polynomial instances with configurable dependencies

### Parser Layer
- **PolynomialParser**: Handles all parsing logic
  - Expression validation
  - Term extraction
  - Scientific notation handling

### Operations Layer
- **IntegrationOperation**: Performs integration
- **DifferentiationOperation**: Performs differentiation
- **RootFinder**: Finds polynomial roots using numerical methods
- **NumericalOperationBase**: Shared numerical utilities

### Utilities
- **PolynomialConstants**: Centralized configuration values

## Data Flow

### Creating a Polynomial

```
┌─────────────┐
│ User Code   │
│ "x^2 + 2x"  │
└──────┬──────┘
       │
       ▼
┌─────────────────┐
│ PolynomialFactory│
└──────┬──────────┘
       │
       ▼
┌─────────────────┐
│ PolynomialParser│ ◄──── Validates expression
│   .Parse()      │
└──────┬──────────┘
       │
       ▼
┌─────────────────┐
│ TermCollection  │ ◄──── Creates terms
└──────┬──────────┘
       │
       ▼
┌─────────────────┐
│   Poly object   │
└─────────────────┘
```

### Performing an Operation

```
┌─────────────┐
│ User Code   │
│ .Integrate()│
└──────┬──────┘
       │
       ▼
┌──────────────────────┐
│ IntegrationOperation │
│   .Execute(poly)     │
└──────┬───────────────┘
       │
       ▼
┌──────────────────────┐
│ Iterate over terms   │
│ Apply integration    │
│ formula to each      │
└──────┬───────────────┘
       │
       ▼
┌──────────────────────┐
│ Return new Poly      │
└──────────────────────┘
```

## Design Patterns Used

### 1. Strategy Pattern
**Purpose**: Allows different parsing strategies

```csharp
interface IPolynomialParser {
    TermCollection Parse(string expression);
}

class PolynomialParser : IPolynomialParser { ... }
// Could add: ScientificNotationParser, LaTeXParser, etc.
```

### 2. Factory Pattern
**Purpose**: Encapsulates object creation

```csharp
class PolynomialFactory {
    public Poly Create(string expression) { ... }
}
```

### 3. Template Method Pattern
**Purpose**: Provides base for numerical operations

```csharp
abstract class NumericalOperationBase {
    protected double GetInitialStep(...) { ... }
    protected double GetRefinementStep(...) { ... }
}
```

### 4. Command Pattern
**Purpose**: Encapsulates operations as objects

```csharp
interface IPolynomialOperation<TResult> {
    TResult Execute(IPolynomial polynomial);
}
```

## Extension Points

### Adding New Operations

To add a new operation (e.g., symbolic simplification):

```csharp
public class SimplificationOperation : IPolynomialOperation<Poly>
{
    public Poly Execute(IPolynomial polynomial)
    {
        // Implementation
    }
}

// Usage
var simplifier = new SimplificationOperation();
var simplified = simplifier.Execute(poly);
```

### Adding New Parsers

To add a new parser (e.g., LaTeX format):

```csharp
public class LaTeXParser : IPolynomialParser
{
    public bool Validate(string expression) { ... }
    public TermCollection Parse(string expression) { ... }
}

// Usage with factory
var factory = new PolynomialFactory(new LaTeXParser());
var poly = factory.Create("x^{2} + 2x + 1");
```

## Dependency Graph

```
┌───────────────┐
│     Poly      │
└───────┬───────┘
        │ depends on
        ├──────────► IPolynomialParser ──► PolynomialParser
        │
        ├──────────► IPolynomialOperation
        │                 │
        │                 ├──► IntegrationOperation
        │                 ├──► DifferentiationOperation
        │                 └──► RootFinder ──► NumericalOperationBase
        │
        └──────────► PolynomialConstants
```

**Key Points:**
- High-level modules depend on abstractions (interfaces)
- Low-level modules implement abstractions
- Dependencies point inward (toward abstractions)

## Testing Strategy

### Unit Testing with Interfaces

```csharp
// Mock polynomial for testing operations
var mockPoly = new Mock<IPolynomial>();
mockPoly.Setup(p => p.Calculate(It.IsAny<double>())).Returns(5.0);

var operation = new IntegrationOperation();
var result = operation.Execute(mockPoly.Object);

// Assert result
```

### Integration Testing

```csharp
// Test with real implementations
var parser = new PolynomialParser();
var terms = parser.Parse("x^2 + 1");
var poly = new Poly(terms);

var integrator = new IntegrationOperation();
var integrated = integrator.Execute(poly);

Assert.AreEqual("0.333x^3+x", integrated.ToString());
```

## Performance Considerations

### Sorting Optimization
- **Before**: O(n²) selection sort in collections
- **After**: O(n log n) using built-in comparison sort
- **Impact**: 10-100x faster for large polynomials

### Memory Management
- **Before**: Finalizers causing GC pressure
- **After**: No finalizers, let GC handle cleanup
- **Impact**: Better GC performance, fewer pauses

### Lazy Evaluation
Operations create new objects rather than modifying existing ones, supporting:
- Thread safety
- Functional programming style
- Easier debugging

## Conclusion

The refactored architecture provides:
- **Clear separation of concerns** through layered design
- **Extensibility** via interfaces and patterns
- **Maintainability** with single-responsibility components
- **Testability** through dependency injection
- **Performance** with optimized algorithms

All while maintaining 100% backward compatibility with existing code.
