using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsPanel : MonoBehaviour
{
    public RectTransform settingsIcon;
    public RectTransform settingsButton;
    public RectTransform soundButton;
    public RectTransform vibrationButton;

    public Image soundImage;
    public Image vibrationImage;

    public SettingsSprite soundSprites;
    public SettingsSprite vibrationSprites;

    private Vector2 soundStartPos;
    private Vector2 vibrationStartPos;

    private bool isOpen;

    [System.Serializable]
    public struct SettingsSprite {
        public Sprite on;
        public Sprite off;
    }

    private void Start()
    {
        soundStartPos = soundButton.anchoredPosition;
        vibrationStartPos = vibrationButton.anchoredPosition;

        soundButton.localScale = Vector3.zero;
        vibrationButton.localScale = Vector3.zero;

        soundButton.anchoredPosition = settingsButton.anchoredPosition;
        vibrationButton.anchoredPosition = settingsButton.anchoredPosition;

        soundImage.sprite = DataManager.instance.sound ? soundSprites.on : soundSprites.off;
        vibrationImage.sprite = DataManager.instance.vibration ? vibrationSprites.on : vibrationSprites.off;
    }

    public void OnPressSettingsButton()
    {
        if (!isOpen) {
            AppearSettings();
        } else {
            DisappearSettings();
        }
        isOpen = !isOpen;
    }

    public void OnPressSoundButton()
    {
        DataManager.instance.SetSound(!DataManager.instance.sound);
        soundImage.sprite = DataManager.instance.sound ? soundSprites.on : soundSprites.off;
        //SoundManager.instance.AllSound(DataManager.instance.sound);
    }

    public void OnPressVibrationButton()
    {
        DataManager.instance.SetVibration(!DataManager.instance.vibration);
        vibrationImage.sprite = DataManager.instance.vibration ? vibrationSprites.on : vibrationSprites.off;
    }

    public void AppearSettings(float duration = 0.25f)
    {
        settingsIcon.DORotate(new Vector3(0, 0, -360), duration, RotateMode.FastBeyond360);

        soundButton.DOAnchorPos(soundStartPos, duration);
        vibrationButton.DOAnchorPos(vibrationStartPos, duration);

        soundButton.DOScale(1f, duration);
        vibrationButton.DOScale(1f, duration);
    }

    public void DisappearSettings(float duration = 0.25f)
    {
        settingsIcon.DORotate(new Vector3(0, 0, 360), duration, RotateMode.FastBeyond360);

        soundButton.DOAnchorPos(settingsButton.anchoredPosition, duration);
        vibrationButton.DOAnchorPos(settingsButton.anchoredPosition, duration);

        soundButton.DOScale(0f, duration);
        vibrationButton.DOScale(0f, duration);
    }
}
