using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CardFlip
{
    public class SoundSettings : MonoBehaviour
    {
        public static SoundSettings instance;
        AudioSource audioSource;
        public AudioClip clip;

        
        public AudioMixer audioMixer;

        // 슬라이더
        public Slider SoundSlider;
        public Slider EffectSlider;

        public AudioSource SoundAudioSource;
        public AudioSource EffectdAudioSource;
        // 볼륨 조절
        public void SetBgmVolme()
        {
            // 로그 연산 값 전달
       
        }

        private void Awake()
        {
            if (instance = null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }
        public void Start()
        {
            SoundSlider.onValueChanged.AddListener((value)=> { SoundAudioSource.volume = value; });
            EffectSlider.onValueChanged.AddListener((value) => { EffectdAudioSource.volume = value; });
        }
    }
}
