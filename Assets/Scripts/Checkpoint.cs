using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameObject spawnPoint;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            spawnPoint.transform.position = new Vector2(transform.position.x,transform.position.y + 1);

        }
    }

}
