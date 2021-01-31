using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[ExecuteInEditMode]
public class Interact : MonoBehaviour
{
    [Header("Intractable Objects")]
    public ElevatorController   elevatorController;
    public RatGenerator         ratGenerator;

    public TextMeshProUGUI      interactableInstruction;
    public TextMeshProUGUI      interactableStatus;
    public Camera               mainCamera;

    public  float               rayDistance = 1.0f;

    private PlayerCollisions    m_PlayerColls;
    private RaycastHit          m_HitInfo;

    private bool didOpenTraumanaDoor;
    
    void Start()
    {
        
    }

    void Update()
    {
        interactableInstruction.text = "";
        interactableStatus.text = "";

        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out m_HitInfo, rayDistance))
        {
            Debug.Log("Hit : " + m_HitInfo.collider.name);
            Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * rayDistance, Color.white);

            if(m_HitInfo.collider.tag == "Door")
            {
                interactableInstruction.text = "Press 'E' to open the door";
                interactableStatus.text = "Door is locked!";
            }

            if(m_HitInfo.collider.tag == "TraumaDoor" && !didOpenTraumanaDoor)
            {
                interactableInstruction.text = "Press 'E' to open the door";

                //Open the door 
                m_HitInfo.collider.gameObject.GetComponentInParent<Animator>().SetTrigger("DoorOpen");
                didOpenTraumanaDoor = true;
            }

            if(elevatorController != null)
            {
	            if(m_HitInfo.collider.tag == "LiftButtons")
	            {
	                interactableInstruction.text = "Press 'E' to open/move the Elevator";
	
	                if (Input.GetKeyDown(KeyCode.E) && !elevatorController.areDoorsOpen && !elevatorController.isInsideElevator)
	                {
	                    elevatorController.OpenElevatorDoors();
	                }
	
	                if (Input.GetKeyDown(KeyCode.E) && elevatorController.isInsideElevator)
	                {
	                    elevatorController.MoveLiftUp();
	                }
	            }
            }

            if (ratGenerator != null)
            {
                if (m_HitInfo.collider.tag == "Ratmageddon")
                {
                    ratGenerator.generateRatsHerd = true;
                }
            }
        }
    }
}
