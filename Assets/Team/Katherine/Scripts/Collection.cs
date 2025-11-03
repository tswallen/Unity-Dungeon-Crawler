using UnityEngine;

public class Collection : MonoBehaviour
{
    public bool trueDiamondFalseKey;

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player") && trueDiamondFalseKey)
        {
            GameManager.instance.DiamondAddition(1);
        }
        else if (other.gameObject.CompareTag("Player") && !trueDiamondFalseKey)
        {
            GameManager.instance.KeyAddition(1);
        }
    }
}
