using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 8;
    [SerializeField]
    private float walkSpeed = 12;

    [SerializeField]
    private Rigidbody myRigibody;
    [SerializeField]
    private float gravityScale = 5;
    [SerializeField]
    private Camera myCamera;
    [SerializeField]
    private float closest = -10;
    [SerializeField]
    private float farthest = -10;

    [SerializeField]
    private float jumpHeight = 3;

    private float distToGround = 0.1f;
    private Vector3 jump;
    private float inputX;
    private float cameraInputZ;
    private bool isGrounded;
    private Vector3 moveVector;
    private Vector3 originalCamPosition;


    // Start is called before the first frame update
    void Awake()
    {
        originalCamPosition = myCamera.transform.localPosition;
        Cursor.visible = false;
        jump = new Vector3 (0.0f, 1.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        if (cameraInputZ < 0 && originalCamPosition.z > farthest || cameraInputZ > 0 && originalCamPosition.z < closest)
        {
            originalCamPosition.z += cameraInputZ;
        }
        myCamera.transform.position = myRigibody.transform.position + originalCamPosition;
        myRigibody.velocity = new Vector2(inputX * walkSpeed, myRigibody.velocity.y);

        if (!IsGrounded())
        {
            moveVector += Physics.gravity;
        }

        myRigibody.AddForce(Physics.gravity * (gravityScale - 1) * myRigibody.mass);
    }

    public void Jump(InputAction.CallbackContext value)
    {
        if (IsGrounded() && value.performed)
        {
            Debug.Log("yeah");
            float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * (gravityScale - 1) * myRigibody.mass));
            isGrounded = false;
            myRigibody.AddForce(jump * jumpForce, ForceMode.Impulse);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
          inputX = context.ReadValue<Vector2>().x;
    }

    private bool IsGrounded()
    {
        Debug.DrawLine(transform.position + new Vector3(0, 0.05f), transform.position + -Vector3.up * 0.1f, Color.green);
        LayerMask mask = LayerMask.GetMask("Ground");
        bool grounded = Physics.Raycast(transform.position + new Vector3(0, 0.05f), -Vector3.up, out RaycastHit hitInfo, 0.15f, mask);
        return grounded;
    }

    public void CameraZoom(InputAction.CallbackContext context)
    {
        cameraInputZ = context.ReadValue<float>();
    }
}
