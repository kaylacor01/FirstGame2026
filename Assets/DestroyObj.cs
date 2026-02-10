using UnityEngine;

public class DestroyObj : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(this.gameObject);
    }
}
