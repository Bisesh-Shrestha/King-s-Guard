using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBoss : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private GameObject portal;
    private void Update()
    {
        if (enemyHealth.isdead)
        {
            portal.SetActive(true);
        }
    }
}
