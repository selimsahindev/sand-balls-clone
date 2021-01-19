using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    public CanvasGroup group {
        get {
            return GetComponent<CanvasGroup>();
        }
    }

    public void Active(bool isActive) {
        group.alpha = isActive ? 1 : 0;
        gameObject.SetActive(isActive);
    }

    public void ActiveSmooth(bool isActive, float duration = 0.5f) {
        group.DOKill();

        if (isActive) {
            gameObject.SetActive(true);
            SetInteractive(true);
            group.DOFade(1f, duration);
        } else {
            SetInteractive(false);
            group.DOFade(0f, duration).OnComplete(() => gameObject.SetActive(false));
        }
    }

    public void SmoothFade(float end, float duration = 0.5f) {
        group.DOKill();
        group.DOFade(end, duration);
    }

    public void SetInteractive(bool status) {
        group.interactable = status;
        group.blocksRaycasts = status;
    }
}
