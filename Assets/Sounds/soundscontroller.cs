using UnityEngine;

public class soundscontroller : MonoBehaviour
{
    public static soundscontroller Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }
    public void EjecutarSonido(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}
