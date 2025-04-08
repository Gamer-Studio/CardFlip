using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class SelectBtn : MonoBehaviour
    {
        public Animator anim;
        public GameObject MenuPanel;
        public GameObject stageSelectPanel;
        public void SelectActive()
        {
            MenuPanel.SetActive(false);
            stageSelectPanel.SetActive(true);
        }

        public void BacktoMenu()
        {
            stageSelectPanel.SetActive(false);
            MenuPanel.SetActive(true);
            anim.SetBool("isSelected", true);
        }
    }
}
