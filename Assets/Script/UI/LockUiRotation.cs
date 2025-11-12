using UnityEngine;

public class LockUiRotation : MonoBehaviour
{
    private Transform parent;
    private Vector3 originalScale;

    void Awake()
    {
        parent = transform.parent;
        originalScale = transform.localScale;
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.identity;

        if (parent != null && parent.localScale.x < 0)
            transform.localScale = new Vector3(-originalScale.x, originalScale.y, originalScale.z);
        else
            transform.localScale = originalScale;
    }
}