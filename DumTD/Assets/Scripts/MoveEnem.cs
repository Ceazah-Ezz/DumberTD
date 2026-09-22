using Unity.VisualScripting;
using UnityEngine;

public class MoveEnem : MonoBehaviour
{
    public Transform pA, pB;
    public float spd;
    public Collider Enemy;

    private float timer;
    private bool atBase = true; 

    void Update()
    {
        timer += Time.deltaTime;
        float t = timer / spd;

        Vector3 start = atBase ? pA.position : pB.position;
        Vector3 end = atBase ? pA.position : pB.position;

        transform.position = Vector3.Lerp(start, end, t);

        if (t > 1f)
        {
            timer = 0;  
            atBase = false;
        }

        //gameObject.CompareTag("Base");
        //gameObject.CompareTag("Bullet");

        void OnTriggerEnter(Collider Enemy)
        {
            if (Enemy.CompareTag("Base") || Enemy.CompareTag("Bullet"))
            {
                EnemyDespawn();
            }
        } 
    }

    void EnemyDespawn()
    {
        Destroy(gameObject);
    }
}
