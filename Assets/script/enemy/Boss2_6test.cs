using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2_6test : MonoBehaviour
{

    [SerializeField] GameObject Boss_FBj;   //ボス用弾丸

    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("unti", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void unti()
    {
        StartCoroutine("burst");
        Debug.Log(transform.eulerAngles.z);
    }

    private IEnumerator burst()
    {
        Instantiate(Boss_FBj, transform.position, Quaternion.Euler(0f, 0f, transform.eulerAngles.z + 20f));
        //yield return new WaitForSeconds(0.5f);
        Instantiate(Boss_FBj, transform.position, Quaternion.Euler(0f, 0f, transform.eulerAngles.z - 20f));
        //yield return new WaitForSeconds(0.5f);
        Instantiate(Boss_FBj, transform.position, Quaternion.Euler(0f, 0f, transform.eulerAngles.z));

        yield break;        //終了


        //speed_box = 0;
        //yield return null;
        //speed_box = speed;
        //yield return null;
        //speed = 0;
        //yield return new WaitForSeconds(0.5f);
        ////Instantiate(bone, transform.position, transform.rotation);
        //GameObject shot = Instantiate(bone, transform.position, transform.rotation) as GameObject;
        //yield return null;
        //Bone s = shot.GetComponent<Bone>();
        //yield return null;
        //s.Create(transform.localScale.x);
        //yield return new WaitForSeconds(0.5f);
        //speed = speed_box;
        //yield return new WaitForSeconds(0.5f);
    }
}
