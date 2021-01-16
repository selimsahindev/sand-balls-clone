using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] ballsInLevel;
    public bool isPlatformDown = false;

    private int ballsInTruckBed = 0;

    private void Awake() {
        ballsInLevel = GameObject.FindGameObjectsWithTag("Ball");
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