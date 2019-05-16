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
    public int atk;                 //ﾌﾟﾚｲﾔｰ攻撃力

    public GameObject gembutton;    //ｼﾞｪﾑ発動ﾎﾞﾀﾝ 
    public float 
        gempower ,gempower_max = 15;//ｼﾞｪﾑﾊﾟﾜｰ
    private bool gembool;           //ｼﾞｪﾑﾊﾟﾜｰ減少中か否か

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
            if (gempower < gempower_max)
            {
                gempower = gempower + 1;
            }
            if (intervalTime >= 0.1f)
            {
                intervalTime = 0.0f;
                anim.SetTrigger("shot");
                cannon.GetComponent<cannon>().gun();
            }
        }
        Debug.Log(gempower);

        //ｼﾞｪﾑﾊﾟﾜｰが最大になったら
        if (gembool == false)
        {
            if (gempower == gempower_max)
            {
                gembutton.SetActive(true);
            }
        }

        if(gembool == true)
        {
            gempower -= (Time.timeScale / 10);
            if(gempower <= 0)
            {
                gembool = false;
                gempower = 0;
                atk = atk - 1;
            }
        }
    }

    //弾丸発射処理
    public void UIshot()
    {
        anim.SetTrigger("shot");
        cannon.GetComponent<cannon>().gun();
    }

    //ｼﾞｪﾑﾊﾟﾜｰ処理
    public void atkup()
    {
        Debug.Log("aa");
        atk = atk + 1;
        Debug.Log(atk);
        obj = (GameObject)Instantiate(atk_aura, this.transform.position, Quaternion.identity);
        obj.transform.parent = Player.transform;
        //atkUI.SetActive(true);
    }

    //ｼﾞｪﾑ獲得処理
    public void gemup()
    {
        if (gempower < gempower_max)
        {
            gempower = gempower + 1;
        }
    }

    //ｼﾞｪﾑﾎﾞﾀﾝ押下処理
    public void gemdown()
    {
        gembutton.SetActive(false);
        gembool = true;
        atk = atk + 1;
        
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
