[![](https://img.shields.io/nuget/v/soenneker.utils.strings.hammingdistance.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.strings.hammingdistance/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.strings.hammingdistance/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.strings.hammingdistance/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.strings.hammingdistance.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.strings.hammingdistance/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.Strings.HammingDistance
### A utility library for comparing strings via the Hamming Distance algorithm

## Installation

```
dotnet add package Soenneker.Utils.Strings.HammingDistance
```

## Why Hamming Distance?

Hamming Distance is a simple yet powerful metric for comparing strings or sequences of equal length. It is especially useful in scenarios where exact alignment and positional differences matter, such as:

### Positional Accuracy:
Hamming Distance identifies and quantifies differences at each specific position in two sequences.

### Binary or Fixed-Length Data:
It is ideal for comparing fixed-length strings, binary data, or encoded sequences.

### Lightweight and Efficient:
Hamming Distance has low computational overhead, making it well-suited for performance-critical applications.

### Ideal for Error Detection:
It is commonly used in error detection and correction algorithms, like detecting bit-flip errors in transmitted data.

---

## Usage

```csharp
var text1 = "kitten";
var text2 = "sitten";

double similarityPercentage = HammingDistanceStringUtil.CalculatePercentage(text1, text2); // ~83.33
```

### Note:
Hamming Distance requires strings of **equal length**. If the strings differ in length, an exception will be thrown to ensure valid comparisons.