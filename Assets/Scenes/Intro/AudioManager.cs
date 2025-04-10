using System;
using UnityEngine;
using UnityEngine.Audio;

namespace CardFlip
{
  public class AudioManager : MonoBehaviour
  {
    public AudioSource Bgm => bgmSource;
    public AudioSource Effect => effectSource;
    // 0~100 값을 가질 수 있는 전역 볼륨 프로퍼티입니다.
    // 기본값은 80입니다.
    public float globalVolume
    {
      get
      {
        if (audioMixer.GetFloat("Master", out var volume)) return volume + 80;
        else return 0;
      }
      set
      {
        audioMixer.SetFloat("Master", value - 80);
      }
    }

    // 0~100값을 가질 수 있는 배경음음 볼륨 프로퍼티입니다.
    // 기본값은 80입니다.
    public float bgmVolume
    {
      get
      {
        if (audioMixer.GetFloat("Bgm", out var volume)) return volume + 80;
        else return 0;
      }
      set
      {
        audioMixer.SetFloat("Bgm", value - 80);
      }
    }

    // 0~100값을 가질 수 있는 효과음 볼륨 프로퍼티입니다.
    // 기본값은 100입니다.
    public float effectVolume
    {
      get
      {
        if (audioMixer.GetFloat("SFX", out var volume)) return volume + 80;
        else return 0;
      }
      set
      {
        audioMixer.SetFloat("SFX", value - 80);
      }
    }

    [SerializeField]
    private AudioMixer audioMixer;

    [SerializeField]
    private AudioSource bgmSource, effectSource;
    private void Start()
    {
      globalVolume = PlayerPrefs.GetFloat("globalVolume", 80f);
      bgmVolume = PlayerPrefs.GetFloat("bgmVolume", 80f);
      effectVolume = PlayerPrefs.GetFloat("effectVolume", 100f);
    }
  }
}