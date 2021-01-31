using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTrigger : MonoBehaviour
{
    public bool didEnterElevator;
    public bool didExitElevator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            didEnterElevator = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            didExitElevator = true;
    }
}
