using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static event Action OnEnemyKilled;
    public static event Action<int> OnPlayerLevelChange;

    public GameObject player;
    public PoolManager pool;

    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };
    
    void Awake()
    {
        instance = this;
    }
    public void IncreaseKill()
    {
        kill++;
        GetExp(1);

        OnEnemyKilled?.Invoke();
    }
    public void GetExp(int amount)
    {
        exp += amount;

        if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++;
            exp = 0;
            GameEventsManager.instance.playerEvents.PlayerLevelChange(level);

            // OnPlayerLevelChange?.Invoke(level);
        }
    }
}
