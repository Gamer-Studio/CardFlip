using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; // Linq라는 시스템을 사용한다

public class Board : MonoBehaviour
{
    public GameObject card; // Prefabs에서 card를 가져옴

    void Start()
    {
        int[] arr = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 }; // 카드 맞출 숫자 생성
        arr = arr.OrderBy(x => Random.Range(0f, 7f)).ToArray(); // arr 배열값을 랜덤으로 섞어서 arr에 다시 정렬한다.

        for (int i = 0; i < 16; i++) // i가 16보다 작으면 계속 반복 -> 카드가 16개가 생성
        {
            GameObject go = Instantiate(card, this.transform); // card 게임 오브젝트의 복제본(Clone)을 Board 밑에 생성 / 게임 오브젝트라는 자료형 변수로 저장

            float x = (i % 4) * 1.4f - 2.1f; // 카드 위치의 x축 / 1.4를 곱하는 이유는 카드의 간격, 2.1을 빼는 이유는 화면 중앙에 배치하기 위함
            float y = (i / 4) * 1.4f - 3.0f; // 카드 위치의 y축 

            go.transform.position = new Vector2(x, y); // 카드 생성 위치
            go.GetComponent<Card>().Setting(arr[i]); // GetComponent는 어떤 컴포넌트, 스크립트를 가져오기위해 사용하는 키워드 - > card스크립트를 가져온다.
                                                     // card 스크립트의 Setting 함수를 불러와 arr[i] 값을 Setting 함수의 매개변수인 int number 를 통해 넘어와 idx에 넣어줌
        }

        GameManager.Instance.cardCount = arr.Length; // 배열 개수(16개)만큼 cardCount 에 넣어준다.
    }
}
