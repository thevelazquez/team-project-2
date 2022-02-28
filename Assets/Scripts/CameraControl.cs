using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public Transform player;

    float yaw = 0.0f;
    float pitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        player.Rotate(Vector3.up * speedH * Input.GetAxis("Mouse X"));
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
