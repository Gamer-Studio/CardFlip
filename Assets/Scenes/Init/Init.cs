using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CardFlip
{
    public class Init : MonoBehaviour
    {
        public bool loaded = false;
        [SerializeField]
        private TMP_Text introText;
        private void Awake()
        {
            // 여기에 설정, 일시정지 다이얼로그 DDOL로 인스턴스되게끔 구현
            // 인스턴스완료했을 때 텍스트를 바꾸고 터치시 게임 진입 구현
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
