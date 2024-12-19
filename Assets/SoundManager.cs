using Hellmade.Sound;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public SoundData[] soundControls;

    [SerializeField] private Slider soundSizeSlider, musicSizeSlider;
    public float soundSize, musicSize = 1f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        for(int i = 0; i < soundControls.Length; i++)
        {
            if (soundControls[i].audio == null)
            {
                int audioID = EazySoundManager.PlayMusic(soundControls[i].audioclip, soundControls[i].soundType == SoundType.SFX ? soundSize : musicSize, true, false);
                soundControls[i].audio = EazySoundManager.GetAudio(audioID);
            }
        }
    }

    private void Update()
    {
        if(soundSizeSlider != null)
            soundSize = soundSizeSlider.value;
        if (musicSizeSlider != null)
            musicSize = musicSizeSlider.value;
    }

    public void SFXPlay(string name)
    {
        SoundData currentSound = soundControls.ToList().Find(s => s.name == name);
        if (soundControls.ToList().Exists(s => s.name == name) && currentSound.soundType == SoundType.SFX)
        {
            currentSound.audio.Play(soundSize);
        }
        else
            Debug.Log("사운드를 찾을 수 없음");
    }

    public void BGMPlay(string name)
    {
        SoundData currentSound = soundControls.ToList().Find(s => s.name == name);
        if (soundControls.ToList().Exists(s => s.name == name) && currentSound.soundType == SoundType.BGM)
        {
            foreach(var item in soundControls)
                if(item.soundType == SoundType.BGM)
                    item.audio.Pause();

            currentSound.audio.Play(musicSize);
        }
        else
            Debug.Log("사운드를 찾을 수 없음");
    }
}

[System.Serializable]
public struct SoundData
{
    public string name;
    public AudioClip audioclip;
    public Audio audio;
    public SoundType soundType;
}

public enum SoundType { SFX, BGM }
