using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic3 : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.GetComponent<RelicTracker>().UpdateRelic3();
            Destroy(gameObject);
        }
    }
}
