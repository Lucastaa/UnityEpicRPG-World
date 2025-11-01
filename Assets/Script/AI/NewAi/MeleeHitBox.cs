using UnityEngine;

public class MeleeHitBox : MonoBehaviour
{
    private bool active = false;
    public int damage = 20;

    public void EnableHitBox() => active = true;
    public void DisableHitBox() => active = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!active) return;

        var playerHealth = collision.GetComponent<Bandit>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
