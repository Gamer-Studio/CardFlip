using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardFlip
{
  public class MenuSystem : MonoBehaviour
  {
    public void SelectStage()
    {

    }

    public void OpenSetting()
    {
      PanelManager.Instance.OpenSetting = true;
    }

    public void ExitGame()
    {
      Application.Quit();
    }
  }
}
