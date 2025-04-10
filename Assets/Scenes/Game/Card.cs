using JetBrains.Annotations;
using UnityEngine;
using System.Collections;


namespace CardFlip
{
    public class Card : MonoBehaviour
    {
        public int Id
        {
            get => id;
            set
            {
                renderer.sprite = GameManager.Instance.sprites[$"rtan{value}"];
                id = value;
            }
        }
        public bool destroy = false;
        private int id = 0;
        [SerializeField]
        private new SpriteRenderer renderer;
        [SerializeField]
        private Animator animator;

        public int order = 0;
        private Vector3 pos;
        void Start()
        {
            pos = transform.position;
            transform.position = Vector3.zero;
            StartCoroutine(MoveToTarget());
        }

        IEnumerator MoveToTarget()
        {
            float timeWait = 0.07f;  //유지 보수 측면을 위한 timeWait 변수 추가가

            float elapsed = 0f;
            float delay = order * timeWait;
            yield return new WaitForSeconds(delay);

            while (elapsed <= timeWait)
            {
                transform.position = Vector3.Lerp(Vector3.zero, pos, elapsed / timeWait);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = pos;
            GetComponent<BoxCollider2D>().enabled = true; //카드 prefab의 boxcollider2d를 비활성화 한 후 배치가 끝나면 활성화

        }
    }
}
