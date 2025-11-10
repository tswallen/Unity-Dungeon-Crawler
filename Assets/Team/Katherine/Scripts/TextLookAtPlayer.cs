using UnityEngine;

public class TextLookAtPlayer : MonoBehaviour
{
    public Transform target;


    // Update is called once per frame

    private void Start()
    {
        target = FindAnyObjectByType<Camera>().transform;
    }
    void Update()
    {
        transform.LookAt(target);
    }
}
