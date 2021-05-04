using UnityEngine;
using Photon.Pun;

public class bullet : MonoBehaviour
{
    private Transform target;
    public Shooting Shooting;
    public float speed = 70f;
    PhotonMessageInfo info;
    private void Start()
    {
        Shooting = GetComponent<Shooting>();
    }

    public void seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
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
            hitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void hitTarget()
    {
        Shooting.TakeDamage(5,info);
    }
}
