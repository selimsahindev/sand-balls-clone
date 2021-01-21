using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public TruckController truck;
    public GameObject[] ballsInLevel;
    public bool isPlatformDown = false;

    private int ballsInTruckBed = 0;
    private bool endSequenceCalled = false;

    private void Awake() {
        ballsInLevel = GameObject.FindGameObjectsWithTag("Ball");
    }

    private void FixedUpdate() {
        if (!endSequenceCalled && isPlatformDown) {
            Invoke("StartEndingSequence", 2f);
            endSequenceCalled = true;
        }
    }

    public void StartEndingSequence() {
        truck.Move();
        GameManager.instance.NextLevel();
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
}