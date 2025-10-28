using UnityEngine;

public abstract class SampleEnemy : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb; // Cap nhat o FireWeapon
    public Animator anim;

    private Vector2 lastPosition; // Cap nhat o FireWeapon
    protected SpriteRenderer sr;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lastPosition = rb.position;
    }
    protected virtual void FixedUpdate()
    {
        // Set bool if isWalking based on actual movement speed
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
