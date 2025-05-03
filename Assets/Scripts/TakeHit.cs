using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TakeHit : MonoBehaviour
{
    public int deadCount = 0;
    public bool isHit = false;

    public TextMeshProUGUI deadUiText;

    public GameObject spawnPoint;
    public GameObject deadEffectPrefab;
    public int effectPoolSize = 10;

    private Rigidbody2D rb;
    private List<GameObject> effectPool;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InitEffectPool();
    }

    private void FixedUpdate()
    {
        Respawn();
    }

    void Respawn()
    {
        if (isHit)
        {
            GameObject effect = GetEffectFromPool();

            transform.position = spawnPoint.transform.position;
            isHit = false;

            effect.SetActive(true);
            effect.transform.position = transform.position;
            effect.transform.rotation = transform.rotation;

            // Return reference into script of effect
            DeadEffect de = effect.GetComponent<DeadEffect>();
            if (de != null) de.Init(this);

            if (deadUiText != null)
            {
                deadUiText.text = deadCount.ToString();
            }
        }
    }

    public void GetHit()
    {
        isHit = true;
        deadCount++;
    }

    // Pooling
    void InitEffectPool()
    {
        effectPool = new List<GameObject>();
        for (int i = 0; i < effectPoolSize; i++)
        {
            GameObject obj = Instantiate(deadEffectPrefab);
            obj.SetActive(false);
            effectPool.Add(obj);
        }
    }

    GameObject GetEffectFromPool()
    {
        foreach (GameObject obj in effectPool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        GameObject newObj = Instantiate(deadEffectPrefab);
        newObj.SetActive(false);
        effectPool.Add(newObj);
        return newObj;
    }

    public void ReturnEffectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
