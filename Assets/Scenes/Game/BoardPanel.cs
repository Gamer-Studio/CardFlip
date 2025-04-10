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
      remainAttemptResultText.text = remainAttempt.ToString();
      remainTimeResultText.text = time.ToString("N2");

      var current = GameManager.Instance.stageIndex;
      var best = PlayerPrefs.GetInt("bestStage", 1);
      if (current >= best) PlayerPrefs.SetInt("bestStage", current + 1);

      nextStageButton.SetActive(current >= GameManager.Instance.stageDataList.Count);
    }

    public void Retry()
    {
      SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void BackToHome()
    {
      SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }

    public void NextStage()
    {
      GameManager.Instance.stageIndex++;
      SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    // failPanel 구현
    [Header("Fail Panel"), SerializeField]
    private GameObject failPanel;

    private void Fail()
    {
      failPanel.SetActive(true);
    }
  }
}