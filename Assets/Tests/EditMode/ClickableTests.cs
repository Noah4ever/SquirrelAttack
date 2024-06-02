using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class ClickableTests
{

    [Test]
    public void Select()
    {
        Clickable clickable = new Clickable();

        clickable.Select();

        Assert.IsTrue(clickable.IsSelected);
    }

    [Test]
    public void Deselect()
    {
        Clickable clickable = new Clickable();

        clickable.Select();
        clickable.Deselect();

        Assert.IsFalse(clickable.IsSelected);
    }

}
