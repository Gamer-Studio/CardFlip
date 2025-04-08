using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class ContinueBtn : MonoBehaviour
    {
        GameManager gameManager = GameManager.Instance;
        //TODO
        //게임 매니저 스크립트에서 timescale 1, pausescene 닫기
        public void ReturnGame()
        {
            //gameManager.Time.timeScale = 1f;
            SceneManager.UnloadSceneAsync("PauseScene");
        }
    }
}
