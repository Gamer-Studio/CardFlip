using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CardFlip
{
    public class Card : MonoBehaviour
    {
        public int idx = 0; // idx는 index를 줄인말

        public GameObject front; // OpenCard 로직에 필요한 GameObject
        public GameObject back; // 꺼줘야 하는 GameObject 변수

        public Animator anim; // 

        public SpriteRenderer frontImage; // card 에 Front 변수에다가 이미지를 넣어주기 위해 생성

        public void Setting(int number) // 외부에서 Setting이라는 함수를 호출할 때 어떤 값을 넣어줄 수 있게 됨
        {
            idx = number; // idx에 number 저장
            frontImage.sprite = Resources.Load<Sprite>($"image{idx}"); // 앞면 이미지를 Resources의 image(개인 이미지)로 불러온다.
        }

        public void OpenCard()
        {
            anim.SetBool("isOpen", true);
            front.SetActive(true); // Animations 폴더의 Card Animator의 Parmeters에서 설정했던 카드를 맞췄을 때 뒤집는다는 설정
            back.SetActive(false); // 틀리면 카드를 뒤집지 않는다.

            if (GameManager.Instance.firstCard == null) // firstCard가 비었다면,
            {
                GameManager.Instance.firstCard = this; // firstCard에 내 정보를 넘겨준다. / Card 클래스에 있기 때문에 나 자신을 넘겨줌
            }
            else
            {
                GameManager.Instance.secondCard = this; // secondCard에 내 정보를 넘겨준다.
                GameManager.Instance.Matched();  // Matched 함수를 호출해 준다.
            }
        }

        public void DestroyCard()
        {
            Invoke("DestroyCardInvoke", 1.0f); // 1초 뒤에 DestroyCardInvoke 실행 (카드 파괴) / 카드가 일치하는지 확인하기 위함
        }

        void DestroyCardInvoke()
        {
            Destroy(gameObject); // 게임 오브젝트(card) 파괴
        }

        public void CloseCard() // 카드 덮기
        {
            Invoke("CloseCardInvoke", 1.0f); // 1초 뒤에 CloseCardInvoke 실행 (카드 다시 뒤집기) / 카드가 일치하는지 확인하기 위함
        }

        void CloseCardInvoke()
        {
            anim.SetBool("isOpen", false); // isOpen가 false일 때 Idle로 이동 -> transition 세팅한 값
            front.SetActive(false); // front를 다시 끔
            back.SetActive(true); // back을 다시 켬 -> 다시 카드를 뒤집음
        }
    }
}
