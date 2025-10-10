using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Animator animator;
    
    public Vector2 inputVec;
    public float speed;
    Rigidbody2D rigid;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // FixedUpdate duoc goi theo khoang thoi gian co dinh, tuy vao toc do khung hinh
    void FixedUpdate()
    {
        //bool forwardPressed = inputVec.x > 0;
        //bool ;
        //if () { }
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
