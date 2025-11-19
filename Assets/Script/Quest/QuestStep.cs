using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;
    private string questId;
    public void InitializeQuestStep(string questId)
    {
        this.questId = questId;
    }
    protected void FinishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;
            GameEventsManager.instance.questEvents.AdvanceQuest(questId);

            Debug.Log("Quest finished: Starting to destroy");
            Destroy(this.gameObject);
        }
    }
}
