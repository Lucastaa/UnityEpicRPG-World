using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;
    public Rigidbody2D target;

    public float health;
    bool isLive = true;

    Animator anim;
    Rigidbody2D rigid;
    Collider2D coll;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        wait = new WaitForFixedUpdate();
    }
    void FixedUpdate()
    {
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
        {
            return;
        }

        // MoveTo(target.position);
    }
    public void MoveTo(Vector2 position)
    {
        Vector2 dirVec = position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.linearVelocity = Vector2.zero;
    }
    public void StopMoving()
    {
        if (rigid != null)
        {
            rigid.linearVelocity = Vector2.zero;
            rigid.angularVelocity = 0f;
        }
    }
    void LateUpdate()
    {
        if (!isLive)
        {
            return;
        }
        spriter.flipX = target.position.x < rigid.position.x;
    }
    void OnEnable()
    {
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        coll.enabled = true;
        rigid.simulated = true;
        spriter.sortingOrder = 2;
        anim.SetBool("Dead", false);
        // health = maxHealth;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;

        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());

        if (health > 0)
        {
            anim.SetTrigger("Hit");
        }
        else
        {
            isLive = false;
            coll.enabled = false;
            rigid.simulated = false;
            spriter.sortingOrder = 1;
            anim.SetBool("Dead", true);
        }
    }
    IEnumerator KnockBack()
    {
        yield return wait;
        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerPos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}
