﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;
public class Character : NetworkBehaviour
{
    bool canPlayerMove = true;

    public float speed = 15.0f;
    [SerializeField] GameObject player_visual;
    [SerializeField] GameObject weapon;
    [SerializeField] Slider hpSlider;
    [SerializeField] public float maxHp = 100;
    [SerializeField][SyncVar] public float hp = 100;

    void Start()
    {
        if (base.isClient && base.hasAuthority)
        {
            MeshRenderer mR = player_visual.GetComponent<MeshRenderer>();
            mR.material.color = Color.green;

            MeshRenderer mR2 = weapon.GetComponent<MeshRenderer>();
            mR2.material.color = Color.green;
        }

    }

    private void Update()
    {
        hpSlider.value=hp;
        if(hp <= 0) {
            Destroy(this);//safe?
        }
        if (!isLocalPlayer) return;
        float moveHorizontal = -Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveVertical, 0.0f, moveHorizontal);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15F);
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

    }

    public void TakeDamage(float amt) {
        Debug.Log($"take {amt} damage!");
        hp -= amt;
    }
}