using CodeMonkey.HealthSystemCM;
using UnityEngine;

/// <summary>
/// Abstract base class for enemy AI in the game.
/// Handles movement, health, animation, and basic enemy behaviors.
/// Inherit from this class to implement specific enemy logic.
/// </summary>
public abstract class AbstractEnemy : MonoBehaviour, IGetHealthSystem
{
    /// <summary>
    /// Movement speed of the enemy.
    /// </summary>
    public float moveSpeed = 5f;

    /// <summary>
    /// Rigidbody2D component for physics-based movement.
    /// </summary>
    protected Rigidbody2D rb;

    /// <summary>
    /// Animator component for controlling animations.
    /// </summary>
    protected Animator anim;

    /// <summary>
    /// SpriteRenderer component for rendering the enemy sprite.
    /// </summary>
    protected SpriteRenderer sr;

    /// <summary>
    /// Stores the last position to determine movement.
    /// </summary>
    private Vector2 lastPosition;

    /// <summary>
    /// Health system for managing enemy health and death.
    /// </summary>
    private HealthSystem healthSystem;

    /// <summary>
    /// Initializes components and health system.
    /// </summary>
    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        lastPosition = rb.position;

        healthSystem = new HealthSystem(100);
        healthSystem.OnDead += HealthSystem_OnDead;
    }

    /// <summary>
    /// Called on start. Can be overridden by derived classes.
    /// </summary>
    protected virtual void Start()
    {

    }

    /// <summary>
    /// Updates walking animation based on movement.
    /// </summary>
    protected virtual void FixedUpdate()
    {
        bool isWalking = Vector2.Distance(rb.position, lastPosition) > 0.001f;
        anim.SetBool("isWalking", isWalking);

        lastPosition = rb.position;
    }

    /// <summary>
    /// Moves the enemy towards a target position.
    /// Flips sprite based on direction.
    /// </summary>
    /// <param name="targetPos">Target position to move towards.</param>
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

    /// <summary>
    /// Stops the enemy's movement.
    /// </summary>
    public virtual void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }

    /// <summary>
    /// Applies damage to the enemy.
    /// </summary>
    /// <param name="damage">Amount of damage to apply.</param>
    public void Damage(int damage)
    {
        healthSystem.Damage(damage);
    }

    /// <summary>
    /// Handles enemy death: plays animation, stops movement, destroys object.
    /// </summary>
    private void HealthSystem_OnDead(object sender, System.EventArgs e)
    {
        anim.SetBool("Dead", true);
        Stop();

        Destroy(gameObject, 1f);
    }

    /// <summary>
    /// Returns the health system instance.
    /// </summary>
    public HealthSystem GetHealthSystem() => healthSystem;

    /// <summary>
    /// Abstract method for enemy attack logic.
    /// </summary>
    /// <param name="pos">Target position.</param>
    /// <param name="attackRange">Attack range.</param>
    public abstract void Attack(Vector2 pos, float attackRange);

    /// <summary>
    /// Abstract method for playing skill effects.
    /// </summary>
    /// <param name="targetPos">Target position for skill effect.</param>
    public abstract void PlaySkillEffect(Vector2 targetPos);
}
