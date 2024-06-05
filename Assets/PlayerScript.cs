using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    private bool isBlock = true;
    private AudioSource audioSource;
    public GameObject bombParticle;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            Instantiate(bombParticle, transform.position, Quaternion.identity);
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
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 v = rb.velocity;
        Vector3 rayPosition = transform.position + new Vector3(0.0f,0.8f,0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);

        float distance = 0.9f;
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

        isBlock = Physics.Raycast(ray, distance);

        if (GoalScript.isGameClear ==  false)
        {
            if (isBlock == true)
            {
                animator.SetBool("Jump", false);
                //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
                if (Input.GetKey(KeyCode.Space))
                {
                    v.y = 8;
                }
            }
            else
            {
                animator.SetBool("Jump", true);
                //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
                v.x = 5;
                animator.SetBool("Walk", true);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
                v.x = -5;
                animator.SetBool("Walk", true);
            }
            else
            {
                animator.SetBool("Walk", false);
                v.x = 0;
            }
            rb.velocity = v;
        }
        else {
            // Rigidbody‚ð‚Æ‚ß‚é
            rb.isKinematic = true;
        }
    }
}
