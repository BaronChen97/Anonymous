using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class BackgroundTest2
{

    [UnityTest]
    public IEnumerator Verify_Background_IsRunableTest()
    {
        var Background = new GameObject().AddComponent<Background2>();

        bool isBackgroundRun = true;

        yield return null;
        Assert.AreEqual(true, Background.verifyBackground(isBackgroundRun));
    }
}