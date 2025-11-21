# Polynomial.Tests

This test project contains comprehensive unit tests for the Polynomial library.

## Test Framework

- **Framework**: MSTest
- **Target**: .NET 8.0 (testing .NET Framework 4.8 library via source inclusion)
- **Test Count**: 55 tests covering all major functionalities

## Running Tests

To run all tests:

```bash
dotnet test Polynomial.Tests/Polynomial.Tests.csproj
```

To run tests with detailed output:

```bash
dotnet test Polynomial.Tests/Polynomial.Tests.csproj --verbosity normal
```

## Test Coverage

### PolyTests.cs (25 tests)
Tests for the main `Poly` class:
- Constructor variations
- Calculation methods
- Integration and differentiation
- Arithmetic operations (addition, subtraction, multiplication, division)
- Polynomial properties (degree, isConstant, isLinear)
- String parsing and validation
- Mathematical operations (square, cube)

### TermTests.cs (14 tests)
Tests for the `Term` class:
- Constructor with power and coefficient
- String expression parsing
- Various term formats (linear, constant, negative coefficients)
- String representation
- Property getters and setters

### PolynomialParserTests.cs (10 tests)
Tests for the `PolynomialParser` class:
- Expression validation
- Parsing various polynomial formats
- Scientific notation handling
- Error handling for invalid expressions
- Whitespace and sign normalization

### IntegrationOperationTests.cs (4 tests)
Tests for the `IntegrationOperation` class:
- Integration of simple polynomials
- Integration of linear polynomials
- Integration of constants
- Integration of polynomials with multiple terms

### DifferentiationOperationTests.cs (4 tests)
Tests for the `DifferentiationOperation` class:
- Differentiation of quadratic polynomials
- Differentiation of cubic polynomials
- Differentiation of linear polynomials
- Differentiation of polynomials with multiple terms

### PolynomialFactoryTests.cs (4 tests)
Tests for the `PolynomialFactory` class:
- Creating polynomials from expressions
- Creating polynomials with specified ranges
- Creating polynomials from term collections
- Creating polynomials from single terms

## Test Results

All 55 tests pass successfully, validating:
- ✅ Core polynomial operations
- ✅ Parsing and validation
- ✅ Mathematical operations (calculus, arithmetic)
- ✅ SOLID principles implementation (operations, factory)
- ✅ Edge cases and error handling

## Note on .NET Framework 4.8

Since the original Polynomial library targets .NET Framework 4.8 which isn't available in all CI environments, this test project uses .NET 8.0 and includes the source files directly. This ensures tests can run in modern .NET environments while maintaining compatibility with the original library's behavior.
