using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject win;

    public int circle;
    public int square;
    public int triangle;

    public int diamondScore;

    public AudioClip diamondCollection;
    public AudioClip keyCollection;

    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        win.SetActive(false);
        Time.timeScale = 1.0f;
        if (instance == null)
        {

            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }


    public void DiamondAddition(int collected)
    {
        diamondScore = diamondScore + collected;
        SFXManager.instance.PlaySFXClip(diamondCollection, player.transform, 0.2f);
    }

    public void KeyAddition(int key, GameObject keyType)
    {
        if (keyType.CompareTag("Square"))
        {
            square = square + key;
            SFXManager.instance.PlaySFXClip(keyCollection, player.transform, 0.2f);
        }
        else if (keyType.CompareTag("Circle"))
        {
            circle = circle + key;
            SFXManager.instance.PlaySFXClip(keyCollection, player.transform, 0.2f);
        }
        else if (keyType.CompareTag("Triangle"))
        {
            triangle = triangle + key;
            SFXManager.instance.PlaySFXClip(keyCollection, player.transform, 0.2f);
        }
    }




    // Update is called once per frame
    void Update()
    {
        if (diamondScore == 10)
        {
            win.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
