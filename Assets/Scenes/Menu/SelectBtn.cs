using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class SelectBtn : MonoBehaviour
    {
        public Animator anim;
        public GameObject MenuPanel;
        public GameObject stageSelectPanel;

        public List<GameObject> stageButtons;

        string key = "bestStage";
        int bestStage;
        public void SelectActive()
        {
            MenuPanel.SetActive(false); 
            stageSelectPanel.SetActive(true);

            if (!PlayerPrefs.HasKey(key))
            {
                PlayerPrefs.SetInt(key, 1);
            }
            bestStage = PlayerPrefs.GetInt(key);

            for (int i = 0; i < stageButtons.Count; ++i)
            {
                GameObject btnObj = stageButtons[i];

                bool isCleared = (i + 2) <= bestStage;
                btnObj.SetActive(true);

                Transform lockIcon = btnObj.transform.Find("LockIcon");
                if (lockIcon != null)
                    lockIcon.gameObject.SetActive(!isCleared);

                Transform overlay = btnObj.transform.Find("DarkOverlay");
                if (overlay != null)
                    overlay.gameObject.SetActive(!isCleared);

                Button btn = btnObj.GetComponent<Button>();
                if (btn != null)
                    btn.interactable = isCleared;
            }
        }

        public void BacktoMenu()
        {
            stageSelectPanel.SetActive(false);
            MenuPanel.SetActive(true);
            anim.SetBool("isSelected", true);
        }
    }
}
