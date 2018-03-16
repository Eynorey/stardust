using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class AnimationController : MonoBehaviour {
	// How fast your object moves
    private float moveSpeed;
	// How fast your object will rotate in the direction of movement
    private float rotationSpeed;
    // jump vector
    private Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    private float jumpForce = 2.0f;

    private bool isWalking = false;
    //private bool isJumping = false;

    private Animator animator;

    private CharacterController cc;

    // Use this for initialization
    void Start () 
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        moveSpeed = 10;
        rotationSpeed = 10;
    }

    void LateUpdate() {
        float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        float moveVertical = Input.GetAxisRaw ("Vertical");
        isWalking = false;
        //isJumping = false;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if(movement != Vector3.zero)
        {
            isWalking = true;
            transform.rotation = Quaternion.LookRotation(movement);
        }
        if((Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Button_0")) && cc.isGrounded)
        {
            transform.position += (jump * jumpForce);
        }

        animator.SetBool("IsWalking", isWalking);
        //animator.SetBool("IsJumping", isJumping);
    }
}