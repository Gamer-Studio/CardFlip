using System.Collections.Generic;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace CardFlip
{
  public partial class Board : MonoBehaviour
  {
    public static Board Instance { get; private set; }
    public RuleTile baseTile;
    public Card selectedCard = null;
    public int cardCount = 0;
    [SerializeField]
    private new Camera camera;
    [SerializeField]
    private Tilemap grid;
    [SerializeField]
    private GameObject endText;
    [SerializeField]
    private TextMeshProUGUI timeText;
    // 남은기회 txt
    [SerializeField]
    private TextMeshProUGUI countText;

    private int cardOrder = 0;
    private float timeWait = 0.07f;
    // 남은 시간간
    private float time = 30.0f;
    // 남은 시도횟수
    private int remainAttempt;

    private bool isStarted = false;

    private void Awake()
    {
      if (Instance == null) Instance = this;
      timeText.text = time.ToString("N2");
      remainAttempt = GameManager.Instance.stageData.remainAttempt;
    }

    private void Start()
    {
      StartGame();
      StartCoroutine(CardSettingComplete());
    }

    private void Update()
    {
      if (isStarted)
      {
        if (time > 0) // 0초가 아닐 때
        {
          time -= Time.deltaTime; // 시간 감소
          timeText.text = time.ToString("N2");
        }
        else
        {
          timeText.text = 0f.ToString("N2"); // 끝나면 화면에 0초로 표시
          GameOver();
        }
      }
    }

    private void StartGame()
    {
      var stageData = GameManager.Instance.stageData;

      var sizeX = 4;
      var sizeY = stageData.pair / 2;
      var list = new List<int>();

      for (int i = 0; i < stageData.pair; i++)
      {
        list.Add(i);
        list.Add(i);
      }
      var arr = list.OrderBy(_ => Random.Range(0, 7)).ToArray();
      int index = 0;
      for (int y = 0; y < sizeY; y++)
      {
        for (int x = 0; x < sizeX; x++)
        {
          if (index >= arr.Length) break;

          SetCard(arr[index], new Vector3Int(x, y));
          index++;
        }
      }
      cardCount = arr.Length;
      countText.text = remainAttempt.ToString(); // 화면에 출력
    }

    public void GameOver()
    {
      endText.SetActive(true);
      Time.timeScale = 0;
    }

    public Card SetCard(int id, Vector3Int position)
    {
      grid.SetTile(position, baseTile);
      var obj = grid.GetInstantiatedObject(position);
      obj.GetComponent<Card>().Id = id;
      obj.GetComponent<Card>().order = cardOrder;
      obj.GetComponent<Card>().timeWait = timeWait; // 카드 배치 시간
      cardOrder++;

      return obj.GetComponent<Card>();
    }

    public bool TryGetCard(Vector3Int position, out Card card)
    {
      if (grid.GetInstantiatedObject(position).TryGetComponent(out card)) return true;
      else
      {
        card = null;
        return false;
      }
    }

    private IEnumerator CardSettingComplete()
    {
      //yield return new WaitForSeconds(timeWait * cardOrder);
      yield return new WaitForSeconds(timeWait * GameManager.Instance.stageData.pair * 2);
      isStarted = true;
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
                //여기서 match.mp3 재생
                anim.SetBool("destroy", true);
                selectedCard.GetComponent<Animator>().SetBool("destroy", true);
                cardCount -= 2;
              }
              else
              {
                //여기서 unmatch 사운드 재생
                selectedCard.GetComponent<Animator>().SetBool("isOpen", false);
                anim.SetBool("isOpen", false);
                countText.text = (--remainAttempt).ToString();

              }
              selectedCard = null;
            }

            break;
          }
        }

        if (cardCount <= 0) GameOver();
      }
    }
  }
}