using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private string Enemy = "Enemy";
    private Transform target;

    [Header("Bullet attributes")]
    public float speed = 50f;

    public void Pewpew (Transform _target)
    {
        target = _target;
    }

    #region [Bullet code]
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            return;
        }

        // Makes the bullet in a constant speed, space world is there in
        // order to make the bullet trajectory straight
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }
    #endregion

    void OnCollisionEnter(Collision Bullet)
    {
        if (Bullet.gameObject.CompareTag(Enemy))
        {
            Destroy(gameObject);
        }
    }
}
