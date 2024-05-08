using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : Animal
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        addToTimeController();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
}
