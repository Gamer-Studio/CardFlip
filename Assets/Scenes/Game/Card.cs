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
            float elapsed = 0f;
            float delay = order * 0.2f;
            yield return new WaitForSeconds(delay);

            while (elapsed < 0.3f)
            {
                transform.position = Vector3.Lerp(Vector3.zero, pos, elapsed / 0.3f);
                elapsed += Time.deltaTime;
                yield return null;
            }

            transform.position = pos;
        }
    }
}
