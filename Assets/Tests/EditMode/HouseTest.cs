using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HouseTest
{

    [Test]
    public void EnterLifeform()
    {
        House house = new GameObject().AddComponent<House>();
        Lifeform lifeform = new GameObject().AddComponent<Lifeform>();
        house.lifeformsInside.Add(lifeform);
        
        Assert.IsTrue(house.lifeformsInside.Contains(lifeform));
        Assert.AreEqual(1, house.lifeformsInside.Count);
    }

    [Test]
    public void LeaveLifeform()
    {
        House house = new GameObject().AddComponent<House>();
        Lifeform lifeform = new GameObject().AddComponent<Lifeform>();
        house.LifeformEnter(lifeform);
        house.LifeformLeave(lifeform);
        
        Assert.IsFalse(house.lifeformsInside.Contains(lifeform));
        Assert.AreEqual(0, house.lifeformsInside.Count);
    }

    [Test]
    public void MultipleEnterLifeform()
    {
        House house = new GameObject().AddComponent<House>();
        Lifeform lifeform1 = new GameObject().AddComponent<Lifeform>();
        Lifeform lifeform2 = new GameObject().AddComponent<Lifeform>();
        house.LifeformEnter(lifeform1);
        house.LifeformEnter(lifeform2);
        
        Assert.IsTrue(house.lifeformsInside.Contains(lifeform1));
        Assert.IsTrue(house.lifeformsInside.Contains(lifeform2));
        Assert.AreEqual(2, house.lifeformsInside.Count);
    }

    [Test]
    public void MultipleLeaveLifeform()
    {
        House house = new GameObject().AddComponent<House>();
        Lifeform lifeform1 = new GameObject().AddComponent<Lifeform>();
        Lifeform lifeform2 = new GameObject().AddComponent<Lifeform>();
        house.LifeformEnter(lifeform1);
        house.LifeformEnter(lifeform2);
        house.LifeformLeave(lifeform1);
        house.LifeformLeave(lifeform2);
        
        Assert.IsFalse(house.lifeformsInside.Contains(lifeform1));
        Assert.IsFalse(house.lifeformsInside.Contains(lifeform2));
        Assert.AreEqual(0, house.lifeformsInside.Count);
    }
}