using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CardFlip
{
    public class Try : MonoBehaviour
    {
        public Text TryTxt_F; // TryTxt_F를 변수로 불러옴옴

        public int trycount = 5; // 남은 시도 횟수: 5번(작동 되는지 확인용)

        void Start()
        {
            trycount -= 1; // 남은 시도 횟수-1
            TryTxt_F.text = trycount.ToString(); // 화면에 출력
        }
    }
}