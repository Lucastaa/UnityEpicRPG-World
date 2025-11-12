using System.Collections;
using System.Runtime.CompilerServices;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpearmanEnemy : AbstractEnemy
{
    [Header("Combat Settings")]
    [SerializeField] private MeleeHitBox meleeHitbox;
    [SerializeField] private float attackCooldown = 1.2f;
    [SerializeField] private float skillCooldown = 6f;

    public Collider2D spinHitBox;
    private Transform player;
    private float lastAttackTime = -999f;
    private float lastSkillTime = -999f;
    protected override void Awake()
    {
        base.Awake();
    }
    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player")?.transform;
    }
    public override void Attack(Vector2 pos, float attackRange)
    {
        float distance = Vector2.Distance(pos, player.position);

        if (Time.time < lastAttackTime + attackCooldown && Time.time < lastSkillTime + skillCooldown) return;
        
        if (Time.time >= lastSkillTime + skillCooldown)
        {
            anim.SetTrigger("Attack2");
            StartCoroutine(SpinAttack());

            lastSkillTime = Time.time;
        }
        else if (Time.time >= lastAttackTime + attackCooldown)
        {
            anim.SetTrigger("Attack");

            lastAttackTime = Time.time;
        }
    }
    private IEnumerator SpinAttack()
    {
        spinHitBox.enabled = true;
        yield return new WaitForSeconds(2f);

        spinHitBox.enabled = false;
    }
    public void EnableAnimHitbox() => meleeHitbox.EnableHitBox();
    public void DisableAnimHitbox() => meleeHitbox.DisableHitBox();
    public override void PlaySkillEffect(Vector2 targetPos) { }
}