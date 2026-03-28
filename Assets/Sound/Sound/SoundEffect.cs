using UnityEngine;

public class SoundEffect : MonoBehaviour
{

    public AudioSource soundCrash;
    public AudioSource soundFuelUp;
    public AudioSource soundSlotUp;
    public AudioSource soundDone;

    public void PlayCrash()
    {
        soundCrash.Play();
    }
    public void PlaySlotUp()
    {
        soundSlotUp.Play();
    }
    public void PlayFuelUp()
    {
        soundFuelUp.Play();
    }
    public void PlayDone()
    {
        soundDone.Play();
    }
}
