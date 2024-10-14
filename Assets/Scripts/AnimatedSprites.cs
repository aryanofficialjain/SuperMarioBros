using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Sprite[] sprites;
    public float framerate = 1f/6f;

    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void OnEnable(){
        InvokeRepeating(nameof(Animate), framerate, framerate);


    }

    private void Disable(){
        CancelInvoke();

    }

    private void Animate(){
        frame++;
        if(frame >= sprites.Length){
            frame = 0;

        }

        if(frame >= 0 && frame < sprites.Length){

        spriteRenderer.sprite = sprites[frame];
        }


    }




}
