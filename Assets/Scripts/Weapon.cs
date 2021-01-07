using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] private float damage = 10;
    // [SerializeField] GameObject owner = null;

    void Start()
    {
        // owner = this.gameObject.transform.parent.transform.parent.gameObject;
    }
    void OnTriggerEnter(Collider collider)
    {
        GameObject target = collider.gameObject;
        if (target.name == "player_visual")
        {
            target.transform.parent.GetComponent<Character>().TakeDamage(damage);
            // owner.GetComponent<Character>().GiveDamage(target.transform.parent, damage);
            // TargetGiveDamage(target.transform.parent.GetComponent<NetworkConnection>(), );
        }
    }


}
