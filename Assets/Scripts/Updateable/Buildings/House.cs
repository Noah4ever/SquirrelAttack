using Codice.Client.Common.GameUI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : Building
{
    [SerializeField]
    public int humanCapacity;
    [SerializeField]
    public List<Human> humansLiving;
    [SerializeField]
    public List<Lifeform> lifeformsInside; // TODO: Maybe change to GameObject instead of Lifeform so we can access Clickable aswe

    new void Start()
    {
        base.Start();
        addToTimeController();
    }
    new void Update()
    {
        base.Update();
    }

    public override void update()
    {
        // TODO: do magic here to update reclaimed int 
        // Maybe: if more animals then humans
        // Or: if more animals.presence then humans.presence
        // Something else: ...

        if (MoreAnimalsThenHumans() && reclaimed < fullyReclaimed)
        {
            // check if more animals then humans and if time to reclaim is over then reclaim for animals
            reclaimed += Time.deltaTime / reclaimPerSecond;
        }
        else if (!MoreAnimalsThenHumans() && reclaimed > 0)
        {
            // check if more humans then animals and if time to reclaim is over then reclaim for humans
            reclaimed -= Time.deltaTime / reclaimPerSecond;
        }
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
        // check if open for animals
        lifeformsInside.Add(lifeform);
    }

    public void LifeformLeave(Lifeform lifeform)
    {
        lifeformsInside.Remove(lifeform);
    }
}
