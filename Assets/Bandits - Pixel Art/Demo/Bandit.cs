using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using CodeMonkey.HealthSystemCM;

public class Bandit : MonoBehaviour, IGetHealthSystem
{
    public Vector2 inputVec;

    public Animator             m_animator;
    private Rigidbody2D         m_body2d;

    private PlayerModel model;

    [SerializeField] float      m_speed = 4.0f;
    public bool                 m_combatIdle = false;
    private void Awake()
    {
        model = new PlayerModel(m_speed, 500);

        model.OnDeadEvent += OnPlayerDead;
        model.OnRespawnEvent += OnPlayerRespawn;
    }
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
    }
	
    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
    void OnInteract(InputValue value)
    {
        GameEventsManager.instance.inputEvents.SubmitPressed();
    }
    void FixedUpdate()
    {
        if (m_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            return;

        Vector2 nextVec = inputVec * model.Speed * Time.fixedDeltaTime;
        m_body2d.MovePosition(m_body2d.position + nextVec);

        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        if (Mathf.Abs(inputVec.x) > Mathf.Epsilon || Mathf.Abs(inputVec.y) > Mathf.Epsilon)
        {
            m_animator.SetInteger("AnimState", 2);
            return;
        }

        if (m_combatIdle)
        {
            m_animator.SetInteger("AnimState", 1);
            return;
        }

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
    public void Damage(int dmg)
    {
        model.TakeDamage(dmg);
    }
    public HealthSystem GetHealthSystem()
    {
        return model.Health;
    }
    


    private void OnPlayerDead()
    {
        StartCoroutine(RespawnRoutine());
    }
    IEnumerator RespawnRoutine()
    {
        m_animator.SetTrigger("Death");
        GetComponent<PlayerInput>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(5f);

        model.Respawn(500);
    }
    private void OnPlayerRespawn()
    {
        m_animator.SetTrigger("Recover");
        GetComponent<Collider2D>().enabled = true;
        GetComponent<PlayerInput>().enabled = true;
    }
}
