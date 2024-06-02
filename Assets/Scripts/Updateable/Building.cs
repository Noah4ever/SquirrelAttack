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
    public float timeToReclaim;
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
