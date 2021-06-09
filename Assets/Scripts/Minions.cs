using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minions : MonoBehaviour
{
    [SerializeField] private GameObject minion;
    [SerializeField] private int minionNumber;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < minionNumber; i++)
        {
            float rangeX = Random.Range(-150, 150);
            float rangeZ = Random.Range(-150, 150);
            // 
            Instantiate(minion, new Vector3(rangeX, 0.5f, rangeZ), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
