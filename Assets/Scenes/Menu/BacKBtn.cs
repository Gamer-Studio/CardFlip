using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class BacKBtn : MonoBehaviour
    {
        public void Back ()
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
}
