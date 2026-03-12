using System.Diagnostics.Contracts;
using System;

namespace Soenneker.Utils.Strings.HammingDistance;

/// <summary>
/// A utility library for comparing strings via the Hamming Distance algorithm
/// </summary>
public static class HammingDistanceStringUtil
{
    /// <summary>
    /// Calculates the similarity percentage between two strings via Hamming Distance.
    /// </summary>
    /// <param name="s1">The first string.</param>
    /// <param name="s2">The second string.</param>
    /// <returns>The similarity percentage between the two strings.</returns>
    [Pure]
    public static double CalculatePercentage(string s1, string s2)
    {
        double similarity = Calculate(s1, s2);
        double percentageMatch = similarity * 100;

        return percentageMatch;
    }

    /// <summary>
    /// Calculates the similarity score between two strings using the Hamming Distance.
    /// </summary>
    /// <param name="s1">The first string.</param>
    /// <param name="s2">The second string.</param>
    /// <returns>The similarity score between the two strings.</returns>
    [Pure]
    public static double Calculate(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            throw new ArgumentException("Strings must be of equal length to calculate Hamming Distance.");

        if (s1.Length == 0 && s2.Length == 0)
            return 1.0;

        var distance = 0;

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
                distance++;
        }

        int maxLength = s1.Length;
        double similarity = 1.0 - (double)distance / maxLength;

        return similarity;
    }
}
