using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Sources ---------")]
    public AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip ------------")]
    public AudioClip background;
    public AudioClip tension;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
