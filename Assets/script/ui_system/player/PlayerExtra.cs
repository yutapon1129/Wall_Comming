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
    public bool gembool = false;   //ｼﾞｪﾑﾊﾟﾜｰ減少中か否か

    [SerializeField] Animator gem_background1;      //gembarのbackground格納
    [SerializeField] Animator gem_background2;     


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

        //GemPower使用時変数減少
        if (gembool == true)
        {
            gempower -= (Time.timeScale / 30);
            if (gempower <= 0)
            {
                gembool = false;
                gempower = 0;
                gem_background1.SetBool("gem_using", false);
                gem_background2.SetBool("gem_using", false);
                atk = atk - 1;
            }
        }
    }

    private void FixedUpdate()
    {
        
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
        if(gempower > 1)
        {
            if(gembool == true)
            {
                gembool = false;
                gem_background1.SetBool("gem_using", false);
                gem_background2.SetBool("gem_using", false);
                atk = atk - 1;
            }
            else
            {
                gembool = true;
                gem_background1.SetBool("gem_using", true);
                gem_background2.SetBool("gem_using", true);
                atk = atk + 1;

            }
        }
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
