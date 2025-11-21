# Polynomial

A library for advanced operations with polynomial expressions. This project is based on Morteza Alikhani's [Polynomial.Net](https://www.codeproject.com/Articles/83394/Polynomial-Net) project. It adds many additional features and has been refactored to follow SOLID principles.

## Recent Improvements

This library has been refactored to apply SOLID principles and modern design patterns. See [SOLID_IMPROVEMENTS.md](SOLID_IMPROVEMENTS.md) for details.

### Key Features
- **Interface-based design**: Uses `IPolynomial`, `ITerm`, and other interfaces for better abstraction
- **Separation of concerns**: Parser, operations, and business logic are separated
- **Extensible operations**: New operations can be added without modifying existing code
- **Factory pattern**: `PolynomialFactory` for cleaner object creation
- **Constants**: No magic numbers - all constants are centralized
- **Improved performance**: Better sorting algorithms (O(n log n) instead of O(n²))

## Basic Usage

### Creating Polynomials

```csharp
// Traditional way (still supported)
var poly1 = new Poly("3x^2 + 2x - 1");

// Using factory (recommended)
var factory = new PolynomialFactory();
var poly2 = factory.Create("3x^2 + 2x - 1", 0, 10);
```

### Performing Operations

```csharp
// Integration
var integrated = poly1.Integrate();

// Differentiation
var derivative = poly1.Derivate();

// Calculate value at x
double value = poly1.Calculate(5.0);

// Find roots
var roots = poly1.Roots();
```

### Using Operations Directly

```csharp
// More testable and follows OCP
var integrationOp = new IntegrationOperation();
var result = integrationOp.Execute(poly1);

var rootFinder = new RootFinder();
var roots = rootFinder.Execute(poly1);
```

## Architecture

The library is now organized into logical namespaces:

- **Polynomial.Interfaces**: Contracts and abstractions
- **Polynomial.Parsers**: Parsing logic
- **Polynomial.Operations**: Mathematical operations
- **Polynomial.Factories**: Object creation patterns

