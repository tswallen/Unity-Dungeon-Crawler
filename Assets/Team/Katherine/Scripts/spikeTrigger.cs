using UnityEngine;

public class spikeTrigger : MonoBehaviour
{
    public GameObject deathScreen;

    public AudioClip deathFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            SFXManager.instance.PlaySFXClip(deathFX, transform, 0.2f);
            deathScreen.SetActive(true);

        }
    }
}
