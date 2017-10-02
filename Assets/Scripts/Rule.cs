using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule {

    public enum RuleType { CONTAINS, VOWELS, CONSONENTS, LENGTH, STARTS, ENDS};

    public RuleType MyRuleType;
    public int Amount;
    public string FirstWord;
    public string SecondWord;

    public Rule()
    {

    }

    public Rule(RuleType type)
    {

    }
}
