using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IncreaseLife : MonoBehaviour
{

    private bool entered = false;
    public int plusHealth = 1;
    public bool destroyLife = true;


    private GameObject HealthManager;
    private BoxCollider boxCol;
    private void Start()
    {
        HealthManager = GameObject.Find("HealthManager");
    }
    void OnTriggerEnter(Collider col)
    {

        if (!entered && (col.tag == "Player"))
        {

            entered = true;

            if (HealthManagerScript.lives < 10)
            {

                HealthManager.GetComponent<HealthManagerScript>().DecreaseLife(plusHealth);
                
                if (destroyLife)
                {
                    Destroy(gameObject);
                }
                StartCoroutine(Do());
            }
        }
    }

    void OnTriggerExit(Collider col)
    {

        entered = false;

    }
    

    IEnumerator Do()
    {
        boxCol = this.GetComponent<BoxCollider>();
        boxCol.center = new Vector3(0, -5, 0); 
        yield return new WaitForSeconds(1);
        boxCol.center = new Vector3(0, 0, 0);
        Debug.Log("OOF");
    }

}
