using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameManager gm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            Time.timeScale = 0f;
            gm.endMenu.SetActive(true);
        }
    }
}
