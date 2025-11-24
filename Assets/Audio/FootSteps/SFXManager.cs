using UnityEngine;

public class SFXManager : MonoBehaviour
{

    public static SFXManager instance;
    [SerializeField] private AudioSource SFXObject;

    //sfxobject is a prefab that is made and attached in editor, this gets instantiated everytime you call a sound by script
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    //one-shot sound effect player only
    //creates a one time gameobject on sound that is then instantly destroyed

    //setup for playing a single sound, just need to refer to this instance

    //called in other  scripts by sfx.instance.PlaySFXClip(audioclip, position, volume)
    public void PlaySFXClip(AudioClip audioClip, Transform spawnTransform, float volume)
    {

        //when called it instantiates an object at the position allocated in the other script
        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);

        //audiosource clip is the one that comes from the other script, where you attach an audioclip variable with the sound
        audioSource.clip = audioClip;   

        //volume is a float between 0.1-0.5, have to see how the sound is and adjust if it is quiet 
        audioSource.volume = volume;

        //plays on instance
        audioSource.Play();

        //goes for however long the clip goes for, so just plays once
        float clipLength = audioSource.clip.length; 

        //it then destroys itself at the end 
        Destroy(audioSource.gameObject, clipLength);






    }

    //setup for a randomsound array, need a list of sounds and reference to this array

    //same as single clip but includes an array where it randomly picks from the array

    //can play single sounds but allows more sounds to be played than the single for variation
    public void PlayRandomSFXClip(AudioClip[] audioClip, Transform spawnTransform, float volume)
    {

        int randomSelection = Random.Range (0, audioClip.Length);

        AudioSource audioSource = Instantiate(SFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip[randomSelection];

        audioSource.volume = volume;


        audioSource.Play();


        float clipLength = audioSource.clip.length;


        Destroy(audioSource.gameObject, clipLength);






    }

}
