using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public void Continue() {
        GameObject.FindGameObjectWithTag("Truck").GetComponent<TruckController>().Move();
        GameManager.instance.NextLevel();
    }
}
