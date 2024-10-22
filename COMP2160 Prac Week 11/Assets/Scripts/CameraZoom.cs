using UnityEngine;
using UnityEngine.InputSystem;

public class CameraZoom : MonoBehaviour
{
    public Camera mainCamera;
    public float zoomSpeed = 10f;
    public float minOrthographicSize = 5f;
    public float maxOrthographicSize = 20f;
    public float minFov = 20f;
    public float maxFov = 100f;

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
