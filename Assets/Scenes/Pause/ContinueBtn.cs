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
        //���� �Ŵ��� ��ũ��Ʈ���� timescale 1, pausescene �ݱ�
        public void ReturnGame()
        {
            //gameManager.Time.timeScale = 1f;
            SceneManager.UnloadSceneAsync("PauseScene");
        }
    }
}
