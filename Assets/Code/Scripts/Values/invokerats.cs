
using UnityEngine;

public class invokerats : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] GameObject rata;
    [SerializeField] GameObject lagarto;
    [SerializeField] Transform ratposition;
    [SerializeField] Transform lagartoposition;
    private float nextAttackTime;

  
    void Start()
    {
        nextAttackTime = Time.time;
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            ivokeenemy();
            nextAttackTime = Time.time + attackCooldown;
        }
    }
    void ivokeenemy()
    {
        float randomValue = Random.value;
        if (randomValue < 0.33f)
        {
            Instantiate(rata, ratposition.position, Quaternion.identity);
        }
        if (randomValue < 0.55f)
        {
            Instantiate(lagarto, lagartoposition.position, Quaternion.identity);
        }
    }
}

//         if (randomValue< 0.f)
//            {
//                Instantiate(rata, ratposition.position, Quaternion.identity);
//    timer = 0;
//            }
//float randomValue = Random.value;


//            else if (randomValue < 0.66f)
//{
//    Instantiate(lagarto, ratposition.position, Quaternion.identity);
//    timer = 0;
//}
                     
        
    
//}
