using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class EmptyController : NetworkBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<CharacterSpawner>().TrySpawn();
    }

}
