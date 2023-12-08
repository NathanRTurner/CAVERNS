using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject room1;
    public GameObject room2;
    public GameObject room3;
    public GameObject room4;
    public Vector3 desiredPos = new Vector3(0, 10, 0);
    public Vector3 desiredAng = new Vector3(45, 0, 0);
    private Vector3 currentAngle;
    // Start is called before the first frame update
    void Start()
    {
        currentAngle = transform.eulerAngles;
        int count = 0;
        Vector3 vector = new Vector3(0, 0, 0);
        int prevDir = 0;
        for (int i = 0; i < 50; i++)
        {
            int roomrando = (Random.Range(1, 5));
            GameObject prefab = room1;
            if (roomrando == 1)
            {
                prefab = room1;
            }
            else if (roomrando == 2)
            {
                prefab = room2;
            }
            else if (roomrando == 3)
            {
                prefab = room3;
            }
            else if (roomrando == 4)
            {
                prefab = room4;
            }
            count += 1;
            int rando = (Random.Range(-1, 2));
            if (prevDir == -1)
            {
                rando = (Random.Range(-1, 1));
            }
            else if (prevDir == 1)
            {
                rando = (Random.Range(0, 2));
            }
            int forward = 0;
            if (rando == 0)
            {
                forward = 16;
            }
            //Debug.Log(rando);
            if (count > 1)
            {
                vector += new Vector3(16 * rando, 0, forward);
            }
            GameObject temp = Instantiate(prefab,vector, Quaternion.identity);
            GameObject prev = temp;
            if (count > 1)
            {
                prev = GameObject.Find((count - 1).ToString());

                if (rando == -1)
                {
                    prev.transform.Find("LWALL").transform.Find("LD").gameObject.SetActive(false);
                }
                else if (rando == 0)
                {
                    prev.transform.Find("FWALL").transform.Find("FD").gameObject.SetActive(false);
                }
                else if (rando == 1)
                {
                    prev.transform.Find("RWALL").transform.Find("RD").gameObject.SetActive(false);
                }
            }
            vector = temp.transform.position;
            temp.name = count.ToString();
            prevDir = rando;
            if (count > 1)
            {
                if (prevDir == -1)
                {
                    temp.transform.Find("RWALL").transform.Find("RD").gameObject.SetActive(false);
                }
                else if (prevDir == 0)
                {
                    temp.transform.Find("BWALL").transform.Find("BD").gameObject.SetActive(false);
                }
                else if (prevDir == 1)
                {
                    temp.transform.Find("LWALL").transform.Find("LD").gameObject.SetActive(false);
                }
            }
        }
    }
    void Update()

    {
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, desiredAng.x, Time.deltaTime * 5),
            Mathf.LerpAngle(currentAngle.y, desiredAng.y, Time.deltaTime * 5),
            Mathf.LerpAngle(currentAngle.z, desiredAng.z, Time.deltaTime * 5));
        if ((this.transform.position != desiredPos) || (this.transform.eulerAngles != desiredAng))
        {
            this.transform.eulerAngles = currentAngle;//Vector3.Lerp(this.transform.eulerAngles, desiredAng, Time.deltaTime * 5);
            this.transform.position = Vector3.Lerp(this.transform.position, desiredPos, Time.deltaTime * 5);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            other.gameObject.SetActive(false);
            Debug.Log("W");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall")
        {
            other.gameObject.SetActive(true);
        }
    }
}
