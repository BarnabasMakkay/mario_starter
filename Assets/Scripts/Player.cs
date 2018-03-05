using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// variables taken from CharacterController.Move example script
	// https://docs.unity3d.com/ScriptReference/CharacterController.Move.html
	public float speed = 6.0F;
	public float jumpSpeed = 8.0F;
	public float gravity = 20.0F;
    public GameObject fireball;


    public int Lives = 3; // number of lives the player hs

    private Vector3 moveDirection = Vector3.zero;
    private bool falling;
    private bool jumping;
    private Vector3 start_position; // start position of the player
    bool facingRight;

	public Color WeaponColour;
	private Color NormalColour;

	public GameObject WeaponAmmo;

	bool hasWeapon = false;

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

        facingRight = true;
		NormalColour = GetComponent<Renderer> ().material.color;

    }

	public void Reset()
	{
		// reset the player position to the start position
		transform.position = start_position;
	}

	void Update()
	{
		
        // set facing direction and
		if (Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;

        }
		if (Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
        }

        // shoot fireball
        if (Input.GetKeyDown(KeyCode.UpArrow) && hasWeapon)
        {
			
            var fireballtemp = Instantiate(fireball);

            if (facingRight)
            {
				fireballtemp.transform.position = transform.position + Vector3.right * 2.0f;
				fireballtemp.GetComponent<FireballMovement>().SetXVelocityPositive();
            }
            else
            {
				fireballtemp.transform.position = transform.position + Vector3.left * 2.0f;
				fireballtemp.GetComponent<FireballMovement>().SetXVelocityNegative();
            }
        }

        // Check if the player is in collision with the grounf
        if ((controller.collisionFlags & CollisionFlags.CollidedBelow) != 0)
        {
            falling = false;
        }
        else
        {
            falling = true;
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

            // If the player is jumping and collides with something above stop the jump
            if (jumping && ((controller.collisionFlags & CollisionFlags.CollidedAbove)) != 0)
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


        if(hit.collider.tag == "Block")
        {
            
            // if the player is below the block activate it
            if((controller.collisionFlags & CollisionFlags.CollidedAbove) != 0)
            {

                // Activate the block
                hit.gameObject.GetComponent<Block>().PlayerReaction();

            }

        }

		if (hit.collider.tag == "Weapon") 
		{

			// Change the players colour??
			hasWeapon = true;
			GetComponent<Renderer> ().material.color = WeaponColour;
			Destroy (hit.collider.gameObject);

		}


    }

}