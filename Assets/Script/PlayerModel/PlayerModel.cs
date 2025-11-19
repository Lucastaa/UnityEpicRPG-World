using UnityEngine;
using System;
using CodeMonkey.HealthSystemCM;

public class PlayerModel
{
    public bool IsDead { get; private set; }
    public float Speed { get; private set; }

    public HealthSystem Health { get; private set; }

    public event Action OnDeadEvent;
    public event Action OnRespawnEvent;

    public PlayerModel (float speed, int maxHealth)
    {
        Speed = speed;
        Health = new HealthSystem(maxHealth);
        Health.OnDead += HandleDeath;
    }
    public void TakeDamage(int damage)
    {
        Health.Damage(40);
    }
    private void HandleDeath(object sender, EventArgs e)
    {
        IsDead = true;
        OnDeadEvent?.Invoke();
    }
    public void Respawn(int fullHealth)
    {
        Health.Heal(fullHealth);
        IsDead = false;
        OnRespawnEvent?.Invoke();
    }
}
