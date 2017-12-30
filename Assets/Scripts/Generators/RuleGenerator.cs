using System;

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
                Equality nextEquality = pickEquality();
                int nextAmount = pickAmount(nextRule, nextEquality);
                return new Rule(ruleType: nextRule, equality: nextEquality, amount: nextAmount);
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
        return rnd.Next(1,5); //TODO REALLY need to tweak this
    }

    private int pickAmount(RuleType nextRule, Equality nextEquality)
    {
        int minAmount = GlobalData.MinNameLength;
        int maxAmount = GlobalData.MaxNameLength;
        switch (nextRule)
        {
            case RuleType.VOWELS:
            case RuleType.CONSONENTS:
                minAmount--;
                maxAmount--; //TODO TWEAK THIS
                break;
        }
        return pickAmountUsingEquality(minAmount, maxAmount, nextEquality);
    }

    private int pickAmountUsingEquality(int min, int max, Equality equality)
    {
        switch (equality)
        {
            case Equality.EQUAL:
                return rnd.Next(min, max);
            case Equality.GREATER:
                return getWeightedAmount(min, max);
            case Equality.LESSER:
                return getWeightedAmount(max, min);
            default:
                throw new ArgumentException();
        }
    }

    /** REQUIRES: max - min is less than 3. i.e. there are 3 options to return
     * Easiest option has 4/8 chance
     * Medium option has 3/8 chance
     * Hard option has 1/8 chance
     */
    private int getWeightedAmount(int easier, int harder)
    {
        int attempts = Math.Abs(easier - harder) + 1; //TODO this is 3 for now
        for (int a = 0; a < attempts; a++)
        {
            int guess = rnd.Next(2);
            if(guess == 0)
            {
                return easier + a;
            }
        }
        return harder;
    }


    private string pickOneLetter()
    {
        int nextIndex = rnd.Next(26);
        return ALPHABET[nextIndex].ToString();
    }
}
