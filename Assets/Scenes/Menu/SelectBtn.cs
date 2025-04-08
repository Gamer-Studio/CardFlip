using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class SelectBtn : MonoBehaviour
    {
        public void Select()
        {
            SceneManager.LoadScene("StageSelectScene");
        }
    }
}
