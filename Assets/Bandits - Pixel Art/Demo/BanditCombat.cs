using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class BanditCombat : MonoBehaviour
{
    private Bandit player;
    // public Animator animator;
    // public Transform attackPoint;
    // public LayerMask enemyLayers;

    public int attackDamage = 40;

    public InputAction attackAction;
    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        attackAction.Enable();
        Debug.Log("Enabled Bandit Combat");
        attackAction.performed += ctx => Attack();
    }

    void OnDisable()
    {
        attackAction.Disable();
        attackAction.performed -= ctx => Attack();
    }

    void Attack()
    {
        player.m_combatIdle = true;
        player.m_animator.SetInteger("AnimState", 1);
    }

}
