using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseLook : MonoBehaviourPun
{

    public float mouseSceneitivity = 1000f;
    public Transform playerBody;
    float xRotation = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }
            Debug.Log("마우스 클릭");
            float mouseX = Input.GetAxis("Mouse X") * mouseSceneitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSceneitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        

           
        
        
    }
}
