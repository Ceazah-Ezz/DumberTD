using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] public GameObject Enemy;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
    }
}
