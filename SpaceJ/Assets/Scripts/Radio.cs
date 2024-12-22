using System.Collections;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioClip[] songs;
    public AudioClip intro;

    private AudioSource audioSource;
    private int currentSongIndex = 0;
    private bool first_time = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // If it was already playing, it unpauses; if not, it starts from the beginning
    public void SwitchRadio()
    {
        Debug.Log("Ha entrado en el switch");
        if (!audioSource.isPlaying && songs.Length > 0)
        {
            if (!first_time)
            {
                Debug.Log("Despausar");
                audioSource.UnPause();
            }
            else
            {
                Debug.Log("Intro cadena 100");
                StartCoroutine(CorutineIntro());
                first_time = false;
            }
        } else if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void NextSong()
    {
        if (audioSource.isPlaying)
        {
            currentSongIndex = (currentSongIndex + 1) % songs.Length;
            PlaySong(currentSongIndex);
        }
    }

    public void PreviousSong()
    {
        if (audioSource.isPlaying)
        {
            currentSongIndex = (currentSongIndex - 1 + songs.Length) % songs.Length;
            PlaySong(currentSongIndex);
        }
    }

    private void PlaySong(int songIndex)
    {
        if (songs.Length == 0) return;

        audioSource.Stop();
        audioSource.clip = songs[songIndex];
        audioSource.Play();

        Debug.Log($"¿Está reproduciendo? {audioSource.isPlaying}");
    }

    private IEnumerator CorutineIntro()
    {
        if (intro != null)
        {
            Debug.Log("Entra a la corutina");
            audioSource.clip = intro;
            Debug.Log($"Clip asignado: {audioSource.clip.name}, Volume: {audioSource.volume}, Mute: {audioSource.mute}");
            audioSource.Play();
            Debug.Log($"¿Está reproduciendo? {audioSource.isPlaying}");

            yield return new WaitForSeconds(audioSource.clip.length);
        }

        PlaySong(currentSongIndex);
    }

    // Update is called once per frame
    void Update()
    {
        // Manual controls: 8 -> previous; 9 -> pause/continue; 0 -> next
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SwitchRadio();
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            PreviousSong();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            NextSong();
        }

        // Avanzar automáticamente cuando la canción termina
        if (!audioSource.isPlaying && audioSource.clip != null)
        {
            NextSong();
        }
    }
}
