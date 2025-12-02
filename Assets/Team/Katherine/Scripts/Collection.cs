using UnityEngine;

public class Collection : MonoBehaviour
{
    public bool trueDiamondFalseKey;

    public bool canBeCollected;

    // public AudioSource sound;
    private void Start()
    {
        //sound = GetComponent<AudioSource>();
        canBeCollected = true;
    }
    private void OnTriggerEnter(Collider other)
    {

        //if (other.gameObject.CompareTag("Player") && trueDiamondFalseKey && canBeCollected)
        //{
        //    GameManager.instance.DiamondAddition(1);
        //  //  sound.Play();
        //    Destroy(gameObject);
        //}
        if (other.gameObject.CompareTag("Player") && !trueDiamondFalseKey)
        {
            GameManager.instance.KeyAddition(1, gameObject);
            //sound.Play();
            Destroy(gameObject);
        }
    }




    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && trueDiamondFalseKey && canBeCollected)
        {
            GameManager.instance.DiamondAddition(1);
            //  sound.Play();
            Destroy(gameObject);
        }
    }
}
