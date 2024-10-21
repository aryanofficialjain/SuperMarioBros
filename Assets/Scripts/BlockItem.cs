using System.Collections;
using UnityEngine;

public class BlockItem : MonoBehaviour
{
    public float gravityMultiplier = 16f; // Add a public variable to adjust gravity easily

    private void Start(){
        StartCoroutine(Animate());
    }

    private IEnumerator Animate(){
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        CircleCollider2D physicsCollider = GetComponent<CircleCollider2D>();
        BoxCollider2D triggerCollider = GetComponent<BoxCollider2D>();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // Disable physics and render initially
        rigidbody.isKinematic = true;
        physicsCollider.enabled = false;
        triggerCollider.enabled = false;
        spriteRenderer.enabled = false;

        yield return new WaitForSeconds(0.25f);

        // Enable sprite renderer after delay
        spriteRenderer.enabled = true;

        // Move the item upwards
        float elapsed = 0f;
        float duration = 0.5f;
        Vector3 startPosition = transform.localPosition;
        Vector3 endPosition = transform.localPosition + Vector3.up;

        while (elapsed < duration){
            float t = elapsed / duration;
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        
        transform.localPosition = endPosition;
        

        // Enable physics so the power-up falls vertically with increased gravity
        rigidbody.isKinematic = false; 
        rigidbody.gravityScale = gravityMultiplier; // Increase gravity

        physicsCollider.enabled = true;
        triggerCollider.enabled = true;
    }
}