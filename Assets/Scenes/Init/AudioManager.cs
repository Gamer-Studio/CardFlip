using System;
using UnityEngine;

namespace CardFlip
{
  public class AudioManager : MonoBehaviour
  {
    public Single globalVolume
    {
      get => globalSource.volume;
      set => globalSource.volume = value;
    }
    public Single effectVolume
    {
      get => effectSource.volume;
      set => effectSource.volume = value;
    }

    [SerializeField]
    private AudioSource globalSource, effectSource;

    private void Awake()
    {
      globalVolume = PlayerPrefs.GetFloat("globalSound", 0.5f);
      effectVolume = PlayerPrefs.GetFloat("effectSound", 0.5f);
    }
  }
}