using UnityEngine;
using UnityEngine.UIElements;

public class SkillEffect : MonoBehaviour
{
    public float damage = 10f;
    private bool canDamage = false;
    public float lifeTime = 1.5f;
    private SpriteRenderer sr;
    private BoxCollider2D hitBox;
    [HideInInspector] public Transform target;
    public void EnableDamage() => canDamage = true;
    public void DisableDamage() => canDamage = false;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        hitBox = GetComponent<BoxCollider2D>();
    }
    public void FixedUpdate()
    {
        if (target != null)
        {
            FlipX(target.position);
        }
    }
    public void SetUpSkill1HitBox()
    {
        hitBox.size = new Vector2(0.4806469f, 0.3290103f);
        hitBox.offset = new Vector2(-0.04089855f, -0.2109503f);
        damage = 10f;
    }
    public void SetUpSkill2HitBox()
    {
        hitBox.size = new Vector2(0.9542089f, 0.6174524f);
        hitBox.offset = new Vector2(0.1958824f, -0.3551713f);
        damage = 25f;
    }
    public void FlipX(Vector2 targetPos)
    {
        Vector2 direction = (targetPos - (Vector2)transform.position);
        if (direction.x > 0)
        {
            sr.flipX = false;
        }
        else if (direction.x < 0)
        {
            sr.flipX = true;
        }
    }
    public void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canDamage) return;
        if (collision.CompareTag("Player"))
        {
            // collision.GetComponent<PlayerHealth>()?.TakeDamage(damage);
            Debug.Log("Player takes " + damage + " damage from SkillEffect.");
        }
    }
}
