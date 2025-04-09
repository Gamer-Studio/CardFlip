using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace CardFlip
{
  public class Board : MonoBehaviour
  {
    public static Board Instance { get; private set; }
    public AssetReference rtanRef;
    public Dictionary<string, Sprite> sprites = new();
    public RuleTile baseTile;
    [SerializeField]
    private Tilemap grid;
    int cardOrder = 0;
    private void Awake()
    {
      if (Instance == null) Instance = this;

      var loadSprites = Addressables.LoadAssetsAsync<Sprite>("rtan", sprite =>
      {
        sprites.Add(sprite.name, sprite);
      }).WaitForCompletion();
    }

    private void Start()
    {
      StartGame();
    }

    private void StartGame()
    {
      var size = 4;
      var list = new List<int>();
      for (int i = 0; i < 8; i++)
      {
        list.Add(i);
        list.Add(i);
      }
      var arr = list.OrderBy(_ => Random.Range(0, 7)).ToArray();

      for (int x = 0; x < size; x++)
      {
        for (int y = 0; y < size; y++)
        {
          SetCard(arr[x + y * size], new(x, y));
        }
      }

      GameManager.Instance.cardCount = arr.Length;
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