using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    private bool isBlock = true;
    private AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManagerScript.score = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = rb.velocity;
        Vector3 rayPosition = transform.position;
        Ray ray = new Ray(rayPosition, Vector3.down);

        float distance = 0.6f;
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

        isBlock = Physics.Raycast(ray, distance);

        if (GoalScript.isGameClear ==  false)
        {
            if (isBlock == true)
            {
                //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
                if (Input.GetKey(KeyCode.Space))
                {
                    v.y = 9;
                }
            }
            else
            {
                //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
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
