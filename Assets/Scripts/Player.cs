using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// variables taken from CharacterController.Move example script
	// https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;


    public int Lives = 3; // number of lives the player hs

    private Vector3 moveDirection = Vector3.zero;
    private bool falling;
    private bool jumping;
    private Vector3 start_position; // start position of the player

    // get the character controller attached to the player game object
    private CharacterController controller;

    void Start()
	{
		// record the start position of the player
		start_position = transform.position;

        // Get the player controller
        controller = GetComponent<CharacterController>();

        // set the falling assume the player is falling
        falling = true;
        jumping = false;

    }

	public void Reset()
	{
		// reset the player position to the start position
		transform.position = start_position;
	}

	void Update()
	{

        if(controller.collisionFlags == CollisionFlags.None)
        {
            Debug.Log("Stuck");
        }


        Debug.Log(controller.collisionFlags);

        if (controller.collisionFlags == CollisionFlags.Below)
        {
            falling = false;
            Debug.Log("On the ground");
        }
        else
        {
            falling = true;
            Debug.Log("Falling");
        }


        // check to see if the player is on the ground
        if (!falling)
        {
            // set the movement direction based on user input and the desired speed
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            // check to see if the player should jump
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
                jumping = true;
            }
        }
        else
        {

            if (jumping && controller.collisionFlags == CollisionFlags.CollidedAbove)
            {
                moveDirection.y = 0.0f;
                jumping = false;
            }

            // apply gravity to movement direction
            moveDirection.y -= gravity * Time.deltaTime;

        }

		// make the call to move the character controller
		controller.Move(moveDirection * Time.deltaTime);

	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }

}