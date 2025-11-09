using TMPro;
using UnityEngine;

public class Einteract : MonoBehaviour
{
    GameManager gameManager;

    public GameObject E;

    public TMP_Text prompt;

    public string missingKeyText;

    public string youHaveAKey;


    bool canOpen = false;

    private void Start()
    {
        E.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player") && GameManager.instance.keyScore == 1)
        {
            E.SetActive(true);
            prompt.text = youHaveAKey;
            canOpen = true;


           
        }
        else if (other.gameObject.CompareTag("Player") && GameManager.instance.keyScore != 1)
        {
            E.SetActive(true);
            prompt.text = missingKeyText;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            E.SetActive(false);
        }
    }


    private void Update()
    {
        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //trigger door animation
                GameManager.instance.keyScore--;
                Destroy(E);
            }
        }
    }
}
