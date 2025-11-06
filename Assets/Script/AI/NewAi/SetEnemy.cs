using UnityEngine;

public class SetEnemy : AbstractEnemy
{
    [Header("Combat Settings")]
    [SerializeField] private MeleeHitBox meleeHitbox;
    [SerializeField] private float attackCooldown = 1.2f;
    [SerializeField] private float skillCooldown = 2f;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    private Transform player;
    private float lastAttackTime = -999f;
    private float lastSkillTime = -999f;
    private int skill1Count = 0;
    // public Animator skillAnimator;
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
        if (player == null) return;

        if (Time.time < lastAttackTime + attackCooldown) return;

        Stop();
        lastAttackTime = Time.time;

        float distance = Vector2.Distance(pos, player.position);
        if (distance < attackRange - 1f)
        {
            anim.SetTrigger("Attack2");
        }
        else
        {
            anim.SetTrigger("Attack");
        }
    }
    public void EnableHitbox() => meleeHitbox.EnableHitBox();
    public void DisableHitbox() => meleeHitbox.DisableHitBox();
    public override void PlaySkillEffect(Vector2 targetPos)
    {
        if (Time.time < lastSkillTime + skillCooldown) return;
        lastSkillTime = Time.time;

        if (projectilePrefab == null)
        {
            Debug.LogError("projectilePrefab is missing!");
            return;
        }
        GameObject skillFx = Instantiate(projectilePrefab, targetPos, Quaternion.identity);
        SkillEffect effect = projectilePrefab.GetComponent<SkillEffect>();

        if (effect != null)
        {
            effect.target = player;
        }

        Animator fxAnim = skillFx.GetComponent<Animator>();
        if (skill1Count < 3)
        {
            fxAnim.SetTrigger("Skill1");
            skill1Count++;
        }
        else
        {
            fxAnim.SetTrigger("Skill2");
            skill1Count = 0;
        }
    }
}