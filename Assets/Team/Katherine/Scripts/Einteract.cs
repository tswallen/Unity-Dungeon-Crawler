using System;
using TMPro;
using UnityEngine;

public class Einteract : MonoBehaviour
{
    GameManager gameManager;

    public GameObject E;

    public TMP_Text prompt;

    public string missingKeyText;

    public string keyTypeText;


    public enum KeySelect
    {
        Triangle,
        Square,
        Circle
    }

    public KeySelect keySelect;

    public bool canOpen = false;

    public int keyCount;

    public Animator doorAnimator;

    public AudioSource doorAudio;


    bool doorOpened;

    private void Start()
    {
        E.SetActive(false);
        doorOpened = false;
        //  doorAnimator = GetComponentInParent<Animator>();
        doorAudio = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && keyCount == 1)
        {
            E.SetActive(true);
            prompt.text = "Press E to use " + keySelect + " key";
            canOpen = true;



        }
        else if (other.gameObject.CompareTag("Player") && keyCount == 0)
        {
            E.SetActive(true);
            prompt.text = "This requires a " + keySelect + " key";

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            E.SetActive(false);

            canOpen = false;
        }
    }


    private void Update()
    {
        if (!canOpen)
        {
            KeySelection();
            return;
        }


        if (canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!doorOpened)
                {
                    //trigger door animation
                    doorAnimator.SetBool("DoorOpen", true);
                    keyCount = 0;
                    RemoveKey();
                    Destroy(E);
                    doorAudio.Play();
                    doorOpened = true;
                }

            }
        }
    }

    private void RemoveKey()
    {
        switch (keySelect)
        {
            case KeySelect.Triangle:
                GameManager.instance.triangle = 0;
                break;
            case KeySelect.Circle:
                GameManager.instance.circle = 0;
                break;
            case KeySelect.Square:
                gameManager.square = 0;
                break;



        }
    }

    public void KeySelection()
    {
        switch (keySelect)
        {
            case KeySelect.Triangle:
                keyCount = GameManager.instance.triangle;
                break;
            case KeySelect.Circle:
                keyCount = GameManager.instance.circle;
                break;
            case KeySelect.Square:
                keyCount = GameManager.instance.square;
                break;



        }

    }
}
