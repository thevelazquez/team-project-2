using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10f;
    public GuardControl guard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        GetComponent<CharacterController>().Move(move * speed * Time.deltaTime);
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
}
