using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchMove1 : MonoBehaviour
{
    private GameManager gamemanager;
    public Transform startPoint;
    public Transform controlPoint1;
    public Transform middlePoint;
    public Transform controlPoint2;
    public Transform endPoint;

    public Camera mainCamera;
    public Transform launchCameraPoint;

    private Transform originalParent;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

    public Transform launchCameraPoint2;
    private bool cameraChanged = false;
    private Vector3 originalLocalPosition;
    private Quaternion originalLocalRotation;

    
    private bool isGrounded = false;

    public float duration = 10f;

    private float t = 0f;

    private bool isLaunching = false;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
    }

     private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Launcher1"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Launcher1"))
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
        

        if (!isLaunching) return;

        mainCamera.transform.LookAt(transform);

        t += Time.deltaTime / duration;

        Vector3 pos;

        if (t < 0.5f)
        {
            float localT = t * 2f;

            Vector3 p0 = startPoint.position;
            Vector3 p1 = controlPoint1.position;
            Vector3 p2 = middlePoint.position;

            pos =
                Mathf.Pow(1 - localT, 2) * p0 +
                2 * (1 - localT) * localT * p1 +
                Mathf.Pow(localT, 2) * p2;
        }
        else
        {
            float localT = (t - 0.5f) * 2f;

            Vector3 p0 = middlePoint.position;
            Vector3 p1 = controlPoint2.position;
            Vector3 p2 = endPoint.position;

            pos =
                Mathf.Pow(1 - localT, 2) * p0 +
                2 * (1 - localT) * localT * p1 +
                Mathf.Pow(localT, 2) * p2;
        }

        transform.position = pos;

        if (!cameraChanged && t >= 0.5f)
        {

            mainCamera.transform.position =
                launchCameraPoint2.position;

            cameraChanged = true;
        }


        if (t >= 1f)
        {
            isLaunching = false;

            // 元の親(Player)に戻す
            mainCamera.transform.SetParent(originalParent);

            mainCamera.transform.localPosition = originalLocalPosition;
            mainCamera.transform.localRotation = originalLocalRotation;
        }

        
    }

    // 発射開始
    public void Launch()
    {
        gamemanager.PlaySE_Launcher();

        originalParent = mainCamera.transform.parent;
        originalLocalPosition = mainCamera.transform.localPosition;
        originalLocalRotation = mainCamera.transform.localRotation;

        mainCamera.transform.SetParent(null);

        mainCamera.transform.position =
            launchCameraPoint.position;

        mainCamera.transform.rotation =
            launchCameraPoint.rotation;

        t = 0f;
        cameraChanged = false;
        isLaunching = true;
    }
}
