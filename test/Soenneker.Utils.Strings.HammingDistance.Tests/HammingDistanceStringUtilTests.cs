using Soenneker.Tests.HostedUnit;

using AwesomeAssertions;
using System;

namespace Soenneker.Utils.Strings.HammingDistance.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class HammingDistanceStringUtilTests : HostedUnitTest
{
    public HammingDistanceStringUtilTests(Host host) : base(host)
    {
    }

    [Test]
    [Arguments("", "", 100.0)] // Empty strings are identical
    [Arguments("a", "b", 0.0)] // Completely different single characters
    [Arguments("abc", "def", 0.0)] // Completely different strings
    [Arguments("abc", "abc", 100.0)] // Identical strings
    [Arguments("1010", "1111", 50.0)] // Two differences out of four
    [Arguments("kitten", "sitten", (5.0 / 6.0) * 100)] // One difference out of six
    [Arguments("abcdef", "abcxyz", 50.0)] // Half are different
    public void CalculateSimilarityPercentage_Returns_Correct_Percentage(string str1, string str2, double expectedPercentage)
    {
        double similarityPercentage = HammingDistanceStringUtil.CalculatePercentage(str1, str2);

        similarityPercentage.Should().BeApproximately(expectedPercentage, 0.001);
    }

    [Test]
    [Arguments("abc", "abcd")] // Unequal length, should throw exception
    [Arguments("", "a")] // Unequal length, should throw exception
    public void CalculateSimilarityPercentage_Throws_ArgumentException_For_Unequal_Lengths(string str1, string str2)
    {
        Action act = () => HammingDistanceStringUtil.CalculatePercentage(str1, str2);

        act.Should().Throw<ArgumentException>().WithMessage("Strings must be of equal length*");
    }

    [Test]
    [Arguments("", "", 1.0)] // Empty strings are identical
    [Arguments("a", "b", 0.0)] // Completely different single characters
    [Arguments("abc", "def", 0.0)] // Completely different strings
    [Arguments("abc", "abc", 1.0)] // Identical strings
    [Arguments("1010", "1111", 0.5)] // Two differences out of four
    [Arguments("kitten", "sitten", 5.0 / 6.0)] // One difference out of six
    [Arguments("abcdef", "abcxyz", 0.5)] // Half are different
    public void CalculateSimilarity_Returns_Correct_Similarity_Score(string str1, string str2, double expectedScore)
    {
        double similarityScore = HammingDistanceStringUtil.Calculate(str1, str2);

        similarityScore.Should().BeApproximately(expectedScore, 0.001);
    }

    [Test]
    [Arguments("abc", "abcd")] // Unequal length, should throw exception
    [Arguments("", "a")] // Unequal length, should throw exception
    public void CalculateSimilarity_Throws_ArgumentException_For_Unequal_Lengths(string str1, string str2)
    {
        Action act = () => HammingDistanceStringUtil.Calculate(str1, str2);

        act.Should().Throw<ArgumentException>().WithMessage("Strings must be of equal length*");
    }

}

