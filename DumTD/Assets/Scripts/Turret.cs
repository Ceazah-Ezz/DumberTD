using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Tower rotation")]
    public Transform target; //enemy target
    public Transform Rotate;
    public float speed = 5f;

    
    [Header("Tower attributes")]
    public MeshRenderer SelectionColor; //Indicates the player if the tower is cliked on or not
    public GameObject Prefabbullet; //Bullet GameObject/prefab
    public Transform firingpoint;
    public float range = 10f;

    #region [Mouse Clicks]

    private void OnMouseExit()
    {
        SelectionColor.material.color = Color.white;
    }

    private void OnMouseDown()
    {
        Debug.Log("Tower clicked!");
        Attack();
        SelectionColor.material.color = Color.darkBlue;
    }

    private void OnMouseEnter()
    {
        SelectionColor.material.color = Color.blue;
    }
    #endregion

    #region [Update function]
    void Update()
    {
        #region [Tower rotation]
        if (target == null)
        return;

        Vector3 Tdirection = (target.position - transform.position).normalized;

        //This makes the tower not float suddenly
        Tdirection.y = 0f;

        if (Tdirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Tdirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }

        float dotProduct = Vector3.Dot(transform.forward, Tdirection);

        if (dotProduct > 0.95)
        {
            Debug.Log("Target locked!");
        }
        else
        {
            Debug.Log("Searching...");
        }
        #endregion
    }
    #endregion

    #region[Attack code]
    void Attack()
    {
        GameObject Objectbullet = (GameObject)Instantiate(Prefabbullet, firingpoint.position, firingpoint.rotation);
        Bullet bullet = Objectbullet.GetComponent<Bullet>();

        if (bullet != null) {
            bullet.Pewpew(target);
        }
    }
    #endregion
}