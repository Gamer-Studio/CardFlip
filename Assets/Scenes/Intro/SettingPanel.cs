using UnityEngine;
using UnityEngine.UI;

namespace CardFlip
{
  public class SettingPanel : MonoBehaviour
  {
    [SerializeField]
    private Slider globalSoundSlider, bgmSoundSlider, effectSoundSlider;
    private void OnEnable()
    {
      Debug.Log("load");
      globalSoundSlider.value = PlayerPrefs.GetFloat("globalVolume", 80f);
      bgmSoundSlider.value = PlayerPrefs.GetFloat("bgmVolume", 80f);
      effectSoundSlider.value = PlayerPrefs.GetFloat("effectVolume", 100f);
    }

    public void Back()
    {
      PlayerPrefs.SetFloat("globalVolume", globalSoundSlider.value);
      PlayerPrefs.SetFloat("bgmVolume", bgmSoundSlider.value);
      PlayerPrefs.SetFloat("effectVolume", effectSoundSlider.value);
      PanelManager.Instance.OpenSetting = false;
    }

    public void ChangeGlobalSound(float value)
    {
      GameManager.Instance.audio.globalVolume = value;
    }

    public void ChangeBackgroundSound(float value)
    {
      GameManager.Instance.audio.BgmVolume = value;
    }

    public void ChangeEffectSound(float value)
    {
      GameManager.Instance.audio.effectVolume = value;
    }
  }
}
