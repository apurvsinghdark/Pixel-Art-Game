using UnityEngine;

public class MovingPlateform : MonoBehaviour
{
    [SerializeField] Transform fromPosition;
    [SerializeField] Transform toPosition;
    Vector3 nextPosition;
    [SerializeField] float speed;

    private void Start() {
        nextPosition = toPosition.position;
    }

    private void FixedUpdate() {
        Moving();
    }
    void Moving()
    {
        
        if(transform.position == fromPosition.position)
        {
            nextPosition = toPosition.position;
        }else
        if(transform.position == toPosition.position)
        {
            nextPosition = fromPosition.position;
        }
    
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        other.transform.SetParent(this.gameObject.transform);
    }
    private void OnCollisionExit2D(Collision2D other) {
        other.transform.SetParent(null);
    }
}
