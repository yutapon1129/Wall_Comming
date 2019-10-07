using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boss_hpbar : MonoBehaviour
{

    public GameObject player, boss;
    Slider hpslider;
    private int hp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        boss = GameObject.Find("stage_boss");
        hpslider = GameObject.Find("boss_hpbar").GetComponent<Slider>();

        hp = boss.GetComponent<Boss_HP>().HP;
        Debug.Log(hp);
        hpslider.maxValue = hp;
    }


    // Update is called once per frame
    void Update()
    {
        hp = boss.GetComponent<Boss_HP>().HP;
        hpslider.value = hp;
    }

    public void activator()
    {
        this.gameObject.SetActive(false);
    }
}
