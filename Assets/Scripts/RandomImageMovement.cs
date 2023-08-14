using UnityEngine;

public class RandomImageMovement : MonoBehaviour
{
    public RectTransform imageTransform;
    public Vector2 moveSpeedRange = new Vector2(50f, 100f);

    //private Vector2 currentDirection;
    //private Vector2 targetDirection;
    //private Vector2 screenSize;
    //private bool changingDirection = true;

    //private void Start()
    //{
    //    screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
    //}

    //private void Update()
    //{
    //    if (changingDirection)
    //    {
    //        targetDirection = Random.insideUnitCircle.normalized;
    //        changingDirection = false;
    //    }

    //    Vector2 newPosition = imageTransform.anchoredPosition + moveSpeedRange.y * Time.deltaTime * currentDirection;
    //    imageTransform.anchoredPosition = newPosition;

    //    if (Mathf.Abs(newPosition.x) > screenSize.x ||  || Mathf.Abs(newPosition.y) > screenSize.y)
    //    {
    //        changingDirection = true;
    //    }

    //    currentDirection = Vector2.Lerp(currentDirection, targetDirection, Time.deltaTime * 0.5f);
    //}
}
