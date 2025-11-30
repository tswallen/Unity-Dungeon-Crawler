using System;
using System.Collections;
using UnityEngine;

public class ChestTrigger : MonoBehaviour
{
    public Animator ChestAnimator;


    public Transform upMovement;

    public Transform downMovement;

    public float movementTime;

    public GameObject diamondPrefab;

    bool opened;

    GameObject newDiamond;

    int stage;

    public AudioClip chestOpenSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        opened = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((newDiamond != null) && stage == 1)
        {
            newDiamond.transform.position = Vector3.MoveTowards(newDiamond.transform.position, upMovement.position, 0.1f);
        }

        if ((newDiamond != null) && stage == 2)
        {
            newDiamond.transform.position = Vector3.MoveTowards(newDiamond.transform.position, downMovement.position, 0.1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ChestAnimator.SetTrigger("ChestOpen");
            if (!opened)
            {
                opened = true;
                SFXManager.instance.PlaySFXClip(chestOpenSound, transform, 0.5f);
                StartCoroutine(MoveDiamond(newDiamond));


            }
        }
    }


    private IEnumerator MoveDiamond(GameObject spawnedDiamond)
    {
        yield return new WaitForSeconds(movementTime);
        newDiamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);
        stage = 1;
        yield return new WaitForSeconds(movementTime);
        stage = 2;

    }
}
