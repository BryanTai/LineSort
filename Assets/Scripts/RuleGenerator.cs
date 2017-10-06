using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleGenerator {
    System.Random rnd;

    public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    public RuleGenerator()
    {
        rnd = new System.Random();
    }

    public Rule GenerateNewRule()
    {
        //TODO perhaps cache the generated Rules so the same ones don't get picked?
        RuleType nextRule = pickRuleType();
        switch (nextRule)
        {
            case RuleType.CONTAINS:
            case RuleType.STARTS:
            case RuleType.ENDS:
                return new Rule(ruleType: nextRule, firstWord: pickOneLetter());
            case RuleType.VOWELS:
            case RuleType.CONSONENTS:
            case RuleType.LENGTH:
                return new Rule(ruleType: nextRule, equality: pickEquality(), amount: pickAmount());
            default:
                throw new ArgumentException();
        }
    }

    

    private RuleType pickRuleType()
    {
        int totalTypes = Enum.GetNames(typeof(RuleType)).Length;
        int next = rnd.Next(totalTypes);
        return (RuleType)next;
    }

    private Equality pickEquality()
    {
        int totalTypes = Enum.GetNames(typeof(Equality)).Length;
        int next = rnd.Next(totalTypes);
        return (Equality)next;
    }

    private int pickAmount()
    {
        return rnd.Next(1,8); //TODO might need to tweak this
    }

    private string pickOneLetter()
    {
        int nextIndex = rnd.Next(26);
        return ALPHABET[nextIndex].ToString();
    }
}
