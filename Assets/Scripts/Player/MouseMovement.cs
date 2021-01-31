using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouseSens= 100f;
    public Transform player;
    float Xrotate = 0f;
    void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float Xaxis = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime; 
        float Yaxis = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;
        Xrotate = Xrotate-Yaxis;
        Xrotate=Mathf.Clamp(Xrotate,-90f,90f);
        transform.localRotation = Quaternion.Euler(Xrotate,0f,0f);
        player.Rotate(Vector3.up * Xaxis);
    }
}
