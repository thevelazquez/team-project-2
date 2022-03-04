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
    public float range = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);
        player.Rotate(Vector3.up * speedH * Input.GetAxis("Mouse X"));
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKeyDown(KeyCode.E)) {
            Interact();
        }
    }

    void Interact() {
        RaycastHit target;

        //Debug.DrawRay(transform.position, transform.forward*2, Color.white, 5f);
        if (Physics.Raycast(transform.position, transform.forward, out target, range)) {
            GameObject obj = target.transform.gameObject;

            //Debug.Log(obj.name);
            if (obj.tag == "pickup") {
                //check if hitbox contains child game objects
                if (obj.transform.childCount > 0)
                {
                    switch (obj.transform.GetChild(0).name) {
                        case "Gun":
                            Transform gun = obj.transform.GetChild(0).transform;
                            gun.SetParent(transform);
                            gun.localPosition = Vector3.zero;
                            gun.localRotation = Quaternion.identity;
                            gun.Translate(.4f, 0, .6f);
                            gun.localRotation = Quaternion.Euler(-10f, 0, 0);
                            Debug.Log("Picked up gun");
                            break;
                        case "Key":
                            Debug.Log("Picked up key");
                            break;
                    }
                    obj.SetActive(false);
                } else {
                    obj.SetActive(false);
                }
            } else {
                Debug.Log("Not a pickup");
            }
        } 
    }
}
