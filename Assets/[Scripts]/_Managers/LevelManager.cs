using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] ballsInLevel;

    [HideInInspector]
    public bool isPlatformDown = false;

    [Space]
    [Header("Materials & Sprites")]
    [SerializeField] Material deformablePlaneMaterial;
    [SerializeField] Material backPlaneMaterial;
    [SerializeField] Material platformMaterial;
    [SerializeField] Material frameMaterial;
    [SerializeField] SpriteRenderer backgroundSprite;

    [Space]
    [Header("Level Colors")]
    [SerializeField] Color deformablePlaneColor;
    [SerializeField] Color backPlaneColor;
    [SerializeField] Color platformColor;
    [SerializeField] Color frameColor;
    [SerializeField] Color backgroundColor;

    [Header("Ball Colors")]
    public Color[] ballColors;

    private int ballsInTruckBed = 0;
    private bool endSequenceCalled = false;

    private void Awake() {
        ballsInLevel = GameObject.FindGameObjectsWithTag("Ball");
    }

    private void Start() {
        UpdateLevelColors();
    }

    private void FixedUpdate() {
        if (isPlatformDown) {
            Invoke("HandleEndOfGame", 2f);
        }
    }

    public void SuccessSequence() {
        GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>().ShowEndGamePanel(true);
    }

    public void RestartLevel() {
        GameManager.instance.RestartLevel();
    }

    public void FailureSequence() {
        // Show Restart UI
    }

    public int GetBallCount() {
        return ballsInTruckBed;
    }

    public void IncreaseBallCount() {
        ballsInTruckBed++;
    }

    public void DecreaseBallCount() {
        ballsInTruckBed--;
    }

    public void HandleEndOfGame() {
        if (endSequenceCalled)
            return;

        if (ballsInTruckBed >= (ballsInLevel.Length / 3f)) {
            SuccessSequence();
            Debug.Log("Level Success");
        } else {
            FailureSequence();
            Debug.Log("Level Failed");
        }

        endSequenceCalled = true;
    }

    private void UpdateLevelColors() {
        deformablePlaneMaterial.color = deformablePlaneColor;
        backPlaneMaterial.color = backPlaneColor;
        platformMaterial.color = platformColor;
        frameMaterial.color = frameColor;
        backgroundSprite.color = backgroundColor;
    }

    private void OnValidate() {
        UpdateLevelColors();
    }
}