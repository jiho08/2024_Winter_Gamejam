using Hellmade.Sound;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public List<SoundData> soundControls = new List<SoundData>();

    [SerializeField] private Slider soundSizeSlider, musicSizeSlider;
    private float soundSize, musicSize;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(soundSizeSlider != null)
            soundSize = soundSizeSlider.value;
        if (musicSizeSlider != null)
            musicSize = musicSizeSlider.value;
    }

    public void SoundPlay(string Id)
    {
        SoundData currentSound = soundControls.Find(s => s.Id == Id);
        if (soundControls.Exists(s => s.Id == Id) && currentSound.soundType == SoundType.SFX)
        {
            currentSound.audio.Play(soundSize);
        }
        else
            Debug.Log("���带 ã�� �� ����");
    }

    public void MusicStart(string Id)
    {
        SoundData currentSound = soundControls.Find(s => s.Id == Id);
        if (soundControls.Exists(s => s.Id == Id) && currentSound.soundType == SoundType.BGM)
        {
            foreach(var item in soundControls)
                if(item.soundType == SoundType.BGM)
                    item.audio.Pause();

            currentSound.audio.Play(musicSize);
        }
        else
            Debug.Log("���带 ã�� �� ����");
    }
}

[System.Serializable]
public struct SoundData
{
    public string Id;
    public AudioClip audioclip;
    public Audio audio;
    public SoundType soundType;
}

public enum SoundType { SFX, BGM }
