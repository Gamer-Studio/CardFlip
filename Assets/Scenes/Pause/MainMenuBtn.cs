using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class MainMenuBtn : MonoBehaviour
    {
        public void MainMenu()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
