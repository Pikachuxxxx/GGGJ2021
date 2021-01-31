using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorController : MonoBehaviour
{
    public LiftTrigger liftTrigger;
    public Animator elevatorAC;

    public bool isInsideElevator;
    public bool areDoorsOpen;

    private void Update()
    {

        if (liftTrigger.didEnterElevator)
        {
            Debug.Log("Closing Doors");
            CloseElevatorDoors();
            isInsideElevator = true;
            liftTrigger.didEnterElevator = false;
        }

        if(liftTrigger.didExitElevator)
        {
            isInsideElevator = false;
        }
    }

    public void OpenElevatorDoors()
    {
        elevatorAC.SetTrigger("OpenDoors");
        areDoorsOpen = true;
    }

    public void CloseElevatorDoors()
    {
        elevatorAC.SetTrigger("CloseDoors");
        areDoorsOpen = false;
    }

    public void MoveLiftUp()
    {
        elevatorAC.SetTrigger("LiftUp");
    }

    public void MoveLiftDown()
    {
        elevatorAC.SetTrigger("LiftDown");
    }

}
