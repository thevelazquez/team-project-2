using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraControl : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    public GameObject player;
    public GuardControl guard;
    float yaw = 0.0f;
    float pitch = 0.0f;
    public float range = 10.0f;
    public float gunRange = 30.0f;
    int ammo = 0;
    bool hasKey = false;
    bool hasGoalKey = false;

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
        player.transform.Rotate(Vector3.up * speedH * Input.GetAxis("Mouse X"));
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetKeyDown(KeyCode.E)) {
            Interact();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && Cursor.lockState == CursorLockMode.Confined)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
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
                            obj.SetActive(false);
                            ammo++;
                            break;
                        case "Key":
                            hasKey = true;
                            obj.SetActive(false);
                            break;
                        case "Adrenaline":
                            Debug.Log("Sped up");
                            player.GetComponent<PlayerControl>().Speed();
                            obj.SetActive(false);
                            break;
                        case "doorlocked":
                            if (hasKey) {
                                obj.SetActive(false);
                            }
                            Debug.Log("You don't have the key");
                            break;
                        case "GoalKey":
                            Debug.Log("Picked up goal key");
                            hasGoalKey = true;
                            obj.SetActive(false);
                            break;
                        case "shutter":
                            if (hasGoalKey) {
                                obj.SetActive(false);
                            }
                            break;
                    }
                } else {
                    obj.SetActive(false);
                }
            } else {
                Debug.Log("Not a pickup");
            }
            if (obj.name == "Exit") {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("WinScene");
            }
        } 
    }

    void Shoot()
    {
        RaycastHit target;

        //Debug.DrawRay(transform.position, transform.forward*2, Color.white, 5f);
        if (Physics.Raycast(transform.position, transform.forward, out target, gunRange))
        {
            GameObject obj = target.transform.gameObject;

            if (obj.transform.gameObject.GetComponent(typeof(GuardControl)) != null)
            {
                if (player.transform.Find("Main Camera/Gun") != null)
                {
                    if (ammo <= 0)
                    {
                        Debug.Log("No ammo");
                        return;
                    }
                    Debug.Log("Stunned");
                    guard.Stun();
                    ammo--;
                }
                else
                {
                    Debug.Log("Player doesn't have gun");
                }
            }
        }
    }
}
