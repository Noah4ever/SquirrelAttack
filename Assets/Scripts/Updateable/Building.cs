using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Updateable
{
    [SerializeField]
    protected float cityInfluence { get; set; }
    [SerializeField]
    protected float reclaimed { get; set; }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
