using UnityEngine;
using UnityEngine.InputSystem;

namespace CardFlip
{
  public partial class Board
  {
    AudioSource audioSource;

    public AudioClip matchClip;
    public AudioClip unmatchClip;

        private void OnClick(InputValue value)
    {
      if (value.Get<float>() == 1)
      {
        var pos = camera.ScreenToWorldPoint(Input.mousePosition);
        var hits = Physics2D.RaycastAll(pos, Vector2.zero, 0f);

        foreach (var hit in hits)
        {
          if (hit.collider.TryGetComponent<Card>(out var card) && card != selectedCard && !card.destroy)
          {
            var anim = card.GetComponent<Animator>();
            anim.SetTrigger("Open");
            anim.SetBool("isOpen", true);

            // 카드 선택했을 때 동작
            if (selectedCard == null) selectedCard = card;
            else
            {
              if (selectedCard.Id == card.Id)
              {
                audioSource.PlayOneShot(matchClip);
                anim.SetBool("destroy", true);
                selectedCard.GetComponent<Animator>().SetBool("destroy", true);
                cardCount -= 2;
                // match
              }
              else
              {
                audioSource.PlayOneShot(unmatchClip);
                selectedCard.GetComponent<Animator>().SetBool("isOpen", false);
                anim.SetBool("isOpen", false);

              }
              selectedCard = null;
            }

            break;
          }
        }

        if (cardCount <= 0) GameOver();
      }
    }
  }
}