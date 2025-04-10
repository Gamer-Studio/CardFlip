using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CardFlip
{
  public class MenuSystem : MonoBehaviour
  {
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private GameObject MenuPanel, stageSelectPanel;
    [SerializeField]
    private List<GameObject> stageButtons;

    private string key = "bestStage";
    private int bestStage;

    // MenuPanel 코드
    public void OpenSelectPanel()
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

        var btn = btnObj.GetComponent<Button>();
        if (btn != null)
          btn.interactable = isCleared;
      }
    }

    public void OpenSetting()
    {
      PanelManager.Instance.OpenSetting = true;
    }

    public void ExitGame()
    {
      Application.Quit();
    }


    // 여기서부터 StageSelectPanel 코드
    public void SelectStage(Stage stageData)
    {
      if (stageData == null)
      {
        return;
      }
      GameManager.Instance.stageData = stageData;
      SceneManager.LoadScene("GameScene");
    }

    public void BacktoMenu()
    {
      stageSelectPanel.SetActive(false);
      MenuPanel.SetActive(true);
      anim.SetBool("isSelected", true);
    }

    public void OpenMenuPanel()
    {
      stageSelectPanel.SetActive(false);
      MenuPanel.SetActive(true);
      anim.SetBool("isSelected", true);
    }
  }
}
