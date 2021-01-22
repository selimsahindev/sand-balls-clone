using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadePanel : MonoBehaviour
{
    Image image;
    
    void Start()
    {
        image = GetComponent<Image>();
        FadeOut();
    }

    public void FadeOut()
    {
        image.DOFade(0f, 0.6f).From(1f);
    }
}
