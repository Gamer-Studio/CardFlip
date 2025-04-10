using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;

namespace CardFlip
{
    public class HiddenBtn : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public float holdTime = 2f; // 몇 초 이상 눌러야 반응할지
        private float holdTimer = 0f;   //현재 눌린 시간
        private bool isHolding = false;     //눌렸는지에 대한 판단

        void Update()
        {
            if (isHolding)
            {
                holdTimer += Time.deltaTime;
                if (holdTimer >= holdTime)
                {
                    isHolding = false; // 더 이상 누르고 있어도 추가 실행 안 되게
                    EnterHiddenStage();
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            isHolding = true;
            holdTimer = 0f;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            isHolding = false;
            holdTimer = 0f;
        }

        void EnterHiddenStage()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
