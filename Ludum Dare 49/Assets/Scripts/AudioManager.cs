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
    public AudioClip[] AntVO;
    public AudioClip[] SpiderVO;
    public AudioClip[] FlyVO;
    public AudioClip[] MantisVO;
    public AudioClip[] StickVO;
    private void Awake() {
        _ = this;
    }

    public void PlayVO(int CID, int VL)
    {
        AudioClip[] array = null;

        switch (CID)
        {
            case 0: array = AntVO; break;
            case 1: array = SpiderVO; break;
            case 2: array = FlyVO; break;
            case 3: array = MantisVO; break;
            case 4: array = StickVO; break;
        }

        VoicePlayer.clip = array[VL];
        VoicePlayer.Play();
    }
}
