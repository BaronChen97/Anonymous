using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class Destory_Game_Test {

    [UnityTest]
    public IEnumerator Destory_Game_TestWithEnumeratorPasses() {
        var destroyGame = new GameObject().AddComponent<DestoryGame>();
        bool isTheGameOver = true;
        
        yield return null;
        Assert.AreEqual(true, destroyGame.VerifyGameOver(isTheGameOver));
    }

}
