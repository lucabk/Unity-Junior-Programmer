using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject hoodCamera;
    private bool isMainCameraActive = true;

    private void Start()
    {
        activateMainCamera();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isMainCameraActive)
            {
                activateHoodCamera();
                isMainCameraActive = false;
            } else
            {
                activateMainCamera();
                isMainCameraActive = true;
            }
        }
    }

    private void activateMainCamera()
    {
        mainCamera.SetActive(true);
        hoodCamera.SetActive(false);
    }

    private void activateHoodCamera()
    {
        hoodCamera.SetActive(true);
        mainCamera.SetActive(false);
    }
}
