using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class BanditCombat : MonoBehaviour
{
    [SerializeField] private Bandit player;
    // public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 40;

    [SerializeField] private InputActionReference attackActionReference;
    private InputAction attackAction;

    void OnEnable()
    {
        attackAction = attackActionReference.action;
        attackAction.Enable();
        attackAction.performed += OnAttackPerformed;
    }

    void OnDisable()
    {
        attackAction.performed -= OnAttackPerformed;
        attackAction.Disable();
    }

    private void OnAttackPerformed(InputAction.CallbackContext ctx)
    {
        Attack();
    }

    void Attack()
    {
        player.m_combatIdle = true;
        player.m_animator.SetInteger("AnimState", 1);

        if (player.m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        } 
        else
        {
            player.m_animator.SetTrigger("Attack");
        }
    }
    public void DealDamage()
    {
        // Detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            var enemyScript = enemy.GetComponentInParent<AbstractEnemy>();
            if (enemyScript != null)
            {
                enemyScript.Damage(attackDamage);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}