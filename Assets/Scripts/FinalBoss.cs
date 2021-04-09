using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    [SerializeField] GameObject gameManager;
    [SerializeField] GameObject spikes;
    [SerializeField] GameObject spikeSpawner;


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
            bool isGoodEnding = gameManager.GetComponent<RelicTracker>().EndingCheck();
            if (isGoodEnding)
            {
                gameManager.GetComponent<RelicTracker>().PlayerWin();
            }
            else
            {
                //spawn spikes
                GameObject _ = Instantiate(spikes, spikeSpawner.transform);
                _.transform.SetParent(spikeSpawner.transform);

            }
        }
    }

}
