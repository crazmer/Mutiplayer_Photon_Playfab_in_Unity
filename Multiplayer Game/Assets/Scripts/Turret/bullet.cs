using UnityEngine;

public class bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

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
        Debug.Log("Khopdi Thod Saale Ka");
        Destroy(gameObject);

    }
}
