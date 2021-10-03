using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager _;

    public AudioSource MusicPlayer;
    public AudioSource VoicePlayer;
    public AudioSource SFXPlayer;

    public AudioClip MusicLoop;
    public AudioClip ScissorSnip;
    public AudioClip ClipperBuzz;
    private void Awake() {
        _ = this;
    }
}
