using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world_go : MonoBehaviour
{

    private Animator animator;
    public string scene;
    public int flag;

    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();

        if (FlagManager.Instance.flags[flag] == true)
        {
            animator.SetBool("color", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "player")
        {
            FadeManager.Instance.LoadScene(scene, 1.0f);
        }
    }
}
