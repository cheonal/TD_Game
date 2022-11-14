using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float explsionRadius = 0f;
    public GameObject effect;
    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarger();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarger()
    {
        GameObject effectIns =(GameObject) Instantiate(effect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explsionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }
    void Explode()
    {
        Collider[] coliders = Physics.OverlapSphere(transform.position, explsionRadius);
        foreach(Collider colider in coliders)
        {
            if(colider.tag == "Enemy")
            {
                Damage(colider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    void OnDrawGizmoSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explsionRadius);
    }
}
