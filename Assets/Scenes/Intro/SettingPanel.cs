using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardFlip
{
  public class SettingPanel : MonoBehaviour
  {
    [SerializeField]
    private Slider globalSoundSlider, effectSoundSlider;
    private void OnEnable()
    {
      globalSoundSlider.value = PlayerPrefs.GetFloat("globalSound", 0.5f);
      effectSoundSlider.value = PlayerPrefs.GetFloat("effectSound", 0.5f);
    }

    private void OnDisable()
    {
      PlayerPrefs.GetFloat("globalSound", globalSoundSlider.value);
      PlayerPrefs.GetFloat("effectSound", effectSoundSlider.value);
    }

    public void Back()
    {
      PanelManager.Instance.OpenSetting = false;
    }

    public void ChangeGlobalSound(float value)
    {
      GameManager.Instance.audio.globalVolume = value;
    }

    public void ChangeBackgroundSound(float value)
    {

    }

    public void ChangeEffectSound(float value)
    {
      GameManager.Instance.audio.effectVolume = value;
    }
  }
}
