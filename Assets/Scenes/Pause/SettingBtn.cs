using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class SettingBtn : MonoBehaviour
    {
        public void Setting()
        {
            SceneManager.LoadScene("SettingScene");
        }
    }
}
