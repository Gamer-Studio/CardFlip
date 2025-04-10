using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CardFlip
{
  public partial class Board
  {
    // successPanel 구현
    [Header("Success Panel"), SerializeField]
    private GameObject successPanel;
    [SerializeField]
    private TextMeshProUGUI remainAttemptResultText, remainTimeResultText;

    private void Success()
    {
      remainAttemptResultText.text = time.ToString("N2");
    }

    // failPanel 구현
    [Header("Fail Panel"), SerializeField]
    private GameObject failPanel;
  }
}