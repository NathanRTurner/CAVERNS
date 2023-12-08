using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    private CharacterController controller;
    private GameObject cam;
    private Vector3 relative;
    private Vector3 playerVelocity;
    public float playerSpeed = 2.0f;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        cam = GameObject.Find("Main Camera");
    }

    void Update()
    {
        Vector3 move = Vector3.Scale(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")), relative);
        if (cam.transform.forward.x > 0.1f)
        {
            relative = new Vector3(1, 0, 1);
            move = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        }
        else if (cam.transform.forward.x < -0.1f)
        {
            relative = new Vector3(-1, 0, 1);
            move = new Vector3(-Input.GetAxis("Vertical"), 0,Input.GetAxis("Horizontal"));
        }
        if (cam.transform.forward.z > 0.1f)
        {
            relative = new Vector3(1, 0, 1);
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
        else if (cam.transform.forward.z < -0.1f)
        {

            relative = new Vector3(-1, 0, -1);
            move = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        }
        //Vector3 move = Vector3.Scale(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")),relative);
        //move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            //Debug.Log(cam.transform.forward);
        }
        
        controller.Move(playerVelocity * Time.deltaTime);
    }
}