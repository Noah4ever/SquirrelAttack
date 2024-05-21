using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    [SerializeField]
    private int humanCapacity { get; set; }
    [SerializeField]
    private List<Human> humansLiving { get; set; }
    [SerializeField]
    private List<Lifeform> lifeformsInside { get; }
    [SerializeField]
    private bool openForAnimals { get; set; }

    void Start()
    {
        base.Start();
    }
    void Update()
    {
        base.Update();
    }

    public override update()
    {
        // TODO: do magic here to update reclaimed int 
        // 1. if more animals then humans
        // 2. if more animals.presence then humans.presence
        // 3. ...
    }

    public LifeformEnter(Lifeform lifeform)
    {
        lifeformsInside.Add(lifeform);
    }

    public LifeformLeave(Lifeform lifeform)
    {
        lifeformsInside.Remove(lifeform);
    }
}
