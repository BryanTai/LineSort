using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class RuleTest {

    [Test]
    public void NameContainsVowelTest()
    {
        Rule containsVowelRule = new Rule(ruleType: RuleType.CONTAINS, firstWord: "A");
        Assert.True(Rule.NameMatchesRule("A", containsVowelRule));
        Assert.True(Rule.NameMatchesRule("ALBERT", containsVowelRule));
        Assert.True(Rule.NameMatchesRule("CAMERON", containsVowelRule));
        Assert.True(Rule.NameMatchesRule("MERNA", containsVowelRule));
        Assert.False(Rule.NameMatchesRule("", containsVowelRule));
        Assert.False(Rule.NameMatchesRule("BRETT", containsVowelRule));
    }

    [Test]
    public void NameContainsConsonantTest()
    {
        Rule containsConsonantRule = new Rule(ruleType: RuleType.CONTAINS, firstWord: "Z");
        Assert.True(Rule.NameMatchesRule("Z", containsConsonantRule));
        Assert.True(Rule.NameMatchesRule("ZANE", containsConsonantRule));
        Assert.True(Rule.NameMatchesRule("PIZZA", containsConsonantRule));
        Assert.True(Rule.NameMatchesRule("REZ", containsConsonantRule));
        Assert.False(Rule.NameMatchesRule("", containsConsonantRule));
        Assert.False(Rule.NameMatchesRule("BRETT", containsConsonantRule));
    }

    [Test]
    public void VowelEqualsTest()
    {
        Rule vowelsEqualTo3Rule = new Rule(ruleType: RuleType.VOWELS, equality: Equality.EQUAL, amount: 3);    
        Assert.True(Rule.NameMatchesRule("AIE", vowelsEqualTo3Rule));
        Assert.True(Rule.NameMatchesRule("OUO", vowelsEqualTo3Rule));
        Assert.True(Rule.NameMatchesRule("OUOY", vowelsEqualTo3Rule));
        Assert.True(Rule.NameMatchesRule("SHAUNA", vowelsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("", vowelsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("AU", vowelsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("SEAN", vowelsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("CASEY", vowelsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("AEIO", vowelsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("BANANAMAN", vowelsEqualTo3Rule));
    }

    [Test]
    public void VowelGreaterTest()
    {
        Rule vowelsGreaterThan3Rule = new Rule(ruleType: RuleType.VOWELS, equality: Equality.GREATER, amount: 3);
        Assert.True(Rule.NameMatchesRule("AEIO", vowelsGreaterThan3Rule));
        Assert.True(Rule.NameMatchesRule("BANANAMAN", vowelsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("", vowelsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("AIE", vowelsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("OUO", vowelsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("OUOY", vowelsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("SHAUNA", vowelsGreaterThan3Rule));
    }

    [Test]
    public void VowelLesserTest()
    {
        Rule vowelsLesserThan3Rule = new Rule(ruleType: RuleType.VOWELS, equality: Equality.LESSER, amount: 3);
        Assert.True(Rule.NameMatchesRule("AU", vowelsLesserThan3Rule));
        Assert.True(Rule.NameMatchesRule("SEAN", vowelsLesserThan3Rule));
        Assert.True(Rule.NameMatchesRule("", vowelsLesserThan3Rule));
        Assert.False(Rule.NameMatchesRule("AIE", vowelsLesserThan3Rule));
        Assert.False(Rule.NameMatchesRule("OUO", vowelsLesserThan3Rule));
        Assert.True(Rule.NameMatchesRule("OYO", vowelsLesserThan3Rule));
        Assert.False(Rule.NameMatchesRule("SHAUNA", vowelsLesserThan3Rule));
    }

    [Test]
    public void ConsonantEqualsTest()
    {
        Rule consonantsEqualTo3Rule = new Rule(ruleType: RuleType.CONSONENTS, equality: Equality.EQUAL, amount: 3);
        Assert.True(Rule.NameMatchesRule("BCD", consonantsEqualTo3Rule));
        Assert.True(Rule.NameMatchesRule("STEVE", consonantsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("", consonantsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("FG", consonantsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("BOB", consonantsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("HJKL", consonantsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("BRETT", consonantsEqualTo3Rule));
        Assert.False(Rule.NameMatchesRule("MORTY", consonantsEqualTo3Rule));
    }

    [Test]
    public void ConsonantGreaterTest()
    {
        Rule consonantsGreaterThan3Rule = new Rule(ruleType: RuleType.CONSONENTS, equality: Equality.GREATER, amount: 3);
        Assert.False(Rule.NameMatchesRule("BCD", consonantsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("STEVE", consonantsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("", consonantsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("FG", consonantsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("BOB", consonantsGreaterThan3Rule));
        Assert.True(Rule.NameMatchesRule("HJKL", consonantsGreaterThan3Rule));
        Assert.True(Rule.NameMatchesRule("BRETT", consonantsGreaterThan3Rule));
        Assert.True(Rule.NameMatchesRule("MORTY", consonantsGreaterThan3Rule));
    }

    [Test]
    public void ConsonantLesserTest()
    {
        Rule consonantsGreaterThan3Rule = new Rule(ruleType: RuleType.CONSONENTS, equality: Equality.LESSER, amount: 3);
        Assert.False(Rule.NameMatchesRule("BCD", consonantsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("STEVE", consonantsGreaterThan3Rule));
        Assert.True(Rule.NameMatchesRule("", consonantsGreaterThan3Rule));
        Assert.True(Rule.NameMatchesRule("FG", consonantsGreaterThan3Rule));
        Assert.True(Rule.NameMatchesRule("BOB", consonantsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("HJKL", consonantsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("BRETT", consonantsGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("TONY", consonantsGreaterThan3Rule));
    }

    [Test]
    public void LengthEqualsTest()
    {
        Rule lengthEquals3Rule = new Rule(ruleType: RuleType.LENGTH, equality: Equality.EQUAL, amount: 3);
        Assert.False(Rule.NameMatchesRule("", lengthEquals3Rule));
        Assert.False(Rule.NameMatchesRule("BO", lengthEquals3Rule));
        Assert.True(Rule.NameMatchesRule("CAM", lengthEquals3Rule));
        Assert.False(Rule.NameMatchesRule("HARRY", lengthEquals3Rule));
    }
    [Test]
    public void LengthGreaterTest()
    {
        Rule lengthGreaterThan3Rule = new Rule(ruleType: RuleType.LENGTH, equality: Equality.GREATER, amount: 3);
        Assert.False(Rule.NameMatchesRule("", lengthGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("BO", lengthGreaterThan3Rule));
        Assert.False(Rule.NameMatchesRule("CAM", lengthGreaterThan3Rule));
        Assert.True(Rule.NameMatchesRule("HARRY", lengthGreaterThan3Rule));
    }
    [Test]
    public void LengthLesserTest()
    {
        Rule lengthLesserThan3Rule = new Rule(ruleType: RuleType.LENGTH, equality: Equality.LESSER, amount: 3);
        Assert.True(Rule.NameMatchesRule("", lengthLesserThan3Rule));
        Assert.True(Rule.NameMatchesRule("BO", lengthLesserThan3Rule));
        Assert.False(Rule.NameMatchesRule("CAM", lengthLesserThan3Rule));
        Assert.False(Rule.NameMatchesRule("HARRY", lengthLesserThan3Rule));
    }

}
