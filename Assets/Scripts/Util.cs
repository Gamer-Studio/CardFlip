#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace CardFlip
{
  public class Util : MonoBehaviour
  {
    [MenuItem("Window/PlayerPrefs 초기화")]
    private static void ResetPrefs()
    {
      PlayerPrefs.DeleteAll();
      Debug.Log("PlayerPrefs has been reset.");
    }
  }
}

#endif