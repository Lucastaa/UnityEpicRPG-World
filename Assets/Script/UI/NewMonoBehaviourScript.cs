using UnityEngine;
using System;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public static NewMonoBehaviourScript instance;
    public static event Action OnEnemyKilled;

    [Header("# Player Info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = { 3, 5, 10, 100, 150, 210, 280, 360, 450, 600 };

    [HideInInspector] public KillEnemyQuestStep killE;
    void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        killE = GetComponent<KillEnemyQuestStep>();
    }
    public void IncreaseKill()
    {
        kill++;
        GetExp();

        OnEnemyKilled?.Invoke();
    }
    public void GetExp()
    {
        exp++;

        if (exp >= nextExp[Mathf.Min(level, nextExp.Length - 1)])
        {
            level++;
            exp = 0;
        }
    }
}
