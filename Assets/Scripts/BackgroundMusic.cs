using UnityEngine;
using UnityEngine.UI;

public class PlayPauseMusic : MonoBehaviour
{
    public AudioSource backgroundMusic;  // Reference to the AudioSource component
    public Button playPauseButton;       // Reference to the Button component
    private bool isPlaying = true;       // Track if the music is playing or not

    void Start()
    {
        // Add listener to the button's click event
        playPauseButton.onClick.AddListener(ToggleMusic);

        // Start the music when the game starts
        backgroundMusic.Play();
    }

    // Function to toggle between play and pause
    void ToggleMusic()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            return;
        }
        if (isPlaying)
        {
            backgroundMusic.Pause();     // Pause the music
        }
        else
        {
            backgroundMusic.Play();      // Play the music
        }

        isPlaying = !isPlaying;          // Toggle the playing state
    }
}