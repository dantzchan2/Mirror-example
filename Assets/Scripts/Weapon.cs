using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Weapon : NetworkBehaviour
{

    [SerializeField] private float damage = 10;
    [SerializeField] GameObject owner = null;
  
    void OnTriggerEnter(Collider collider)
    {
        GameObject target = collider.gameObject;
        if(target.name != "sword") {
            TargetGiveDamage(target.transform.parent.GetComponent<NetworkConnection>(), damage);
        }
    }

    [TargetRpc]
    public void TargetGiveDamage(NetworkConnection target, float amt)
    {
        owner.GetComponent<Character>().TakeDamage(amt);
    }
}
