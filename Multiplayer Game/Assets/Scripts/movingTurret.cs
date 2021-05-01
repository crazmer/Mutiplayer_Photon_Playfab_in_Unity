using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingTurret : MonoBehaviour
{
    private Transform target; //target

    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCount = 0f;
    public float range = 10f; //range

    [Header("Setup Fields")]
    public string enemyTag = "Enemy"; //tag
    public Transform pathtoRotate;
    public float rotateSpeed = 10f;


    public GameObject bulletP;
    public Transform fireP;


     
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget",0f,0.5f);  //called upadte function  
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        
            foreach(GameObject enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }

            }
            if (nearestEnemy != null && shortestDistance <= range)
            {
                target = nearestEnemy.transform;
            }
            else
            {
                target = null;
            }
    }

    // Update is called once per frame
    void Update()
    {
        if(target== null)
        
        return;
        
        //TargetLocking
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(pathtoRotate.rotation,lookRotation,Time.deltaTime*rotateSpeed).eulerAngles;
        pathtoRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCount<=0)
        {
            shoot();
            fireCount = 1f / fireRate;
        }
        fireCount -= Time.deltaTime; 
        
    }

    void shoot()
    {
        Debug.Log("Shooting");
        GameObject bull= (GameObject)Instantiate(bulletP, fireP.position, fireP.rotation);
        bullet bullt = bull.GetComponent<bullet>();

        if(bullt!=null)
        {
            bullt.seek(target);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
