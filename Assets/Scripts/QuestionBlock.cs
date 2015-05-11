using UnityEngine;
using System.Collections;

public class QuestionBlock : MonoBehaviour {

    private Animator anim;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   /* void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            anim.SetInteger("AnimState", 1);
        }
    }
    * */

    public void ChangeBox()
    {
        anim.SetInteger("AnimState", 1);
    }
}
