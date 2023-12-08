using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManagerScript : MonoBehaviour {

    // 4 public game objects in static stores health amount
    public GameObject life1, life2, life3, life4, life5;
    

    public string nameOfCharacterControllerScript;


    // Use for initialisation, enable lives and then switch off game over
    public static int lives;

    
    void Start () 
    {

        lives = 3;

        life1.gameObject.SetActive (true);
        
        life2.gameObject.SetActive (true);

        life3.gameObject.SetActive (true);

        life4.gameObject.SetActive(false);

        life5.gameObject.SetActive(false);

    }
    //update method to constrain the amount of lives
    void Update () 
    { 

        if (lives > 5) lives = 5;

        // health variable in switch method
        switch (lives) {


        case 5:

            life1.gameObject.SetActive (true);

            life2.gameObject.SetActive (true);

            life3.gameObject.SetActive (true);

            life4.gameObject.SetActive(true);

            life5.gameObject.SetActive(true);

            break;

        case 4:

            life1.gameObject.SetActive (true);

            life2.gameObject.SetActive (true);

            life3.gameObject.SetActive (true);

            life4.gameObject.SetActive(true);

            life5.gameObject.SetActive(false);

            break;

        case 3:

            life1.gameObject.SetActive (true);

            life2.gameObject.SetActive (true);

            life3.gameObject.SetActive (true);

            life4.gameObject.SetActive(false);

            life5.gameObject.SetActive(false);

            break;

        case 2:

            life1.gameObject.SetActive (true);

            life2.gameObject.SetActive (true);

            life3.gameObject.SetActive (false);

            life4.gameObject.SetActive(false);

            life5.gameObject.SetActive(false);

            break;

        case 1:

            life1.gameObject.SetActive (true);

            life2.gameObject.SetActive(false);

            life3.gameObject.SetActive (false);

            life4.gameObject.SetActive(false);

            life5.gameObject.SetActive(false);

            break;

        case 0:

                life1.gameObject.SetActive(false);

                life2.gameObject.SetActive(false);

                life3.gameObject.SetActive(false);

                life4.gameObject.SetActive(false);

                life5.gameObject.SetActive(false);

                break;

        }

        if( lives < 1 )
        {

            Debug.Log("DEAD");
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

        }

    }
    
    public void IncreaseLife()
    {

        lives += 1;

    }

    public void DecreaseLife( int damage )
    {

        lives += damage;


    }

}



