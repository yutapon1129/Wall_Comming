﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_HP : MonoBehaviour
{
    public GameObject explosion;
    public int flag;

    //体力関係
    public int HP;
    public GameObject player;

    public GameObject Rsystem;
    private GameObject Memory_world;

    void Start()
    {
        player = GameObject.Find("player");

        Memory_world = GameObject.Find("select memory");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // 体力関係
        if (col.tag == "bullet")
        {
            int player_atk = player.GetComponent<PlayerExtra>().atk;
            HP = HP - player_atk;
            if (HP <= 0)
            {
                Rsystem = GameObject.Find("restart_bool");//restart_boolの取得
                Destroy(Rsystem);                         //restart_boolの削除

                int number = Memory_world.GetComponent<Select_memory>().world_number;

                this.gameObject.SetActive(false);
                Instantiate(explosion, transform.position, transform.rotation);
                FadeManager.Instance.LoadScene("select_w" + number, 2.0f);
                FlagManager.Instance.flags[flag] = true;
            }
        }
    }
}