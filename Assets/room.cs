using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room : MonoBehaviour
{
    public GameObject cam;
    public bool doIt = false;
    private Vector3 desiredPos = new Vector3(0, 10, 0);
    private Vector3 desiredAng = new Vector3(45, 0, 0);
    Spawner spawner = null;
    private void Start()
    {
        cam = GameObject.Find("Main Camera");
        spawner = cam.GetComponent<Spawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        cam = GameObject.Find("Main Camera");
        if (other.tag == "Player")
        {
            if (spawner == null)
            {
                cam = GameObject.Find("Main Camera");
                spawner = cam.GetComponent<Spawner>();
            }

            if (other.transform.forward.z > 0.5f)
            {
                spawner.desiredPos = transform.position + new Vector3(0, 10, -10);
                spawner.desiredAng = new Vector3(45, 0, 0);
                //this.transform.Find("BWALL").gameObject.SetActive(false);
                //cam.transform.eulerAngles = new Vector3(45, 0, 0);
                //cam.transform.position = transform.position + new Vector3(0, 10, -10);
                //cam.transform.position = Vector3.Lerp(cam.transform.position, transform.position + new Vector3(0, 10, -10), Time.deltaTime * 5);

            }
            else if (other.transform.forward.x < -0.5f)
            {
                //this.transform.Find("RWALL").gameObject.SetActive(false);
                spawner.desiredAng = new Vector3(45, 270, 0);
                spawner.desiredPos = transform.position + new Vector3(10, 10, 0);
            }
            else if (other.transform.forward.x > 0.5f)
            {
                //this.transform.Find("LWALL").gameObject.SetActive(false);
                spawner.desiredAng = new Vector3(45, 90, 0);
                spawner.desiredPos = transform.position + new Vector3(-10, 10, 0);
            }
            else if (other.transform.forward.z < -0.5f)
            {
                //this.transform.Find("FWALL").gameObject.SetActive(false);
                spawner.desiredAng = new Vector3(45, 180, 0);
                spawner.desiredPos = transform.position + new Vector3(0, 10, 10);
            }
            Debug.Log(desiredPos);

        }
    }
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Player")
    //    {
    //        this.transform.Find("FWALL").gameObject.SetActive(true);
    //        this.transform.Find("LWALL").gameObject.SetActive(true);
    //        this.transform.Find("RWALL").gameObject.SetActive(true);
    //        this.transform.Find("BWALL").gameObject.SetActive(true);
    //        if (other.transform.forward.z > 0.1f)
    //        {
    //            this.transform.Find("FWALL").gameObject.SetActive(false);
    //        }
    //        else if (other.transform.forward.x < -0.1f)
    //        {
    //            this.transform.Find("LWALL").gameObject.SetActive(false);
    //        }
    //        else if (other.transform.forward.x > 0.1f)
    //        {
    //            this.transform.Find("RWALL").gameObject.SetActive(false);
    //        }
    //        else if (other.transform.forward.z < -0.1f)
    //        {
    //            this.transform.Find("BWALL").gameObject.SetActive(false);
    //        }
    //    }
    //}
}
