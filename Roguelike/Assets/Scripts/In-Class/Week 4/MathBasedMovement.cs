using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class MathBasedMovement : MonoBehaviour
{
    //vector is direction

    public float speed = 1f;

    public Vector3 startPos;
    public Vector3 endPos;

    //a target we're moving forward
    public Transform targetTrans;

    public Vector3 moveDirection = Vector3.left;

    public float amplitude = 4f;
    public float frequency = 0.5f;

    public enum MovementMathType
    {
        TowardsTarget,
        SpeedPlusDirection,
        Random,
        Noise,
        Sin,
        Circle
    }

    public MovementMathType currentMovementType = MovementMathType.TowardsTarget;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Distance(transform.position, targetTrans.position) < 3)
        //{
        //    currentMovementType = MovementMathType.TowardsTarget;
        //}

        Vector3 movePos = new Vector3();

        switch (currentMovementType)
        {
            case MovementMathType.TowardsTarget:
                Debug.Log("Move Towards Target");

                endPos = targetTrans.position;

                Vector3 direction = endPos - transform.position;

                Debug.Log("Direction: " + direction);
                Debug.Log("Direction Magnitude: " + direction.magnitude);
                Debug.Log("Direction / Magnitude: " + direction.normalized);

                //these two do the same thing
                direction = direction.normalized;
                direction.Normalize();

                //transform.position = startPos + direction;
                transform.position += direction * speed * Time.deltaTime;
                break;

            case MovementMathType.SpeedPlusDirection:
                Debug.Log("Speed Plus Direction");

                moveDirection.Normalize();
                transform.position += moveDirection * (speed * Time.deltaTime);
                break;

            case MovementMathType.Random:
                Debug.Log("");
                movePos = transform.position;
                movePos += Vector3.right * (speed * Time.deltaTime);
                movePos.y += Random.Range(-0.1f, 0.1f);
                transform.position = movePos;
                break;

            case MovementMathType.Noise:
                Debug.Log("");
                movePos = transform.position;
                movePos += Vector3.right * (speed * Time.deltaTime);
                movePos.y = Mathf.PerlinNoise(movePos.x * frequency, 0) * amplitude;
                transform.position = movePos;
                break;

            case MovementMathType.Sin:
                Debug.Log("");
                movePos = transform.position;
                movePos += Vector3.right * (speed * Time.deltaTime);
                movePos.y = Mathf.Sin(movePos.x * frequency) * amplitude;  //amp
                transform.position = movePos;
                break;

            case MovementMathType.Circle:
                Debug.Log("");
                float posOnUnitCircle = Time.timeSinceLevelLoad * frequency;

                movePos.x = Mathf.Cos(posOnUnitCircle) * amplitude;
                movePos.y = Mathf.Sin(posOnUnitCircle) * amplitude;
                
                transform.position = movePos;
                break;

            default:
                Debug.Log("You have not implement movement type yet");
                break;
        }

        if (transform.position.x > 9)
        {
            movePos.x = -9;
            transform.position = movePos;
        }

        //if (currentMovementType == MovementMathType.TowardsTarget)
        //{
        //    endPos = targetTrans.position;

        //    Vector3 direction = endPos - transform.position;

        //    Debug.Log("Direction: " + direction);
        //    Debug.Log("Direction Magnitude: " + direction.magnitude);
        //    Debug.Log("Direction / Magnitude: " + direction.normalized);

        //    //these two do the same thing
        //    direction = direction.normalized;
        //    direction.Normalize();

        //    //transform.position = startPos + direction;
        //    transform.position += direction * speed * Time.deltaTime;
        //}
    }
}
