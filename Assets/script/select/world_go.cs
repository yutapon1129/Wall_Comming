using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world_go : MonoBehaviour
{

    private Animator animator;
    public string scene;
    public int flag;

    private GameObject Memory ,crystal;
    public float crystal_X, crystal_Y;
    Locationmemory Code;

    private GameObject Memory_world;
    [SerializeField] int number;
    Select_memory Code2;



    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();

        Memory = GameObject.Find("location memory");
        crystal = this.gameObject;
        crystal_X = crystal.transform.localPosition.x;
        crystal_Y = crystal.transform.localPosition.y;
        Code = Memory.GetComponent<Locationmemory>();

        Memory_world = GameObject.Find("select memory");
        Code2 = Memory_world.GetComponent<Select_memory>();

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
            Code.player_x = crystal_X;
            Code.player_y = crystal_Y;

            Code2.world_number = number;

            FadeManager.Instance.LoadScene(scene, 1.0f);
        }
    }
}
