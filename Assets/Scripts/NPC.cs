using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float colliderDistance;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private GameObject interactPanel;
    private bool isDone = false;

    private void Update()
    {
        if (PlayerInSight())
        {
            if (!isDone)
            {
                interactPanel.SetActive(true);
                isDone = true;
            }
            if (Input.GetButtonDown("Vertical"))
            {
                interactPanel.SetActive(false);
                dialogPanel.SetActive(true);
            }
        }
        else
        {
            interactPanel.SetActive(false);
            isDone = false;
        }

    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit =
             Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
             new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
             0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }
}
