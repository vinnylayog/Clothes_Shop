using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private float radius = 3.0f;

    GameObject player;

    //On Left Click, Item will be Interacted with if Player is within the radius from item
    private void OnMouseDown()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (Vector2.Distance(player.transform.position, transform.position) <= radius)
        {
            Interact();
        }
    }

    //Draw a Sphere for Editor Visualization of radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    //Generic Interact function
    public virtual void Interact()
    {
        //Debug.Log("Interacting with " + gameObject.name);
    }
}
