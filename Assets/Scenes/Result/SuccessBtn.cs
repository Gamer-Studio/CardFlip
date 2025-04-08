using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class SuccessBtn : MonoBehaviour
    {
        public void Retry()
        {
            SceneManager.LoadScene("GameScene");
        }
        public void BacktoMainMenu()
        {
            SceneManager.LoadScene("MenuScene");
        }
        public void NextStage()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
