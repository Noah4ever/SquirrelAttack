using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField]
    protected int baseDamage = 10;
    protected int lifePoints = 100;

    protected float meleeDefenceFactor = 1.0f; // This value will be multiplied with the melee damage dealt
    protected float rangeDefenceFactor = 1.0f; // This value will be multiplied with the range damage dealt
                                             // Dealt Damage = 10, Defence Factor = 0.5
                                             // Resulting Damage = 10 * 0.5 = 5

    protected AttackController targetController;

    public int getLifePoints() { return lifePoints; }

    public void setTarget(AttackController attackController) { targetController = attackController; }

    public virtual void Attack() {}

    public virtual void ApplyRangeDamage(int damage) 
    {
        int damageAfterDefence = (int)((float)damage * rangeDefenceFactor);
        lifePoints = lifePoints - damageAfterDefence;
    }

    public virtual void ApplyMeleeDamage(int damage)
    {
        int damageAfterDefence = (int)((float)damage * meleeDefenceFactor);
        lifePoints = lifePoints - damageAfterDefence;
        Debug.Log("Dealt Damage. New health is: " + lifePoints);
    }
}
