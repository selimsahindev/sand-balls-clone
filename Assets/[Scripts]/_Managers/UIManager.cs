using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject endGamePanel = null;

    private void Start() {
        endGamePanel = GameObject.FindGameObjectWithTag("EndGamePanel");
        ShowEndGamePanel(false);
    }

    public void ShowEndGamePanel(bool isActive) {
        endGamePanel.SetActive(isActive);
    }

}
