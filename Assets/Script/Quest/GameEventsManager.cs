using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance;

    public InputEvents inputEvents;
    public QuestEvents questEvents;
    public PlayerEvents playerEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one GameEventsManager in scene!");
        }
        instance = this;

        inputEvents = new InputEvents();
        questEvents = new QuestEvents();
        playerEvents = new PlayerEvents();
    }
}
