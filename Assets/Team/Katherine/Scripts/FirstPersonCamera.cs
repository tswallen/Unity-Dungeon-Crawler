using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    
    
    //how fast the camera should move
    public float sensitivity;
    // the player position, assign the object here, transform function gives the option to assign another objects tranform stats here
    public Transform playerTransform;
    //how low can we look
    public float verticalRotationMin;
    //how high can we look
    public float verticalRotationMax;
    //what is our current camera direction
    private float currentHorizonalRotation;
    private float currentVerticalRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //euler angles are referring to the transform rotation (transform component of the camera), here we are looking to left and right, which is in this case is your Y, as we are not moving around we are moving along
        currentHorizonalRotation = transform.localEulerAngles.y;
        //this is up and down
        currentVerticalRotation = transform.localEulerAngles.x;

    }

    // Update is called once per frame
    void Update()
    {
        //mouse input for horizontal
        currentHorizonalRotation += Input.GetAxis("Mouse X") * sensitivity;
        //in unity it is the opposite of how computers are set up, so for vertical you have to minus here, because of screen space (down is bigger) to unity space(up is bigger)
        currentVerticalRotation -= Input.GetAxis("Mouse Y") * sensitivity;

        //constrain (aka clamp) our vertical rotation
        // takes in a number (which is the current vertical rotation) and checks if it fits the min and the max
        currentVerticalRotation = Mathf.Clamp(currentVerticalRotation,verticalRotationMin, verticalRotationMax);

        //assign the local euler angles to the set vertical and horizontal rotation, updates the info that the game starts with, transforms them based on new info
        transform.localEulerAngles = new Vector3(currentVerticalRotation, currentHorizonalRotation);

        //snap to the player's position, camera position is the player (the object we set in the inspecter)
        transform.position = playerTransform.position;


    }
}
