using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject target;
    public Rigidbody2D bulletPrefab;

    private void Start()
    {
        StartCoroutine(shootRoutine());
    }
    IEnumerator shootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(1);
        }
    }

    void Shoot()
    {
        Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, target.transform.position, 1f);

        Rigidbody2D firedBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);

        Destroy(firedBullet.gameObject, 3f);

        firedBullet.linearVelocity = projectileVelocity;
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;

        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);
    }
}