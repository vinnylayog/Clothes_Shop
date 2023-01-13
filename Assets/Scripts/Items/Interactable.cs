using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    private float radius = 3.0f;

    GameObject player;

    private void OnMouseDown()
    {
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (Vector2.Distance(player.transform.position, transform.position) <= radius)
        {
            Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact()
    {
        //Debug.Log("Interacting with " + gameObject.name);
    }
}
