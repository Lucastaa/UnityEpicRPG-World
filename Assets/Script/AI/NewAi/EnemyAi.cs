using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    // Thiet lap ban kinh chuyen vung
    private Vector3 startingPosition;
    private void Start()
    {
        // Vi tri bat dau di chuyen quanh do
        startingPosition = transform.position;
    }
    private Vector3 GetRoamingPosition()
    {
        return startingPosition + GetRandomDir() * Random.Range(10f, 70f);
    }
    // Lay huong di chuyen ngau nhien
    public static Vector3 GetRandomDir()
    {
        // Random theo huong x, y trong khoang -1 den 1 sau do chuan hoa vector (normalized)
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
