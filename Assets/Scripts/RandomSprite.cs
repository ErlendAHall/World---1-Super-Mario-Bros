using UnityEngine;
using System.Collections;

public class RandomSprite : MonoBehaviour
{

    public Sprite[] sprites;
    public string resourceName;
    public int currentSprites = -1;

    // Use this for initialization
    void Start()
    {
        if (resourceName != "")
        {
            sprites = Resources.LoadAll<Sprite>(resourceName);
           // 

            if (currentSprites == -1)
            {
                currentSprites = Random.Range(0, sprites.Length);
            } else if (currentSprites > sprites.Length){
                currentSprites = -1;
            }
            GetComponent<SpriteRenderer>().sprite = sprites[currentSprites];
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
