using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteAnim : MonoBehaviour
{
    //Put the sprite 2D game object in the inspector here.
    public GameObject AnimatedGameObject;
    //Put all the animation sprites. in this array in the inspector.
    public Sprite[] Anim_Sprites;
    //This will allow the script to keep track of the last displayed sprite.
    public int[] First_SpriteID;
    private int Cur_SpriteID;
    public int[] Last_SpriteID;
    private float SecsPerFrame = 0.25f;

    void Awake()
    {
        Cur_SpriteID = First_SpriteID[0] = 0;
        //Last_SpriteID = 4;
        PlayAnimation(0, 0.25f);
    }

    public enum SpriteId
    {
        normal,
        flapping,
        attacking,

    }

    public void PlayAnimation(int ID, float secPerFrame)
    {
        SecsPerFrame = secPerFrame;
        StopCoroutine("AnimateSprite");
        //Add as much ID as necessary. Each is a different animation.
        switch (ID)
        {
            default:
                Cur_SpriteID = First_SpriteID[ID];
                StartCoroutine("AnimateSprite", ID);
                break;
            case 3:
                //Example if you want an animation to something specifique
                //Other than just passing through the sprites.
                Cur_SpriteID = First_SpriteID[ID];
                StartCoroutine("AnimateSprite", ID);
                break;
        }
    }

    IEnumerator AnimateSprite(int ID)
    {
        switch (ID)
        {
            default:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID > Last_SpriteID[ID])
                {
                    Cur_SpriteID = First_SpriteID[ID];
                }
                StartCoroutine("AnimateSprite", ID);
                break;

            //This is an exemple of an animation that only play once, but needs to play fully.
            //Like attacks, being hit, jumps and landings, etc.
            case 7:
                yield return new WaitForSeconds(SecsPerFrame);
                AnimatedGameObject.GetComponent<SpriteRenderer>().sprite
                = Anim_Sprites[Cur_SpriteID];
                Cur_SpriteID++;
                if (Cur_SpriteID > Last_SpriteID[ID])
                {
                    //This will return the animation to the default animation
                    //once the set amount of sprite has been fully displayed.
                    PlayAnimation(0, 0.25f);
                }
                else
                {
                    StartCoroutine("AnimateSprite", ID);
                }
                break;
        }
    }
}