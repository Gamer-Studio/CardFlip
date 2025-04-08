using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class SettingButn : MonoBehaviour
    {
        public void Setting()
        {
            SceneManager.LoadScene("SettingScene",LoadSceneMode.Additive);
        }
    }
}
