using UnityEngine;

public class BossChangeState : MonoBehaviour
{
    //public int state;
    //[SerializeField] GameObject[] StateList;
    //private int currentstate = -1;
    //private void Awake()
    //{
    //    if (currentstate == state) return;
    //    for(int i = 0; i < StateList.Length; i++)
    //    {
    //        StateList[i].SetActive(i == state);
    //    }
    //}
    //{
    [SerializeField] GameObject[] states;
    private float currentTime;
    [SerializeField] float delay = 1;
    [SerializeField] float repeatingTime = 4;
    private void Awake()
    {
        ChangeState(-1);
        InvokeRepeating(nameof(RandomState), delay, repeatingTime);
    }
    private void RandomState()
    {
        ChangeState(Random.Range(0, states.Length));
    }
    private void ChangeState(int index)
    {
        for (int i = 0; i < states.Length; i++)
            states[i].SetActive(i == index);
    }
}
