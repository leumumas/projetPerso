using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float runSpeed = 8;
    public float walkSpeed = 12;

    Rigidbody myRigibody;


    public bool isGrounded;
    public float jumpHeight = 3;
    public Vector3 jump;
   


    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        myRigibody = GetComponent<Rigidbody>();
        jump = new Vector3 (0.0f, 2.0f, 0.0f);


    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionStay()
    {
        isGrounded = true;
    }
    private void FixedUpdate()
    {
        float jumpPress = Input.GetAxis("Fire1");
        if (isGrounded && jumpPress!=0)
        {
            Debug.Log("yeah");
            isGrounded = false;
            myRigibody.AddForce(jump * jumpHeight, ForceMode.Impulse);
        }
   
        float move = Input.GetAxis("Horizontal");
        myRigibody.velocity = new Vector3(move * runSpeed, myRigibody.velocity.y, 0);
     
    }

    void Jump()
    {
        

    }

    
}
