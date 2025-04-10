using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace CardFlip
{
  public class Init : MonoBehaviour
  {
    public bool loaded = false;
    [SerializeField]
    private TMP_Text introText;
    [SerializeField]
    private AssetLabelReference rtanRef;
    private void Start()
    {
      // 초기화 스크립트에서 어드레서블 에셋 로딩하기기
      var sprites = GameManager.Instance.sprites;
      Addressables.LoadAssetsAsync<Sprite>(rtanRef, sprite =>
      {
        sprites.Add(sprite.name, sprite);
      }).WaitForCompletion();

      // 게임 로딩을 완료했을 때 텍스트를 바꾸고 터치시 게임 진입 구현
      introText.GetComponent<Animator>().SetBool("Blinking", true);
      loaded = true;
      introText.text = "Touch To Start!";
    }

    public void LinkToHomepage()
    {
      Application.OpenURL("https://github.com/Gamer-Studio");
    }

    public void JoinMenu()
    {
      if (loaded) SceneManager.LoadScene("MenuScene");
    }
  }
}
