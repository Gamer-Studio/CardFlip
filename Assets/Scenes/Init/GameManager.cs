using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace CardFlip
{
  public class GameManager : MonoBehaviour
  {
    public static GameManager Instance { get; private set; }
    //   여기서는 스테이지 정보 전달받는 변수
    public Stage stageData = null;
    public Dictionary<string, Sprite> sprites = new();
    public new AudioManager audio;
    private void Awake()
    {
      if (Instance == null)
      {
        DontDestroyOnLoad(gameObject);  //씬 전환 시 싱글톤 유지
        Instance = this;
      }
      else Destroy(gameObject);
    }
  }
}