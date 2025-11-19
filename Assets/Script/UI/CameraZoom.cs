using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    public CinemachineCamera vcam;
    public InputActionReference lookAction;
    public float zoomSpeed = 0.5f;
    public float minZoom = 3f;
    public float maxZoom = 10f;

    private void OnEnable()
    {
        lookAction.action.Enable();
    }

    private void Update()
    {
        Vector2 lookValue = lookAction.action.ReadValue<Vector2>();
        float zoomInput = lookValue.y;

        if (Mathf.Abs(zoomInput) > 0.1f)
        {
            var lens = vcam.Lens;
            lens.OrthographicSize -= zoomInput * zoomSpeed * Time.deltaTime * 60f;
            lens.OrthographicSize = Mathf.Clamp(lens.OrthographicSize, minZoom, maxZoom);
            vcam.Lens = lens;
        }
    }
}