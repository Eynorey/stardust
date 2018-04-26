using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class AnimationController : MonoBehaviour {
	public List<GameObject> Logs = new List<GameObject>();
	public List<GameObject> Shipparts = new List<GameObject>();
    public List<GameObject> Fuel = new List<GameObject>();
	// How fast your object will rotate in the direction of movement
    private float rotationSpeed;
    // jump vector
    private Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
    private float jumpForce = 2.0f;

    public bool isWalking = false;
    //private bool isJumping = false;

    private GameObject camswitchWall;
    private Camera mainCam;
    private Camera thirdPersonCam;

    private Animator animator;

    private CharacterController cc;
    private string scene;

    // Use this for initialization
    void Start () 
    {
        scene = SceneManager.GetActiveScene().name;
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //moveSpeed = 10;
        rotationSpeed = 10;
        camswitchWall = GameObject.Find("camswitchWall");
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();

        if (scene != "scene_1")
            return;

        thirdPersonCam = GameObject.Find("thirdPersonCam").GetComponent<Camera>();
    }

    void Update()
    {
        if (scene != "scene_1")
            return;
        if (transform.position.z > camswitchWall.transform.position.z)
        {
            thirdPersonCam.gameObject.SetActive(true);
            mainCam.gameObject.SetActive(false);
        }
        else
        {
            mainCam.gameObject.SetActive(true);
            thirdPersonCam.gameObject.SetActive(false);
        }
    }

    void LateUpdate() {
        /* */
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
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Button_0")) && cc.isGrounded)
        {
            transform.position += (jump * jumpForce);
        }

        animator.SetBool("IsWalking", isWalking);
        //animator.SetBool("IsJumping", isJumping);
    }
}