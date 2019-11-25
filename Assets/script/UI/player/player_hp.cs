using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_hp : MonoBehaviour
{

    public int hp = 3;
    public GameObject life1, life2, life3;//LifeUI関係
    public GameObject player, player_exp;//player関係
    public Renderer renderer;


    [SerializeField]
    //死亡した時に表示するUIのプレハブ
    private GameObject gameoverUIPrefab;
    //死亡UIのインスタンス
    private GameObject gameoverUIInstance;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (hp)
        {
            case 3:
                life1.SetActive(true);
                life2.SetActive(true);
                life3.SetActive(true);
                break;

            case 2:
                life1.SetActive(false);
                life2.SetActive(true);
                life3.SetActive(true);
                break;

            case 1:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(true);
                break;

            case 0:
                life1.SetActive(false);
                life2.SetActive(false);
                life3.SetActive(false);
                player.SetActive(false);
                Instantiate(player_exp, this.transform.position, Quaternion.identity);
                Invoke("death", 0);
                break;
        }

        //if (hp <= 2)
        //{
        //    life1.SetActive(false);
        //    if (hp <= 1)
        //    {
        //        life2.SetActive(false);
        //        if (hp <= 0)
        //        {
        //            life3.SetActive(false);
        //            player.SetActive(false);
        //            Instantiate(player_exp, this.transform.position, Quaternion.identity);
        //            Invoke("death", 0);
        //        }
        //    }
        //}

        //現在のカメラの位置から8低くした位置を下回った時
        if (gameObject.transform.position.y < Camera.main.transform.position.y - 15)
        {
            //LifeScriptのGameOverメソッドを実行する
            hp = 0;
        }
    }

    //死亡処理
    void death()
    {
        gameoverUIInstance = GameObject.Instantiate(gameoverUIPrefab) as GameObject;
        //Invoke("time0", 1f);
    }

    void time0()
    {
        Time.timeScale = 0f;
    }

    public void heal()
    {
        hp = hp + 1;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "enemy" ||col.gameObject.tag == "enemy_bullet")
        {
            StartCoroutine("Damage");
        }
        if (col.gameObject.tag == "boss" || col.gameObject.tag == "trap")
        {
            hp = 0;
        }
    }

    //ダメージを受けた時の一定時間無敵処理
    IEnumerator Damage()
    {
        //レイヤーをPlayerDamageに変更
        gameObject.layer = LayerMask.NameToLayer("playerdamage");
        hp = hp - 1;
        Debug.Log(hp);
        //while文を10回ループ
        int count = 10;
        while (count > 0)
        {
            //透明にする
            renderer.material.color = new Color(1, 1, 1, 0);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            //元に戻す
            renderer.material.color = new Color(1, 1, 1, 1);
            //0.05秒待つ
            yield return new WaitForSeconds(0.05f);
            count--;
        }
        //レイヤーをPlayerに戻す
        gameObject.layer = LayerMask.NameToLayer("player_hp");
    }
}
