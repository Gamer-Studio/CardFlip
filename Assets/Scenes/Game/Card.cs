using JetBrains.Annotations;
using UnityEngine;

namespace CardFlip
{
  public class Card : MonoBehaviour
  {
    public int Id
    {
      get => id;
      set
      {
        renderer.sprite = Board.Instance.sprites[$"rtan{value}"];
        id = value;
      }
    }
    public bool destroy = false;
    private int id = 0;
    [SerializeField]
    private new SpriteRenderer renderer;
    [SerializeField]
    private Animator animator;
  }
}
