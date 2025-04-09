using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
  public class PausePanel : MonoBehaviour
  {
    public void Continue()
    {
      PanelManager.Instance.OpenPause = false;
    }

    public void OpenSetting()
    {
      PanelManager.Instance.OpenSetting = true;
    }

    public void GotoMenu()
    {
      SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
  }
}
