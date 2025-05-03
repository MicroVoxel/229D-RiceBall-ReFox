using UnityEngine;

public class DeadEffect : MonoBehaviour
{
    private TakeHit poolOwner;

    public void Init(TakeHit owner)
    {
        poolOwner = owner;
    }

    public void OnDeathEffectFinished()
    {
        if (poolOwner != null)
        {
            poolOwner.ReturnEffectToPool(gameObject);
        }
    }
}
