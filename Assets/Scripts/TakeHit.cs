using UnityEngine;

public class TakeHit : MonoBehaviour
{
    public int deadCount = 0;
    public bool isHit = false;

    public GameObject spawnPoint;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Respawn();
    }

    void Respawn()
    {
        if (isHit)
        {
            transform.position = spawnPoint.transform.position;
            isHit = false;
        }
    }

    public void GetHit()
    {
        isHit = true;
        deadCount++;
    }

}
