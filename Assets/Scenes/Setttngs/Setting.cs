using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace CardFlip
{
    public class Setting : MonoBehaviour
    {
        public Slider SoundSlider;
        public Slider EffectSlider;

        public void Start()
        {
            SoundSlider.onValueChanged.AddListener((value) => { SoundSettings.Instance.BGMSetting(value); });
            EffectSlider.onValueChanged.AddListener((value) => { SoundSettings.Instance.EffectSetting(value); });
        }
    }
}
