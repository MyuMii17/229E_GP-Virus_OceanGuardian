using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThridCamera : MonoBehaviour
{
    private InputAction lookAction;
    private InputAction zoomAction;
    public Transform cameraPivot;
    public Transform cameraRoot;
    public Transform playerPos;
    public Vector3 deseriedPos;
    public Vector3 playerOffset;
    public float smoothCam = 2f;
    private Vector2 look;
    private Vector2 zoom;
    private float xRotation;
    private float yRotation;
    private float sentivity = 0.2f;
    private float targetDistance = -15f;
    private float currentDistance = -15f;
    private float zoomSpeed = 2f;
    private float minZoom = -15f;
    private float maxZoom = -5f;
    private float zoomSmooth = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lookAction = InputSystem.actions.FindAction("Look");
        zoomAction = InputSystem.actions.FindAction("Zoom");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(zoom.y);
        Look();
        Zoom();

        currentDistance = Mathf.Lerp(currentDistance, targetDistance,zoomSmooth * Time.deltaTime);

        playerOffset = new Vector3 (0,5,currentDistance);

        deseriedPos = playerPos.position + cameraRoot.rotation * playerOffset;
        transform.position = Vector3.Lerp(transform.position,deseriedPos,smoothCam * Time.deltaTime); 

    }
    void Look()
    {
        look = lookAction.ReadValue<Vector2>();

        var mouseDirectionX = look.x * sentivity;
        var mouseDirectionY = look.y * sentivity;
        
        yRotation += mouseDirectionX;
        xRotation -= mouseDirectionY;
        xRotation = Mathf.Clamp(xRotation,-5f,20f);    

        cameraRoot.rotation = Quaternion.Euler(0, yRotation, 0);
        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0, 0);

    }
    void Zoom()
    {
        zoom = zoomAction.ReadValue<Vector2>();

        var scroll = -zoom.y;

        targetDistance -= scroll * zoomSpeed;
        targetDistance = Mathf.Clamp(targetDistance,minZoom,maxZoom);

    }
}
