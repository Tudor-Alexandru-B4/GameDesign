using UnityEngine;

public class PangolinTongue : MonoBehaviour
{
    public int maxRotation = 360;
    public float rotationDegree = -2f;
    int rotaion = 0;
    EnemyMovement pangolin;

    private void Start()
    {
        pangolin = gameObject.transform.parent.gameObject.GetComponent<EnemyMovement>();
        pangolin.canMove = false;
    }

    private void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, 0f, rotationDegree));
        rotaion += Mathf.RoundToInt(Mathf.Abs(rotationDegree));
        if (rotaion >= maxRotation)
        {
            pangolin.canMove = true;
            Destroy(gameObject);
        }
    }
}
