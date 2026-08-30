[![](https://img.shields.io/nuget/v/soenneker.utils.strings.hammingdistance.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.strings.hammingdistance/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.strings.hammingdistance/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.strings.hammingdistance/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.utils.strings.hammingdistance.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.utils.strings.hammingdistance/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.strings.hammingdistance/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.strings.hammingdistance/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.Strings.HammingDistance
Normalized positional similarity for equal-length strings using Hamming distance.

## Installation

```bash
dotnet add package Soenneker.Utils.Strings.HammingDistance
```

## Usage

```csharp
using Soenneker.Utils.Strings.HammingDistance;

var text1 = "kitten";
var text2 = "sitten";

double score = HammingDistanceStringUtil.Calculate(text1, text2);
double percentage = HammingDistanceStringUtil.CalculatePercentage(text1, text2);

// score is approximately 0.8333
// percentage is approximately 83.33
```

`Calculate` does not return the raw Hamming distance. It returns normalized similarity:

```text
1 - differing positions / string length
```

The result ranges from `0` when every position differs to `1` when the strings are identical. `CalculatePercentage` multiplies that value by 100. Two empty strings return `1` (or `100%`).

## Requirements and comparison rules

- Inputs must have equal length; otherwise both methods throw `ArgumentException`.
- Comparison is case-sensitive.
- Positions contain UTF-16 code units, not Unicode scalar values or grapheme clusters.
- Whitespace and punctuation participate like any other character.
- Both arguments must be non-null.

The calculation is linear in the input length and allocates no comparison data structures. It is a good fit for aligned identifiers, fixed-width codes, or other sequences where a character at one position should only be compared with the character at the same position. Use edit distance instead when insertions or deletions should shift subsequent alignment.
