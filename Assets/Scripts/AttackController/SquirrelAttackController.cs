
public class SquirrelAttackController : AttackController
{
    public override void Attack()
    {
        this.targetController.ApplyMeleeDamage(baseDamage);
    }
}
