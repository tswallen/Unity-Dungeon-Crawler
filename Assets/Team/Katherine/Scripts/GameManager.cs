using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject win;

    public int keyScore;
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

    public void KeyAddition(int key)
    {
        keyScore = keyScore + key;
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
