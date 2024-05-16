using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = rb.velocity;
        if(GoalScript.isGameClear ==  false)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                v.y = 5;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                v.x = 5;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                v.x = -5;
            }
            rb.velocity = v;
        }
        else {
            // Rigidbody‚ð‚Æ‚ß‚é
            rb.isKinematic = true;
        }
    }
}
