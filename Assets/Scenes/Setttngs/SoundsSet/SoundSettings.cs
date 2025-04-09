using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CardFlip
{
    public class SoundSettings : MonoBehaviour
    {
        public static SoundSettings Instance;

        public AudioClip matchClip;
        public AudioClip unmatchClip;
        public AudioClip flipClip;

        public AudioSource SoundAudioSource;
        public AudioSource EffectdAudioSource;
        public AudioSource MatchAudioSource;

        private float effectSoundCooldown = 1f;
        private float lastEffectSoundTime = 0f;

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
        }
        public void BGMSetting(float value)
        {
            SoundAudioSource.volume = value;
        }

        public void EffectSetting(float value)
        {
            EffectdAudioSource.volume = value;
            MatchAudioSource.volume = value;
            if (Time.time - lastEffectSoundTime >= effectSoundCooldown)
            {
                EffectdAudioSource.PlayOneShot(flipClip);
                MatchAudioSource.PlayOneShot(matchClip);

                lastEffectSoundTime = Time.time;
            }
        }
    }
}
