using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour { 

    private Rigidbody rb;

    private float cameraRotationX = 0f;
    private float currentCameraRotationX = 0f;
    private float cameraRotationY = 0f;
    private float currentCameraRotationY = 0f;
    [SerializeField]
    private float cameraRotationLimit = 85f;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Camera weaponCam;
    [SerializeField]
    private GameObject crosshair;

    [HideInInspector]
    public bool zoom = false;

    [SerializeField]
    private int normalZoom;
    [SerializeField]
    private int extraZoom;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ZoomCamera();
        PerformRotation();
    }

    // Gets rotation vector
    public void Rotate(float _cameraRotationY)
    {
        cameraRotationY = _cameraRotationY;
    }

    // Gets a rotational vector for the camera
    public void RotateCamera(float _cameraRotationX)
    {
        cameraRotationX = _cameraRotationX;
    }

    void ZoomCamera()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            zoom = true;
            cam.fieldOfView = extraZoom;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            zoom = false;
            cam.fieldOfView = normalZoom;
        }

        weaponCam.enabled = !zoom;
        crosshair.SetActive(!zoom);
    }

    void PerformRotation()
    {
        if (cam != null)
        {
            // Set our rotation and clamp it
            currentCameraRotationX -= cameraRotationX;
            currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);
            // Set our rotation and clamp it
            currentCameraRotationY -= cameraRotationY;
            currentCameraRotationY = Mathf.Clamp(currentCameraRotationY, -cameraRotationLimit, cameraRotationLimit);

            //Apply our rotation to the transform of our camera
            // random range is shake effect
            cam.transform.localEulerAngles = new Vector3(currentCameraRotationX, currentCameraRotationY, 0f);
        }
    }
}
