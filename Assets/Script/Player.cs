using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator animator;
    
    public Vector2 inputVec;
    public float speed;

    public Scanner scanner;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        scanner = GetComponent<Scanner>();
    }

    // FixedUpdate duoc goi theo khoang thoi gian co dinh, tuy vao toc do khung hinh
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        spriter.sortingOrder = 1;
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    public void OnSpawn()
    {
        GameManager.instance.pool.Get(0);
    }

    void LateUpdate()
    {
        animator.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) 
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}