using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ant_enemy : MonoBehaviour
{
    public float timeOut;           //攻撃頻度の時間
    private float timeElapsed;      //時間計測変数格納用

    // 射出するオブジェクト
    [SerializeField] private GameObject ThrowingObject;

    // 標的のオブジェクト
    public GameObject player;

    // 射出角度
    [SerializeField, Range(0F, 90F)] private float ThrowingAngle;

    private void Start()
    {
        Collider collider = GetComponent<Collider>();
        player = GameObject.Find("player");
        timeElapsed = timeOut;
        if (collider != null)
        {
            collider.isTrigger = true;
        }
    }

    private void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;//時間計測
        if (timeElapsed >= timeOut)//設定した時間になったら読み込み
        {
            ThrowingEnemy();
            timeElapsed = 0.0f;//変数リセット用
        }
    }

    // antを射出する
    private void ThrowingEnemy()
    {
        if (ThrowingObject != null && player != null)
        {
            // enemyオブジェクトの生成
            GameObject enemy = Instantiate(ThrowingObject, this.transform.position, Quaternion.identity);
            // 標的の座標
            Vector2 targetPosition = player.transform.position;
            // 射出角度
            float angle = ThrowingAngle;
            // 射出速度を算出
            Vector2 velocity = CalculateVelocity(this.transform.position, targetPosition, angle);
            // 射出
            Rigidbody2D rid = enemy.GetComponent<Rigidbody2D>();
            rid.AddForce(velocity * rid.mass, ForceMode2D.Impulse);
        }
        else
        {
            throw new System.Exception("射出するオブジェクトまたは標的のオブジェクトが未設定です。");
        }
    }
    // 標的に命中する射出速度の計算
    // <param name="pointA">射出開始座標</param>
    // <param name="pointB">標的の座標</param>
    // <returns>射出速度</returns>

    private Vector3 CalculateVelocity(Vector3 pointA, Vector3 pointB, float angle)
    {
        // 射出角をラジアンに変換
        float rad = angle * Mathf.PI / 180;
        // 水平方向の距離x
        float x = Vector2.Distance(new Vector2(pointA.x, pointA.z), new Vector2(pointB.x, pointB.z));
        // 垂直方向の距離y
        float y = pointA.y - pointB.y;
        // 斜方投射の公式を初速度について解く
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(rad), 2) * (x * Mathf.Tan(rad) + y)));

        if (float.IsNaN(speed))
        {
            // 条件を満たす初速を算出できなければVector3.zeroを返す
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x, x * Mathf.Tan(rad), pointB.z - pointA.z).normalized * speed);
        }
    }
}
