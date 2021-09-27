using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviourPun
{
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    Camera cam;
    private void Start()
    {
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
            cam = GetComponentInChildren<Camera>();
            cam.tag = "MainCamera";
            gameObject.layer = LayerMask.NameToLayer("Player");
            gameObject.name = "Player";
            AudioListener.volume = 1;
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Enemy");
            cam = GetComponentInChildren<Camera>();
            cam.enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
            gameObject.name = "Enemy";

        }
    }


    void Update()
    {
        if (photonView.IsMine == false)
        {
            return;
        }
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * y;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButton("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        
        
    }
}
