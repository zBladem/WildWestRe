
using UnityEngine;
using Cinemachine;
public class CameraCrontoller : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera[] virtualCameras;

    void ChangeCamera(int index)
    {
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            virtualCameras[i].Priority = 0;
        }
        virtualCameras[index].Priority = 1;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grande"))
        {
            ChangeCamera(1);
        }
        else if (collision.gameObject.CompareTag("Grandee"))
        {
            ChangeCamera(2);
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Grande"))
        {
            ChangeCamera(0);
        }
        else if (collision.gameObject.CompareTag("Grandee"))
        {
            ChangeCamera(0);
        }

    }
}
