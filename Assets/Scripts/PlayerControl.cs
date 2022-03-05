using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float defaultSpeed = 4f;
    public float boostSpeed = 6f;
    public GuardControl guard;
    public float timeSped = 5f;
    float resetSpeed;
    float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        GetComponent<CharacterController>().Move(move * playerSpeed * Time.deltaTime);
        if (resetSpeed < Time.time)
        {
            playerSpeed = defaultSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "zone")
        {
            if(other.gameObject.GetComponent(typeof(TriggerGuard)) != null)
            {
                guard.SetTarget(null);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "zone")
        {
            if (other.gameObject.GetComponent(typeof(TriggerGuard)) != null)
            {
                guard.SetTarget(transform);
            }
        }
    }

    public void Speed()
    {
        resetSpeed = Time.time + timeSped;
        playerSpeed = boostSpeed;
    }
}
