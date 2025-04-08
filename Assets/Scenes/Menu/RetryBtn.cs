using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class RetryBtn : MonoBehaviour
    {
        public void Retry() // 재시작 
        {
            SceneManager.LoadScene("GameScene"); // GameScene을 불러옴
        }
    }
}