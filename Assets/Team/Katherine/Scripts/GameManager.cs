using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public int keyScore;
    public int diamondScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
        
    }
}
