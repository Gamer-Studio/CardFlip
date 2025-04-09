using System;
using UnityEngine;

namespace CardFlip
{
  public class AudioManager : MonoBehaviour
  {
    public float globalVolume
    {
      get => globalSource.volume;
      set => globalSource.volume = value;
    }
    public float effectVolume
    {
      get => effectSource.volume;
      set => effectSource.volume = value;
    }

    [SerializeField]
    private AudioSource globalSource, effectSource;

    private void Awake()
    {
      globalVolume = PlayerPrefs.GetFloat("globalSound", 0.3f);
      effectVolume = PlayerPrefs.GetFloat("effectSound", 0.3f);
    }
  }
}