using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Updateable
{
    [SerializeField]
    private float cityInfluence { get; set; }
    [SerializeField]
    private int reclaimed { get; set; }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}