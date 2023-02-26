using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy tartgetEnemy;

    [Header("속성")]
    public float range = 15f;

    [Header("불릿 사용")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("레이저 사용")]
    public bool useLaser = false;

    public int damageOverTime = 30;
    public float slowAmount = 0.5f;

    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnspeed = 10f;


    public Transform firePoint;

    public bool Tower2;
    Animator animator;
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        animator = GetComponent<Animator>();
    }
    void UpdateTarget()
    { 
         GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
         float shortestDistance = Mathf.Infinity;
         GameObject nearestEnemy = null;

         foreach(GameObject enemy in enemies)
         {
             float distancToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

             if(distancToEnemy < shortestDistance)
             {
                 shortestDistance = distancToEnemy;
                 nearestEnemy = enemy;
             }
         }
         if(nearestEnemy != null && shortestDistance <= range)
         {
            target = nearestEnemy.transform;
            tartgetEnemy = nearestEnemy.GetComponent<Enemy>();
         }
         else
         {
            target = null;
         }
    }


    
    void Update()
    {
        if (target == null)
        {
            if (useLaser)
            {
                animator.SetBool("Casting", false);
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }

            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
        


    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Laser()
    {
        animator.SetBool("Casting", true);
        tartgetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        tartgetEnemy.Slow(slowAmount);
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;

        impactEffect.transform.rotation = Quaternion.LookRotation(dir);

    }
    void Shoot()
    {
        if (Tower2)
        {
            animator.SetTrigger("Attack2");
        }
        else
        {
            animator.SetTrigger("Attack1");
        }


        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
