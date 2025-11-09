using UnityEngine;

public class TextLookAtPlayer : MonoBehaviour
{
    public Transform target;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
