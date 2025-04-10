using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace CardFlip
{
  public enum PanelType
  {
    Setting = 1,
    Pause = 2
  }
  public class PanelManager : MonoBehaviour
  {
    public static PanelManager Instance { get; private set; } = null;
    public UnityEvent<PanelType, bool> OnOpen;
    [SerializeField]
    private GameObject pausePanel, settingPanel;
    public bool OpenPause
    {
      get => pausePanel.activeSelf;
      set
      {
        pausePanel.SetActive(value);
        OnOpen.Invoke(PanelType.Pause, value);
      }
    }
    public bool OpenSetting
    {
      get => settingPanel.activeSelf;
      set
      {
        settingPanel.SetActive(value);
        OnOpen.Invoke(PanelType.Setting, value);
      }
    }

    private void Awake()
    {
      if (Instance == null) Instance = this;
      DontDestroyOnLoad(gameObject);

      var canvas = GetComponent<Canvas>();

      SceneManager.sceneLoaded += (_, _) =>
      {
        canvas.worldCamera = Camera.main;
      };
    }
  }
}
