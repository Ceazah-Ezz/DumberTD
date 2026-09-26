using UnityEngine;

public class OrbitalTarget : MonoBehaviour
{
    [SerializeField] private string Base = "Base";
    [SerializeField] private string Bullet = "Bullet";

    public Transform pointA, pointB;
    public float travelDuration;

    private float timer;
    private bool toB = true;

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / travelDuration;

        Vector3 start = toB ? pointA.position : pointB.position;
        Vector3 target = toB ? pointB.position : pointA.position;

        transform.position = Vector3.Lerp(start, target, t);

        if (t > 1f)
        {
            timer = 0;
            toB = !toB;
        }
    }

    void OnCollisionEnter(Collision Enemy)
    {
        if (Enemy.gameObject.CompareTag(Base))
        {
            GameManager.Instance.SubtractScore(20);
            Debug.Log("Base hit!");
        }

        if (Enemy.gameObject.CompareTag(Bullet))
        {
            GameManager.Instance.AddScore(10);
            Debug.Log("Enemy shot!");
        }
    }
}
