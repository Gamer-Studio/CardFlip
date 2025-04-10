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
    private string bestStageName = "bestStage";
    private int bestStage;

    // MenuPanel 코드
    public void OpenSelectPanel()
    {
      MenuPanel.SetActive(false);
      stageSelectPanel.SetActive(true);
      // nameof로 키를 변수의 이름으로 사용하게 했어요.
      // 두번째 매개변수로 해당 값이 저장되어있지않을 때 가져올 값을 정의했어요.
      bestStage = PlayerPrefs.GetInt(bestStageName, 1);
      Debug.Log(bestStage);

      for (int i = 0; i < stageButtons.Count; ++i)
      {
        var btnObj = stageButtons[i];

        bool isCleared = (i + 1) < bestStage;
        btnObj.SetActive(true);

        var lockIcon = btnObj.transform.Find("LockIcon");
        if (lockIcon != null)
          lockIcon.gameObject.SetActive(!isCleared);

        var overlay = btnObj.transform.Find("DarkOverlay");
        if (overlay != null)
          overlay.gameObject.SetActive(!isCleared);

        // TryGetComponent를 통해 버튼 컴포넌트를 가져오고, 정상적으로 가져왔을 시 바로 실행하게 했어요.
        if (btnObj.TryGetComponent<Button>(out var btn))
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
    public void SelectStage(int index)
    {
      GameManager.Instance.stageIndex = index;
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
