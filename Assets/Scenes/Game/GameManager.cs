using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance { get; private set; }
  public Card selectedCard = null;
  public int cardCount = 0;
  private float time = 0;
  [SerializeField]
  private GameObject endText;
  [SerializeField]
  private TextMeshProUGUI timeText;
  private new Camera camera;
  private void Awake()
  {
    if (Instance == null) Instance = this;

    camera = Camera.main;
  }

  private void Update()
  {
    if (time < 30)
    {
      time += Time.deltaTime;
      timeText.text = time.ToString("N2");
    }
    else
    {
      timeText.text = 30f.ToString("N2");
      GameOver();
    }
  }

  private void OnClick(InputValue value)
  {
    if (value.Get<float>() == 1)
    {
      var pos = camera.ScreenToWorldPoint(Input.mousePosition);
      var hits = Physics2D.RaycastAll(pos, Vector2.zero, 0f);

      foreach (var hit in hits)
      {
        if (hit.collider.TryGetComponent<Card>(out var card) && card != selectedCard && !card.destroy)
        {
          var anim = card.GetComponent<Animator>();
          anim.SetTrigger("Open");
          anim.SetBool("isOpen", true);

          // 카드 선택했을 때 동작
          if (selectedCard == null) selectedCard = card;
          else
          {
            if (selectedCard.Id == card.Id)
            {
              anim.SetBool("destroy", true);
              selectedCard.GetComponent<Animator>().SetBool("destroy", true);
              cardCount -= 2;
              // match
            }
            else
            {
              selectedCard.GetComponent<Animator>().SetBool("isOpen", false);
              anim.SetBool("isOpen", false);

            }
            selectedCard = null;
          }

          break;
        }
      }

      if (cardCount <= 0) GameOver();
    }
  }

  public void GameOver()
  {
    endText.SetActive(true);
    Time.timeScale = 0;

  }

  public void Retry()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("MainScene");
  }
}
