using UnityEngine;

public class Girarenemigo : MonoBehaviour
{
    [SerializeField] private Transform player;
    private bool MiraALaDerecha = true;


    void Update()
    {
        bool PlayerEstaenLaDerecha = transform.position.x < player.transform.position.y;
        Girar(PlayerEstaenLaDerecha);
    }

    private void Girar(bool PlayerEstaenLaDerecha)
    {
        if ((MiraALaDerecha && PlayerEstaenLaDerecha) || (MiraALaDerecha && !PlayerEstaenLaDerecha))
        {
            MiraALaDerecha = !MiraALaDerecha;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
