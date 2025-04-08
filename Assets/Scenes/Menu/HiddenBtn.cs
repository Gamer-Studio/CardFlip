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
        public float holdTime = 2f; // �� �� �̻� ������ ��������
        private float holdTimer = 0f;   //���� ���� �ð�
        private bool isHolding = false;     //���ȴ����� ���� �Ǵ�

        void Update()
        {
            if (isHolding)
            {
                holdTimer += Time.deltaTime;
                if (holdTimer >= holdTime)
                {
                    isHolding = false; // �� �̻� ������ �־ �߰� ���� �� �ǰ�
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
