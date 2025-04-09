using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class StageSelectBtn : MonoBehaviour
    {
        public Stage stageData;
        public void StageSelect()
        {
            if (stageData == null)
            {
                return;
            }
            GameManager.Instance.stageData = stageData;
            SceneManager.LoadScene("GameScene");
        }
    }
}
