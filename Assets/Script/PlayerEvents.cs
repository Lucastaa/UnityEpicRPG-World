using System;

[Serializable]
public class PlayerEvents
{
    public event Action<int> onPlayerLevelChange;

    public void PlayerLevelChange(int newLevel)
    {
        onPlayerLevelChange?.Invoke(newLevel);
    }
}
