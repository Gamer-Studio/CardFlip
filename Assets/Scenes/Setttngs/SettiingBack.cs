using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace CardFlip
{
    public class SettiingBack : MonoBehaviour
    {
        public void Back()
        {   
            SceneManager.UnloadSceneAsync("SettingScene");
        }
    }
}
