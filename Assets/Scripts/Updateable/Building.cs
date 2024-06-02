using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : Updateable
{
    [SerializeField]
    public float cityInfluence;
    [SerializeField]
    public float reclaimed;
    [SerializeField]
    public float fullyReclaimed = 100;
    [SerializeField]
    public float reclaimPerSecond = 1;
    [SerializeField]
    public bool openForAnimals;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }
}
