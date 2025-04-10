using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
  public partial class Board
  {
    // successPanel 구현
    [Header("Success Panel"), SerializeField]
    private GameObject successPanel;
    [SerializeField]
    private TextMeshProUGUI remainAttemptResultText, remainTimeResultText;
    [SerializeField]
    private GameObject nextStageButton;

    private void Success()
    {
      successPanel.SetActive(true);
      remainAttemptResultText.text = remainAttempt.ToString();
      remainTimeResultText.text = time.ToString("N2");

      var current = GameManager.Instance.stageIndex + 1;
      // var best = PlayerPrefs.GetInt("bestStage", 1);
      PlayerPrefs.SetInt("bestStage", current + 1);

      nextStageButton.SetActive(current <= GameManager.Instance.stageDataList.Count);
    }

    public void Retry()
    {
      SceneManager.LoadSceneAsync("GameScene");
    }

    public void NextStage()
    {
      GameManager.Instance.stageIndex++;
      SceneManager.LoadSceneAsync("GameScene");
    }

    // failPanel 구현
    [Header("Fail Panel"), SerializeField]
    private GameObject failPanel;

    private void Fail()
    {
      finish = true;
      failPanel.SetActive(true);
    }

    public void BackToMenu()
    {
      SceneManager.LoadSceneAsync("MenuScene");
    }
  }
}