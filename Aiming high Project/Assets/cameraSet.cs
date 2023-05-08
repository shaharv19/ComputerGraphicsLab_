using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSet : MonoBehaviour
{
    public Transform player;

    public float mouseSensivity = 100f;
    float xRoatation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;
        xRoatation -= mouseY;
        xRoatation = Mathf.Clamp(xRoatation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRoatation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);

    }
}
