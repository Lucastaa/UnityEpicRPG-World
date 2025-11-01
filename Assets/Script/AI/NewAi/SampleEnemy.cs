using UnityEngine;

public abstract class SampleEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator anim;

    private Vector2 lastPosition;
    protected SpriteRenderer sr;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lastPosition = rb.position;
    }
    public virtual void Start()
    {
        currentHealth = maxHealth;
    }
    protected virtual void FixedUpdate()
    {
        if (Vector2.Distance(rb.position, lastPosition) > 0.001f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        lastPosition = rb.position;
    }
    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        Debug.Log("Enemy Died");
    }
    public virtual void MoveTo(Vector2 targetPos)
    {
        Vector2 direction = (targetPos - rb.position).normalized;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(2.07f, 2.07f, 2.07f);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-2.07f, 2.07f, 2.07f);
        }
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    public virtual void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }
    public abstract void Attack(Vector2 pos, float attackRange);
    public abstract void PlaySkillEffect(Vector2 targetPos);
}
