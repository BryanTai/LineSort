using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule {

    public enum RuleType { CONTAINS, VOWELS, CONSONENTS, LENGTH, STARTS, ENDS};
    public enum Equality { EQUAL, GREATER, LESSER}

    private RuleType ruleType;
    private Equality equality;
    private int amount;
    private string firstWord;
    private string secondWord;

    public Rule()
    {

    }

    public Rule(RuleType ruleType, Equality equality = Equality.EQUAL, 
        int amount = 0, string firstWord = "", string secondWord = "")
    {
        this.ruleType = ruleType;
        this.equality = equality;
        this.amount = amount;
        this.firstWord = firstWord;
        this.secondWord = secondWord;
    }

    public static bool DoesNameMatchRule(string name, Rule rule)
    {

        switch (rule.ruleType)
        {
            case RuleType.CONTAINS:
                //I shouldn't have to worry about case if all my name data is ALL CAPS
                return name.Contains(rule.firstWord); 
            case RuleType.VOWELS:
                int numVowels = numberOfVowels(name);
                return doesCountMatchEquality(numVowels, rule.amount, rule.equality);
            case RuleType.CONSONENTS:
                int numConsonents = name.Length - numberOfVowels(name);
                return doesCountMatchEquality(numConsonents, rule.amount, rule.equality);
            case RuleType.LENGTH:
                return doesCountMatchEquality(name.Length, rule.amount, rule.equality);
            case RuleType.STARTS:
                string nameStart = name.Substring(0, rule.firstWord.Length);
                return nameStart == rule.firstWord;
            case RuleType.ENDS:
                int offset = name.Length - rule.firstWord.Length;
                string nameEnd = name.Substring(offset, rule.firstWord.Length);
                return nameEnd == rule.firstWord;
            default:
                throw new ArgumentException();
        }
    }

    private static bool doesCountMatchEquality(int count, int ruleAmount, Equality myEquality)
    {
        switch (myEquality)
        {
            case Equality.EQUAL:
                return count == ruleAmount;
            case Equality.GREATER:
                return count > ruleAmount;
            case Equality.LESSER:
                return count < ruleAmount;
            default:
                throw new ArgumentException();
        }
    }

    private static int numberOfVowels(string name)
    {
        int total = 0;
        foreach (char c in name)
        {
            if ("AEIOU".IndexOf(c) != -1)
            {
                total++;
            }
        }
        return total;
    }

    public override string ToString()
    {
        //TODO Placeholder, need to use a switch case for nicer text
        return string.Format(
            "RuleType {0}, Equality {1}, Amount {2}, FirstWord {3}, SecondWord, {4}", 
            ruleType, equality, amount, firstWord, secondWord);
    }
}
