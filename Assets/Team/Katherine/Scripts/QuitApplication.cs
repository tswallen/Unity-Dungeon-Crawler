using UnityEngine;

public class QuitApplication : MonoBehaviour
{
   public void QuitGame()
    {
        Application.Quit();
        print("the game has been quit");
    }
}
