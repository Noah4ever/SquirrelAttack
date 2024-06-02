using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HouseTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void HouseTestSimplePasses()
    {
        // Use the Assert class to test conditions
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HouseTestWithEnumeratorPasses()
    {
        House house = new GameObject().AddComponent<House>();
        Lifeform lifeform = new GameObject().AddComponent<Lifeform>();

        house.lifeformsInside.Add(lifeform);

        // Use yield to skip a frame.
        yield return null;

        // Use the Assert class to test conditions.
        Assert.IsTrue(house.lifeformsInside.Contains(lifeform));
        Assert.AreEqual(1, house.lifeformsInside.Count);
    }
}
