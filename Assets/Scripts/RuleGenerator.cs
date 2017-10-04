using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleGenerator {

	public RuleGenerator()
    {

    }

    public Rule GenerateNewRule()
    {
        //TODO perhaps cache the generated Rules so the same ones don't get picked?
        Rule toReturn = new Rule(pickRuleType(),pickEquality(),pickAmount());

        return toReturn;
    }

    private RuleType pickRuleType()
    {
        //TODO for testing, use random one later
        return RuleType.LENGTH; 
    }

    private Equality pickEquality()
    {
        //TODO for testing, use random one later
        return Equality.EQUAL;
    }

    private int pickAmount()
    {
        //TODO for testing, use random one later
        return 5;
    }
}
