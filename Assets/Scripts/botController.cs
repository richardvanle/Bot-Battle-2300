using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : MonoBehaviour
{
    public Animator botAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        botAnimator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            botAnimator.SetBool("isDead", true);
            
        }
    }
}
