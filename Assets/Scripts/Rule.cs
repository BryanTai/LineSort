using System;

public enum RuleType { CONTAINS, VOWELS, CONSONENTS, LENGTH, STARTS, ENDS };
public enum Equality { EQUAL, GREATER, LESSER }

public class Rule {

    private RuleType ruleType;
    private Equality equality;
    private int amount;
    private string firstWord;
    private string secondWord;

    public Rule(RuleType ruleType, Equality equality = Equality.EQUAL, 
        int amount = 0, string firstWord = "", string secondWord = "")
    {
        this.ruleType = ruleType;
        this.equality = equality;
        this.amount = amount;
        this.firstWord = firstWord;
        this.secondWord = secondWord;
    }

    public static bool NameMatchesRule(string name, Rule rule)
    {
        //I shouldn't have to worry about case if all my name data is ALL CAPS
        switch (rule.ruleType)
        {
            case RuleType.CONTAINS:
                return name.Contains(rule.firstWord); 
            case RuleType.VOWELS:
                int numVowels = numberOfVowels(name);
                return countMatchesEquality(numVowels, rule.amount, rule.equality);
            case RuleType.CONSONENTS:
                int numConsonents = name.Length - numberOfVowels(name);
                return countMatchesEquality(numConsonents, rule.amount, rule.equality);
            case RuleType.LENGTH:
                return countMatchesEquality(name.Length, rule.amount, rule.equality);
            case RuleType.STARTS:
                if (name.Length < rule.firstWord.Length) return false;
                string nameStart = name.Substring(0, rule.firstWord.Length);
                return nameStart == rule.firstWord;
            case RuleType.ENDS:
                if (name.Length < rule.firstWord.Length) return false;
                int offset = name.Length - rule.firstWord.Length;
                string nameEnd = name.Substring(offset, rule.firstWord.Length);
                return nameEnd == rule.firstWord;
            default:
                throw new ArgumentException();
        }
    }

    private static bool countMatchesEquality(int count, int ruleAmount, Equality myEquality)
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

    //Note that the letter Y is not a vowel
    //TODO maybe add some wiggle room and count it as both?
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
        switch (ruleType)
        {
            case RuleType.CONTAINS:
                return string.Format("CONTAINS '{0}'", firstWord);
            case RuleType.VOWELS:
                return string.Format("{0} {1} VOWELS", equalityToString(equality),amount);
            case RuleType.CONSONENTS:
                return string.Format("{0} {1} CONSONENTS", equalityToString(equality), amount);
            case RuleType.LENGTH:
                return string.Format("LENGTH IS {0} {1}", equalityToString(equality), amount);
            case RuleType.STARTS:
                return string.Format("STARTS WITH '{0}'", firstWord);
            case RuleType.ENDS:
                return string.Format("ENDS WITH '{0}'", firstWord);
            default:
                throw new ArgumentException();
        }
    }

    //TODO playtest whether phrases or symbols make more sense
    private string equalityToString(Equality equality)
    {
        switch (equality)
        {
            case Equality.EQUAL:
                return "EXACTLY";
            case Equality.GREATER:
                return "MORE THAN";
            case Equality.LESSER:
                return "LESS THAN";
            default:
                throw new ArgumentException();
        }
    }
}
