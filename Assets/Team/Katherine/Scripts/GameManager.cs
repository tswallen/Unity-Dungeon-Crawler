using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject win;

    public int circle;
    public int square;
    public int triangle;

    public int diamondScore;
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
    }

    public void KeyAddition(int key, GameObject keyType)
    {
        if (keyType.CompareTag("Square"))
        {
            square = square + key;
        }
        else if (keyType.CompareTag("Circle"))
        {
            circle = circle + key;   
        }
        else if (keyType.CompareTag("Triangle"))
        {
            triangle = triangle + key;
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
