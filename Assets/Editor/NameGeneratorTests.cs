using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class NameGeneratorTests {

    NameGenerator fullNameGenerator;

    public NameGeneratorTests()
    {
        fullNameGenerator = new NameGenerator(NameGenerator.MAX_NAME_LENGTH,NameGenerator.MIN_NAME_LENGTH);
    }

    [Test]
    public void MaxNameMoreThanMinName()
    {
        Assert.GreaterOrEqual(NameGenerator.MAX_NAME_LENGTH, NameGenerator.MIN_NAME_LENGTH);
    }

    [Test]
	public void NewNameContainsNoNewLine()
    {
        string testName = fullNameGenerator.GetNewName();
        Assert.Greater(1, testName.IndexOf("\n"));
        Assert.Greater(1, testName.IndexOf("\r\n"));
    }

}
