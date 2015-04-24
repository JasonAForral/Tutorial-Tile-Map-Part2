using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    private Transform cameraTilt;
    private Transform cameraZoom;
    
    public float rotateSpeed = 1f;
    public float mouseSlideSpeed = 1f;
    public float keyboardSlideSpeed = 1f;
    public float zoomSpeed = 50f;
    public float panSpeed = 1f;

    // Use this for initialization
    void Awake ()
    {
        //if (null == cameraTilt)
            cameraTilt = transform.GetChild(0);
        //if (null == cameraZoom)
            cameraZoom = cameraTilt.GetChild(0);
    }

    // Update is called once per frame
    void Update ()
    {


    }

    void LateUpdate ()
    {
        if (Input.GetButton("Fire2"))
        {
            transform.Translate(-1.0f * panSpeed * mouseSlideSpeed * new Vector3(Input.GetAxis("Mouse X"), 0.0f, Input.GetAxis("Mouse Y")));
        }

        if (Input.GetButton("Fire3"))
        {
            transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * rotateSpeed);
            cameraTilt.Rotate(Vector3.left * Input.GetAxisRaw("Mouse Y") * rotateSpeed);
            cameraTilt.localEulerAngles = Vector3.right * Mathf.Clamp(cameraTilt.localEulerAngles.x, 10f, 80f);

        }

        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * panSpeed * keyboardSlideSpeed);

        cameraZoom.Translate(Vector3.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed);
        cameraZoom.localPosition = Vector3.forward * Mathf.Round(Mathf.Clamp(cameraZoom.localPosition.z, -110f, -5f));
        panSpeed = -cameraZoom.localPosition.z * 0.03f;

    }
}