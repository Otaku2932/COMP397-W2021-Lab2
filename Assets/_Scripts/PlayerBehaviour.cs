using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float movementForce;
    public float jumpForce;
    public Rigidbody rigid;
    public bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                //move right
                //Debug.Log("moves right");
                rigid.AddForce(Vector3.right * movementForce);
            }

            if (Input.GetAxisRaw("Horizontal") < 0)
            {
                //move right
                //Debug.Log("moves left");
                rigid.AddForce(Vector3.left * movementForce);
            }
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                //move right
                //Debug.Log("moves forward");
                rigid.AddForce(Vector3.forward * movementForce);
            }

            if (Input.GetAxisRaw("Vertical") < 0)
            {
                //move right
                //Debug.Log("moves back");
                rigid.AddForce(Vector3.back * movementForce);
            }

            if(Input.GetAxisRaw("Jump") > 0)
            {
                rigid.AddForce(Vector3.up * jumpForce);
            }
        }
        
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
