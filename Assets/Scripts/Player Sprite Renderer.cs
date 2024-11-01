using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private PlayerMovement movement;

    public Sprite idle;
    public Sprite jump;

    public Sprite slide;

    public Sprite run; // This should reference the GameObject with the AnimatedSprite script



    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = GetComponentInParent<PlayerMovement>();



    }

    private void OnEnable(){
        spriteRenderer.enabled = true;

    }

    private void OnDisable(){
        spriteRenderer.enabled = false;

    }


    private void LateUpdate()
{
   

    if (movement.Playerjumping)
    {
        spriteRenderer.sprite = jump;
    }
    else if (movement.PlayerSliding)
    {
        spriteRenderer.sprite = slide;
    }
    else if (!movement.Playerrunning)
    {
        spriteRenderer.sprite = idle;
    }
    else if (movement.Playerrunning)
    {
        // Run animation should be enabled and handled by AnimatedSprite
    }
}
}

