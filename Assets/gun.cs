using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    enemy closestEnemy = null;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Shoot();
        }
    }
    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        closestEnemy = null;
        enemy[] allEnemies = GameObject.FindObjectsOfType<enemy>();

        foreach (enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        //Debug.DrawLine(player.transform.position, closestEnemy.transform.position);
    }
    void Shoot()
    {
        RaycastHit hit;
        FindClosestEnemy();
        GameObject target = closestEnemy.gameObject;
        if (Physics.Linecast(this.transform.position,target.transform.position,out hit))
        {
            Debug.Log(hit.transform.tag);
            if (hit.transform.tag == "Enemy")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

}
