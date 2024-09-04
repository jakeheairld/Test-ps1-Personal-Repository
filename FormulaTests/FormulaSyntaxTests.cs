// <copyright file="FormulaSyntaxTests.cs" company="UofU-CS3500">
//   Copyright 2024 UofU-CS3500. All rights reserved.
// </copyright>
// <authors> Jake Heairld </authors>
// <date> 8/26/2024 </date>

namespace CS3500.FormulaTests;

using CS3500.Formula3; // Change this using statement to use different formula implementations.

/// <summary>
///   <para>
///     The following class shows the basics of how to use the MSTest framework,
///     including:
///   </para>
///   <list type="number">
///     <item> How to catch exceptions. </item>
///     <item> How a test of valid code should look. </item>
///   </list>
/// </summary>
[TestClass]
public class FormulaSyntaxTests
{
    // --- Tests for One Token Rule ---

    /// <summary>
    ///   <para>
    ///     This test makes sure the right kind of exception is thrown
    ///     when trying to create a formula with no tokens.
    ///   </para>
    ///   <remarks>
    ///     <list type="bullet">
    ///       <item>
    ///         We use the _ (discard) notation because the formula object
    ///         is not used after that point in the method.  Note: you can also
    ///         use _ when a method must match an interface but does not use
    ///         some of the required arguments to that method.
    ///       </item>
    ///       <item>
    ///         string.Empty is often considered best practice (rather than using "") because it
    ///         is explicit in intent (e.g., perhaps the coder forgot to but something in "").
    ///       </item>
    ///       <item>
    ///         The name of a test method should follow the MS standard:
    ///         https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices
    ///       </item>
    ///       <item>
    ///         All methods should be documented, but perhaps not to the same extent
    ///         as this one.  The remarks here are for your educational
    ///         purposes (i.e., a developer would assume another developer would know these
    ///         items) and would be superfluous in your code.
    ///       </item>
    ///       <item>
    ///         Notice the use of the attribute tag [ExpectedException] which tells the test
    ///         that the code should throw an exception, and if it doesn't an error has occurred;
    ///         i.e., the correct implementation of the constructor should result
    ///         in this exception being thrown based on the given poorly formed formula.
    ///       </item>
    ///     </list>
    ///   </remarks>
    ///   <example>
    ///     <code>
    ///        // here is how we call the formula constructor with a string representing the formula
    ///        _ = new Formula( "5+5" );
    ///     </code>
    ///   </example>
    /// </summary>
    [TestMethod]
    [ExpectedException( typeof( FormulaFormatException ) )]
    public void OneToken_FormulaConstructor_TestNoTokens_Invalid( )
    {
        _ = new Formula(string.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void OneToken_FormulaConstructor_TestWhitespaceNoTokens_Invalid()
    {
        _ = new Formula("       ");
    }

    [TestMethod]
    public void OneToken_FormulaConstructor_TestOneToken_Valid()
    {
        _ = new Formula("1");
    }

    // --- Tests for Valid Token Rule ---

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestWholeNumberTokens_Valid()
    {
        _ = new Formula("1 + 50 + 299");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestDecimalNumberTokens_Valid()
    {
        _ = new Formula("0.1 + 3.14");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestEmptyDecimalTokens_Valid()
    {
        _ = new Formula("0. + 3.");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestLowerCaseExponentNumberTokens_Valid()
    {
        _ = new Formula("2e5 + 2e5");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestUpperCaseExponentNumberTokens_Valid()
    {
        _ = new Formula("3.5E-6 + 13.5E-6");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestVariableTokensOneLetterOneDigit_Valid()
    {
        _ = new Formula("y1 + y1");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestVariableTokensOneLetterDigits_Valid()
    {
        _ = new Formula("b198 + y154");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestVariableTokensLettersOneDigit_Valid()
    {
        _ = new Formula("abc1 + udh4");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestVariableTokensLettersDigits_Valid()
    {
        _ = new Formula("abc123 + judy8374");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestVariableTokensUpperCaseLetters_Valid()
    {
        _ = new Formula("D1 + GjD3 + I2831 + DeDcy727");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ValidToken_FormulaConstructor_TestVariableLetterTokens_Invalid()
    {
        _ = new Formula("a + a");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ValidToken_FormulaConstructor_TestVariableNumLetterTokens_Invalid()
    {
        _ = new Formula("2a + 2a");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ValidToken_FormulaConstructor_TestVariableLetterNumLetterTokens_Invalid()
    {
        _ = new Formula("a2a + a2a");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ValidToken_FormulaConstructor_TestInvalidTokens_Invalid()
    {
        _ = new Formula("1 + 1 !@#$%^&*{};?.,<>_ ");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestOperatorAdditionToken_Valid()
    {
        _ = new Formula("1+1+1+1");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestOperatorSubtractionToken_Valid()
    {
        _ = new Formula("1-1-1-1");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestOperatorMultiplicationToken_Valid()
    {
        _ = new Formula("1*1*1*1");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestOperatorDivisionToken_Valid()
    {
        _ = new Formula("1/1/1/1");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ValidToken_FormulaConstructor_TestInvalidModulusOperatorToken_Invalid()
    {
        _ = new Formula("1%1%1%1");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestNoWhitespaceTokens_Valid()
    {
        _ = new Formula("1+abc3/(1+1)/6");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestExtraWhitespaceTokens_Valid()
    {
        _ = new Formula("      1  +1   +  1   ");
    }

    [TestMethod]
    public void ValidToken_FormulaConstructor_TestParenthesisAroundIndividualNumberTokens_Valid()
    {
        _ = new Formula("(1)+(2)");
    }

    // --- Tests for Closing Parenthesis Rule

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ClosingParenthesis_FormulaConstructor_TestClosingParenthesisOrder_Invalid()
    {
        _ = new Formula("(1 + 1)) + 1 + (1 + 1");
    }

    [TestMethod]
    public void ClosingParenthesis_FormulaConstructor_TestClosingParenthesisOrder_Valid()
    {
        _ = new Formula("((1 + 1) + (1 + 1))");
    }

    // --- Tests for Balanced Parentheses Rule

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void BalancedParenthesis_FormulaConstructor_TestMoreOpenParenthesisTotal_Invalid()
    {
        _ = new Formula("(((1 + 1))");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void BalancedParenthesis_FormulaConstructor_TestMoreCloseParenthesisTotal_Invalid()
    {
        _ = new Formula("((1 + 1)))");
    }

    [TestMethod]
    public void BalancedParenthesis_FormulaConstructor_TestEvenParenthesisTotal_Valid()
    {
        _ = new Formula("((((1) + (1))))-(1)");
    }
     
    // --- Tests for First Token Rule

    /// <summary>
    ///   <para>
    ///     Make sure a simple well formed formula is accepted by the constructor (the constructor
    ///     should not throw an exception).
    ///   </para>
    ///   <remarks>
    ///     This is an example of a test that is not expected to throw an exception, i.e., it succeeds.
    ///     In other words, the formula "1+1" is a valid formula which should not cause any errors.
    ///   </remarks>
    /// </summary>
    [TestMethod]
    public void FirstToken_FormulaConstructor_TestFirstTokenNumber_Valid( )
    {
        _ = new Formula("1+1");
    }

    [TestMethod]
    public void FirstToken_FormulaConstructor_TestFirstTokenVariable_Valid()
    {
        _ = new Formula("x2+y3");
    }

    [TestMethod]
    public void FirstToken_FormulaConstructor_TestFirstTokenOpenParenthesis_Valid()
    {
        _ = new Formula("(1+1)");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FirstToken_FormulaConstructor_TestFirstTokenCloseParenthesis_Invalid()
    {
        _ = new Formula(") 1 + 1");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FirstToken_FormulaConstructor_TestFirstTokenOperator_Invalid()
    {
        _ = new Formula("+ 1 + 1");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void FirstToken_FormulaConstructor_TestFirstTokenInvalidToken_Invalid()
    {
        _ = new Formula("& 1 + 1");
    }

    // --- Tests for  Last Token Rule ---

    [TestMethod]
    public void LastToken_FormulaConstructor_TestLastTokenCloseParenthesis_Valid()
    {
        _ = new Formula("5 + (2 * 1)");
    }

    [TestMethod]
    public void LastToken_FormulaConstructor_TestLastTokenVariable_Valid()
    {
        _ = new Formula("5 + 2 * e1");
    }

    [TestMethod]
    public void LastToken_FormulaConstructor_TestLastTokenNumber_Valid()
    {
        _ = new Formula("5 + 2 * 1");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void LastToken_FormulaConstructor_TestLastTokenOperator_Invalid()
    {
        _ = new Formula("1 + 1 +");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void LastToken_FormulaConstructor_TestLastTokenOpenParenthesis_Invalid()
    {
        _ = new Formula("1 + 1 (");
    }

    // --- Tests for Parentheses/Operator Following Rule ---

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ParenthesisOperatorFollowing_FormulaConstructor_TestTwoOperator_Invalid()
    {
        _ = new Formula("1+-1");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ParenthesisOperatorFollowing_FormulaConstructor_TestOpenParenthesisOperator_Invalid()
    {
        _ = new Formula("(+1 + 1)");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ParenthesisOperatorFollowing_FormulaConstructor_TestOperatorOpenParenthesis_Invalid()
    {
        _ = new Formula("+(1 + 1)");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ParenthesisOperatorFollowing_FormulaConstructor_TestOpenParenthesisCloseParenthesis_Invalid()
    {
        _ = new Formula("() + (1 + 1)");
    }

    [TestMethod]
    public void ParenthesisOperatorFollowing_FormulaConstructor_TestOpenParenthesisNumber_Valid()
    {
        _ = new Formula("(2 - 5.5)");
    }

    [TestMethod]
    public void ParenthesisOperatorFollowing_FormulaConstructor_TestOpenParenthesisVariable_Valid()
    {
        _ = new Formula("(r2 - 5.5)");
    }

    [TestMethod]
    public void ParenthesisOperatorFollowing_FormulaConstructor_TestMultipleOpenParenthesisVariable_Valid()
    {
        _ = new Formula("((r2 - 5.5))");
    }

    [TestMethod]
    public void ParenthesisOperatorFollowing_FormulaConstructor_TestMultipleOpenParenthesis_Valid()
    {
        _ = new Formula("(((1 + 7)+2)+3)");
    }

    // --- Tests for Extra Following Rule ---

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ExtraFollowing_FormulaConstructor_TestNumberFollowingNumberToken_Invalid()
    {
        _ = new Formula("1 1+2");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ExtraFollowing_FormulaConstructor_TestVariableFollowingNumberToken_Invalid()
    {
        _ = new Formula("1 a2+2");
    }

    [TestMethod]
    [ExpectedException(typeof(FormulaFormatException))]
    public void ExtraFollowing_FormulaConstructor_TestNumberFollowingVariableToken_Invalid()
    {
        _ = new Formula("a2 1+2");
    }

    [TestMethod]
    public void ExtraFollowing_FormulaConstructor_TestMultipleCloseParenthesis_Valid()
    {
        _ = new Formula("(3+(2+(1 + 7)))");
    }
}