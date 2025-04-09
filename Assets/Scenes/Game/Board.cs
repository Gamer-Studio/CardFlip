using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
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
    private int cardOrder = 0;
    private float time = 30.0f;
    private int Pair; // Stage.cs의 pair 변수를 저장하기 위해 만듬
    private int RemainAttempt; // Stage.cs의 remainAttempt 변수를 저장하기 위해 만듬듬
    private void Awake()
    {
      if (Instance == null) Instance = this;
      GameManager.Instance.stageData.pair = Pair; // Stage.cs에서 pair 변수 가져옴
      GameManager.Instance.stageData.remainAttempt = RemainAttempt; // Stage.cs에서서 remainAttempt 변수 가져옴
    }

    private void Start()
    {
      StartGame();
    }

    private void Update()
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

    private void StartGame()
    {
      var size = 4;
      var list = new List<int>();

      for (int i = 0; i < Pair; i++)
      {
        list.Add(i);
        list.Add(i);
      }
      var arr = list.OrderBy(_ => Random.Range(0, 7)).ToArray();

      for (int x = 0; x < size; x++)
      {
        for (int y = 0; y < (size); y++) // y축 개수는 pair의의 반
        {
          SetCard(arr[x + y * size], new(x, y));
        }
      }

      cardCount = arr.Length;
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

    public Card SetCard(int id, Vector3Int position)
    {
      grid.SetTile(position, baseTile);
      var obj = grid.GetInstantiatedObject(position);
      obj.GetComponent<Card>().Id = id;
      obj.GetComponent<Card>().order = cardOrder;
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
  }
}