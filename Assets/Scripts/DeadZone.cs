using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<TakeHit>())
        {
            TakeHit hit = other.gameObject.GetComponent<TakeHit>();
            hit.GetHit();
        }
    }
}
