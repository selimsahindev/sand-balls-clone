using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TruckController : MonoBehaviour
{
    private Sequence idleSequence;
    private Sequence moveSequence;

    private void Start() {
        SetAnimations();
    }

    public void Move() {
        moveSequence.Play();
    }

    private void SetAnimations() {
        if (idleSequence != null) {
            idleSequence.Kill();
        }

        idleSequence = DOTween.Sequence();
        moveSequence = DOTween.Sequence();

        // Idle Animation
        idleSequence.Append(transform.DOScaleY(1.02f, 0.3f))
            .Join(transform.DOScaleY(0.98f, 0.3f))
            .SetLoops(-1);

        // Move Animation (Considering the size of parent object)
        moveSequence.Append(transform.DOMoveX(25f, 3f));
        moveSequence.Pause();
    }
}
