using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float zoomSpeed = 10f;
    [SerializeField] private float minOrthographicSize = 5f;
    [SerializeField] private float maxOrthographicSize = 20f;
    [SerializeField] private float minFov = 20f;
    [SerializeField] private float maxFov = 100f;

    private InputAction zoomAction;

    void Start()
    {
        zoomAction = new InputAction("zoom", binding: "<Mouse>/scroll");
        zoomAction.Enable();

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        float zoomValue = zoomAction.ReadValue<Vector2>().y;

        if (mainCamera.orthographic)
        {
            mainCamera.orthographicSize -= zoomValue * zoomSpeed * Time.deltaTime;
            mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, minOrthographicSize, maxOrthographicSize);
        }
        else
        {
            mainCamera.fieldOfView -= zoomValue * zoomSpeed * Time.deltaTime;
            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, minFov, maxFov);
        }
    }
}
