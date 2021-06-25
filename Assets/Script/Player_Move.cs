using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Move : MonoBehaviour
{
    public float Speed = 3f;

    // Update is called once per frame
    void Update()
    {
        // 매 프레임마다 메소드 호출
        Move();
    }

    // 움직이는 기능을 하는 메소드
    private void Move()
    {
        // 화면 크기를 구하고 반을 나눠서 왼쪽 혹은 오른쪽을 터치하고 있을 때 이동
        int width = Screen.width;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (width / 2 > touch.position.x)
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    transform.Translate(Vector2.left * Speed * Time.deltaTime);
            }

            if (width / 2 < touch.position.x)
            {
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    transform.Translate(Vector2.right * Speed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))  // → 방향키를 누를 때
            transform.Translate(Vector2.right * Speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))  // ← 방향키를 누를 때
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
    }
}

/*
 * 안드로이드 터치 이벤트 *
 
 Input.GetTouch(0) : 터치에 대한 정보들을 갖고 있다.

- position : 터치한 위치
- deltaPosition : 터치한 화면의 위치가 바뀐 정도
- tapCount : 연속 터치 횟수
- phase : 터치 상태를 나타내며 TouchPhase 와 비교해서 사용함

TouchPhase.Began : 터치 시작
TouchPhase.Canceled : 사용자 얼굴이 장치에 가까이 오거나 5개 이상 터치가 동시에 발생할 때
TouchPhase.Ended : 터치 끝남
TouchPhase.Moved : 누른 상태로 움직일 때
TouchPhase.Stationary : 누른 상태로 안움직일 때
*/