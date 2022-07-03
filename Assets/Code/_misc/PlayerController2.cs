using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private float movespeed;
    private float jumpforce;
    private bool isjumping;
    private float moveHorizontal;
    private float moveVertical;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        movespeed = 3f;
        jumpforce = 40f;
        isjumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
       
        if (Input.GetKey(KeyCode.Space))
        {
            moveVertical = 1;
        }
        else
        {
            moveVertical = Input.GetAxisRaw("Vertical");
         
        }
        // Debug.Log(Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * movespeed, 0f), ForceMode2D.Impulse);


        }
        if (!isjumping && moveVertical > 0.1f)
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpforce), ForceMode2D.Impulse);
        }





        if (moveHorizontal > 0)
        {
            gameObject.transform.localScale = new Vector3(3, 4, 1);
        }

        if (moveHorizontal < 0)
        {
            gameObject.transform.localScale = new Vector3(-3, 4, 1);
        }







    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "Platform")
        {
            isjumping = false;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isjumping = true;
        }
    }
}
