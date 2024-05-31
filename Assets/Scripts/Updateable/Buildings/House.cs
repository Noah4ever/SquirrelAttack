using Codice.Client.Common.GameUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    [SerializeField]
    public int humanCapacity { get; set; }
    [SerializeField]
    public List<Human> humansLiving { get; set; }
    [SerializeField]
    public List<Lifeform> lifeformsInside;
    [SerializeField]
    public bool openForAnimals { get; set; }

    void Start()
    {
        lifeformsInside = new List<Lifeform>();
        base.Start();
    }
    void Update()
    {
        base.Update();
    }

    public override void update()
    {
        // TODO: do magic here to update reclaimed int 
        // Maybe: if more animals then humans
        // Or: if more animals.presence then humans.presence
        // Something else: ...

    }

    public bool MoreAnimalsThenHumans()
    {
        // TODO: Not very good because there could be friendly humans and hostile animals but i cant access teamtype because it is in clickable
        int animals = 0;
        int humans = 0;

        foreach (Lifeform lifeform in lifeformsInside)
        {
            if (lifeform is Human)
            {
                humans++;
            }
            else if (lifeform is Animal)
            {
                animals++;
            }
        }
        return animals > humans;
    }

    public void LifeformEnter(Lifeform lifeform)
    {
        lifeformsInside.Add(lifeform);
    }

    public void LifeformLeave(Lifeform lifeform)
    {
        lifeformsInside.Remove(lifeform);
    }
}
