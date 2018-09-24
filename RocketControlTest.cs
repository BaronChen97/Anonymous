using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class RocketControlTest {

    [UnityTest]
    public IEnumerator Verify_The_Player_Click_The_Rocket4() {
        var rocketControl = new GameObject().AddComponent<RocketControl>();
        var rocket = new GameObject();
        var expectedName = "Rocket";
        rocket.name = expectedName;

        yield return null;

        Assert.AreEqual(true, rocketControl.VerifyObjectName(rocket));
    }

    [UnityTest]
    public IEnumerator Restrict_Player_Leave_The_Left_Side_Safe_Zone()
    {
        var rocketControl = new GameObject().AddComponent<RocketControl>();

        yield return null;

        Assert.AreEqual(-2.5f, rocketControl.SafeZoneRestrict(-3.0f, -2.5f, 2.5f));
    }

    [UnityTest]
    public IEnumerator Restrict_Player_Leave_The_Right_Side_Safe_Zone()
    {
        var rocketControl = new GameObject().AddComponent<RocketControl>();

        yield return null;

        Assert.AreEqual(2.5f, rocketControl.SafeZoneRestrict(3.0f, -2.5f, 2.5f));
    }

    [UnityTest]
    public IEnumerator Restrict_Player_Leave_The_Top_Side_Safe_Zone()
    {
        var rocketControl = new GameObject().AddComponent<RocketControl>();

        yield return null;

        Assert.AreEqual(4.5f, rocketControl.SafeZoneRestrict(5.0f, -1.5f, 4.5f));
    }

    [UnityTest]
    public IEnumerator Restrict_Player_Leave_The_Bottom_Side_Safe_Zone()
    {
        var rocketControl = new GameObject().AddComponent<RocketControl>();

        yield return null;

        Assert.AreEqual(-1.5f, rocketControl.SafeZoneRestrict(-2.0f, -1.5f, 4.5f));
    }

    [UnityTest]
    public IEnumerator The_New_Rocket_Position()
    {
        var rocketControl = new GameObject().AddComponent<RocketControl>();
        Vector3 presumeTouchPoint = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 presumeOffset = new Vector3(1.0f, 1.0f, 1.0f);

        yield return null;

        Assert.AreEqual(new Vector3(-1.0f, -1.0f, -1.0f), 
            rocketControl.NewRocketCenterPosition(presumeTouchPoint, presumeOffset));
    }
}
