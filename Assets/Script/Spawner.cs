using UnityEngine;

public class Spawner : MonoBehaviour
{
    public void OnSpawn()
    {
        GameManager.instance.pool.Get(0);
    }
    
}
