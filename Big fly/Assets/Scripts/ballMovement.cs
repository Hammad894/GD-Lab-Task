using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMovement : MonoBehaviour
{
    private float speed = 6f;
    private float movement = 0f;
    private float jumpSpeed = 7f; 
    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        //Debug.Log(movement);
        
        if(movement>0)
        {
            rigidbody.velocity = new Vector2(movement * speed,rigidbody.velocity.y);
        }
        else if(movement<0)
        {
            rigidbody.velocity = new Vector2(movement * speed,rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {

            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
        }

    }
    void OnTriggerEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Destroy(other.gameObject);
        }
    }

}
