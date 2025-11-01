using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class BanditCombat : MonoBehaviour
{
    [SerializeField] private Bandit player;
    public Animator animator;

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
        player.inputVec = Vector2.zero;
        
        player.m_combatIdle = true;
        player.m_animator.SetInteger("AnimState", 1);
        player.m_animator.SetTrigger("Attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            var enemyScript = enemy.GetComponentInParent<SampleEnemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        // How it like?
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        // Like dedication, and miss other?
    }
}