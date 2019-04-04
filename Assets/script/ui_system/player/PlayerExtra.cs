using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExtra : MonoBehaviour
{
    private Animator anim;          //Playerのanimator格納
    private GameObject obj;         //effect用
    public GameObject cannon;       //銃口ｵﾌﾞｼﾞｪｸﾄ格納
    public GameObject 
        atk_aura,atkUI;             //攻撃力上昇ｴﾌｪｸﾄ関係
    public GameObject Player;       //Playerのｵﾌﾞｼﾞｪｸﾄ格納
    public GameObject gateeffect;   //ｹﾞｰﾄ用ｴﾌｪｸﾄ

    private float intervalTime;     //連射速度（pcﾃﾞﾊﾞｯｸﾞ用）
    public int atk;             //ﾌﾟﾚｲﾔｰ攻撃力

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //弾丸発射処理（pcデバッグ用）
        intervalTime += Time.deltaTime;
        if (Input.GetKeyDown("left ctrl"))
        {
            if (intervalTime >= 0.1f)
            {
                intervalTime = 0.0f;
                anim.SetTrigger("shot");
                cannon.GetComponent<cannon>().gun();
            }
        }
    }

    //弾丸発射処理
    public void UIshot()
    {
        anim.SetTrigger("shot");
        cannon.GetComponent<cannon>().gun();
    }

    //攻撃力関係処理
    public void atkup()
    {
        atk += atk;
        Debug.Log(atk);
        obj = (GameObject)Instantiate(atk_aura, this.transform.position, Quaternion.identity);
        obj.transform.parent = Player.transform;
        atkUI.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //クリスタルゲートに触れた時の処理
        if (collision.tag == "gate")
        {
            Player.SetActive(false);
            Instantiate(gateeffect, this.transform.position, Quaternion.identity);
        }
    }
}
