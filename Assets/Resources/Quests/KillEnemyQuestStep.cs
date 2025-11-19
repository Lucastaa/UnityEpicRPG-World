using UnityEngine;

public class KillEnemyQuestStep : QuestStep
{
    [HideInInspector] public int enemiesKilled = 0;

    [HideInInspector] public int enemiesToKill = 5;
    private void OnEnable()
    {
        GameManager.OnEnemyKilled += HandleEnemyKilled;
    }

    private void OnDisable()
    {
        GameManager.OnEnemyKilled -= HandleEnemyKilled;
    }

    private void HandleEnemyKilled()
    {
        enemiesKilled++;

        Debug.Log("Quest progress: " + enemiesKilled + "/" + enemiesToKill);

        if (enemiesKilled >= enemiesToKill)
        {
            FinishQuestStep();
        }
    }
}