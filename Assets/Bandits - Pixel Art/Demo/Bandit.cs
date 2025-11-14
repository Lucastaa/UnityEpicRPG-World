using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using CodeMonkey.HealthSystemCM;

public class Bandit : MonoBehaviour, IGetHealthSystem
{
    public Vector2 inputVec;
    public bool                m_combatIdle = false;
    public Animator             m_animator;
    private Rigidbody2D         m_body2d;
    [SerializeField] float      m_speed = 4.0f;
    private HealthSystem        healthSystem;

    private void Awake()
    {
        healthSystem = new HealthSystem(500);

        healthSystem.OnDead += HealthSystem_OnDead;
    }
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	//void Update () {
 //       //Check if character just landed on the ground
 //       //if (!m_grounded && m_groundSensor.State()) {
 //       //    m_grounded = true;
 //       //    m_animator.SetBool("Grounded", m_grounded);
 //       //}

 //       //Check if character just started falling
 //       //if(m_grounded && !m_groundSensor.State()) {
 //       //    m_grounded = false;
 //       //    m_animator.SetBool("Grounded", m_grounded);
 //       //}

 //       // -- Handle input and movement --
 //       float inputX = Input.GetAxis("Horizontal");

 //       // Swap direction of sprite depending on walk direction
 //       if (inputX > 0)
 //           transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
 //       else if (inputX < 0)
 //           transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

 //       // Move
 //       // m_body2d.linearVelocity = new Vector2(inputX * m_speed, m_body2d.linearVelocity.y);

 //       //Set AirSpeed in animator
 //       // m_animator.SetFloat("AirSpeed", m_body2d.linearVelocity.y);

 //       // -- Handle Animations --
 //       //Death
 //       //if (Input.GetKeyDown("e")) {
 //       //    if(!m_isDead)
 //       //        m_animator.SetTrigger("Death");
 //       //    else
 //       //        m_animator.SetTrigger("Recover");

 //       //    m_isDead = !m_isDead;
 //       //}
            
 //       //Hurt
 //       //else if (Input.GetKeyDown("q"))
 //       //    m_animator.SetTrigger("Hurt");

 //       //Attack
 //       //else if(Input.GetMouseButtonDown(0)) {
 //       //    m_animator.SetTrigger("Attack");
 //       //}

 //       //Change between idle and combat idle
 //       //else if (Input.GetKeyDown("f"))
 //       //    m_combatIdle = !m_combatIdle;

 //       //Jump
 //       //else if (Input.GetKeyDown("space") && m_grounded) {
 //       //    m_animator.SetTrigger("Jump");
 //       //    m_grounded = false;
 //       //    m_animator.SetBool("Grounded", m_grounded);
 //       //    m_body2d.linearVelocity = new Vector2(m_body2d.linearVelocity.x, m_jumpForce);
 //       //    m_groundSensor.Disable(0.2f);
 //       //}

 //       //Run
 //       //else if (Mathf.Abs(inputX) > Mathf.Epsilon)
 //       //    m_animator.SetInteger("AnimState", 2);

 //       //Combat Idle
 //       //else if (m_combatIdle)
 //       //    m_animator.SetInteger("AnimState", 1);

 //       //Idle
 //       //else
 //       //    m_animator.SetInteger("AnimState", 0);
 //   } //
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    void FixedUpdate()
    {
        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }
        Vector2 nextVec = inputVec * m_speed * Time.fixedDeltaTime;
        m_body2d.MovePosition(m_body2d.position + nextVec);

        if (Mathf.Abs(inputVec.x) > Mathf.Epsilon || Mathf.Abs(inputVec.y) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);
        else if (m_combatIdle)
            m_animator.SetInteger("AnimState", 1);
        else
            m_animator.SetInteger("AnimState", 0);
    }
    void LateUpdate()
    {
        if (inputVec.x != 0)
        {
            float flipX = inputVec.x > 0 ? -1f : 1f;
            transform.localScale = new Vector3(flipX, 1, 1);
        }
    }
    public void Damage(int damage)
    {
        healthSystem.Damage(40);
    }
    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        m_animator.SetTrigger("Death");
        Destroy(gameObject, 1f);
    }
    public HealthSystem GetHealthSystem()
    {
        return healthSystem;
    }
}
