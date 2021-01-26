using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TutorialPanel : MonoBehaviour
{
    [SerializeField] RectTransform hand;
    [SerializeField] RectTransform text;

    private Vector2 handStartPos;

    private Sequence handSequence;
    private Sequence textSequence;

    private void Start() {
        if (GameManager.instance.isTutorialPlayed) {
            gameObject.SetActive(false);
            return;
        }
        SetAnimations();
    }

    private void Update() {
        if (Input.GetMouseButton(0) || Input.touchCount > 0) {
            DeactivateOnTouch();
        }
    }

    public void DeactivateOnTouch() {
        if (handSequence != null) {
            handSequence.Kill();
        }
        if (textSequence != null) {
            textSequence.Kill();
        }
        GameManager.instance.isTutorialPlayed = true;
        gameObject.SetActive(false);
    }

    private void SetAnimations() {
        handStartPos = hand.anchoredPosition;

        if (handSequence != null) {
            handSequence.Kill();
        }
        if (textSequence != null) {
            textSequence.Kill();
        }

        handSequence = DOTween.Sequence();
        textSequence = DOTween.Sequence();

        handSequence.Append(hand.DOAnchorPos(new Vector2(handStartPos.x, handStartPos.y - 180f), 1f, false))
            .Append(hand.DOAnchorPos(new Vector2(handStartPos.x, handStartPos.y), 0.5f, false))
            .Join(hand.DOScale(1.2f, 0.5f))
            .Append(hand.DOScale(Vector3.one, 0.5f))
            .SetLoops(-1).SetEase(Ease.InSine);

        textSequence.Append(text.DOScaleX(0.9f, 0.3f))
            .Join(text.DOScaleY(1.3f, 0.3f))
            .Append(text.DOScaleX(1.2f, 0.1f))
            .Join(text.DOScaleY(0.8f, 0.1f))
            .Append(text.DOScaleX(1f, 0.1f))
            .Join(text.DOScaleY(1f, 0.1f))
            .Append(text.DOScaleX(1f, 2.5f))
            .SetLoops(-1);
    }
}
