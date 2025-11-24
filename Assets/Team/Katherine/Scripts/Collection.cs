using UnityEngine;

public class Collection : MonoBehaviour
{
    public bool trueDiamondFalseKey;

    public AudioSource sound;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player") && trueDiamondFalseKey)
        {
            GameManager.instance.DiamondAddition(1);
            sound.Play();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player") && !trueDiamondFalseKey)
        {
            GameManager.instance.KeyAddition(1, gameObject);
            sound.Play();
            Destroy(gameObject);  
        }
    }
}
