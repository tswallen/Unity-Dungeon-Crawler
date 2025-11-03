using UnityEngine;


//an attribute helps define how this script should work
[RequireComponent(typeof(Rigidbody))]
//RequireComponent tells the script to check the obects for important components, when the script 
[RequireComponent(typeof(CapsuleCollider))]



// this script only works for flat surfaces

public class PlayerController : MonoBehaviour
{
    public float speed;

    //variables for jump
    public float jumpPower;
    public float gravity;


    //the x and y key press
    public Vector2 currentInput;
   
    //the x y z axis of movement
    public Vector3 movement;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;

    public Transform cameraTransform;



    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get the rigidbody component reference and save it (links the script to the rigidboyd component attached to the capsule)

        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        rb.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        // get our input into the varibale we made for them
        currentInput.x = Input.GetAxis("Horizontal");
        currentInput.y = Input.GetAxis("Vertical");
        //update our movement vector based on our inputs
        movement = new Vector3(currentInput.x, 0, currentInput.y);

       
      // apply our speed to our movement direction
         movement *= speed;

        // if we have a camera assigned, we should rotate based on what the camera is doing
       
        if (cameraTransform != null) 
        { //matches left/right rotation to the camera
            transform.localEulerAngles = new Vector3(0, cameraTransform.localEulerAngles.y);
            //translate/change the movement from global forward to local forward
            movement = transform.TransformDirection(movement);

        
        }



        // applies gravity by getting gravity and minus the time of the game
        movement.y = rb.linearVelocity.y - gravity * Time.deltaTime;

        //give this movement to the rigidbody
        rb.linearVelocity = movement;


        //jump button is already set up in unity as space bar
        // to check for a bool and a float you need to wrap the bool 'if' statement around the float if statement, it will then check for one after the other
        if (isGrounded ())
        {
            if (Input.GetButtonDown("Jump"))
            {//&& rb.linearVelocity.y<0.01f - alternative add on to check if player is on the ground, this probably wouldlnt work if there are platforms as the player could still jump if they go off the edge
                Jump();
            }
        }

    }

    private void Jump()
    {

        // it only needs to be used in the case of jump
        //copy the vector 3 currently tracking our velocity
        // local variable - functions like any other variable but only exists within the allocated function
        // to get a local variable, just say what data type you want and name it
        
        
        Vector3 currentVelocity = rb.linearVelocity;

        //change the y value of that vector 3
        currentVelocity.y = jumpPower;

        //apply the copied vector back to our velocity
        rb.linearVelocity = currentVelocity;




    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, capsuleCollider.height / 2f + 0.01f);
    }
}
