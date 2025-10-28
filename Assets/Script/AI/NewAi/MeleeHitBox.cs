using UnityEngine;

public class MeleeHitBox : MonoBehaviour
{
    private bool active = false;
    public float damage = 20f;

    public void EnableHitBox() => active = true;
    public void DisableHitBox() => active = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!active) { Debug.Log(active); return; }
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Health " + (-damage));
        }
    }
}
