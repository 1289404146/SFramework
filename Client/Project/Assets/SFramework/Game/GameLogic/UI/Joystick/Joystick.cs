using UnityEngine.UI;

using System;

using UnityEngine;

/// <summary>

/// 虚拟摇杆具体的相关事件，相关操作

/// </summary>

public class Joystick : MonoBehaviour
{

    //事件

    public Action OnTouchDown;

    public Action<JoystickData> OnTouchMove;
    public Action<float, float> OnTouchRotate;

    public Action OnTouchUp;

    //Untiy 指定参数

    public GameObject joystick;//移动对象

    public float joystickRadius = 150.0f;//移动半径（UGUI像素）

    public Rect touchArea = new Rect(0, 0, 1f, 1f);//0~1

    //data

    public JoystickData data = new JoystickData();

    private Vector3 touchOrigin;//按下原点（Input.mousePosition）

    private float scaleFactor;//Screen 2 Canvas 的转换因子

    private Transform self;

    private Vector3 selfDefaultPosition;

    private Vector3 joystickDefaultLocalPos;//control的默认位置

    private bool isStarted = false;

    private bool isOnArea = false;//是否点击在区域上

    private bool isDragged = false;//是否正在拖拽

    public bool m_enabled = true;//false = 看得见，无法操作

    public bool m_visible = true;//false = 看不见，可以操作

    public bool locked = false;//锁定self位置

    // Use this for initialization

    void Start()

    {

        self = transform;

        selfDefaultPosition = self.position;


        //获取转换系数

        Canvas canvas = joystick.GetComponentInParent<Canvas>();

        scaleFactor = canvas.scaleFactor;

        //转换touchArea

        if (touchArea.width > 1 || touchArea.height > 1)

        {

            touchArea.x = touchArea.x * scaleFactor / Screen.width;

            touchArea.y = touchArea.y * scaleFactor / Screen.height;

            touchArea.width = touchArea.width * scaleFactor / Screen.width;

            touchArea.height = touchArea.height * scaleFactor / Screen.height;

        }

        joystickDefaultLocalPos = joystick.transform.localPosition;

        isStarted = true;

        enabled = m_enabled;

        visible = m_visible;

    }

    public void OnDisable()

    {

        if (isStarted)

            Reset();

    }

    // Update is called once per frame

    void Update()
    {
        horizontal = joystick.transform.localPosition.x;
        vertical = joystick.transform.localPosition.y;
        if (!m_enabled)

            return;

        //按下

        if (Input.GetMouseButtonDown(0))

        {

            TouchDown();
        }

        //拖动

        if (Input.GetMouseButton(0))

        {

            TouchMove();

        }

        //放开

        if (Input.GetMouseButtonUp(0))

        {

            TouchUp();
            JoystickManager.Ins.animator.SetInteger("PlayerAnim", (int)PlayerAnim.Idle);
        }

    }

    private void TouchDown()

    {

        Vector3 touchPosition = Input.mousePosition;
        if (touchPosition.x > 400 || touchPosition.y > 400)
            return;
        Vector2 touchScreen = new Vector2(

            touchPosition.x / Screen.width, touchPosition.y / Screen.height);

        isOnArea = touchArea.Contains(touchScreen);
        JoystickManager.Ins.animator.SetInteger("PlayerAnim", (int)PlayerAnim.Wolk);

        if (!isOnArea)

            return;

        if (!locked)

        {

            touchOrigin = touchPosition;

            self.position = touchOrigin;

        }

        else

        {

            touchOrigin = joystick.transform.position;

        }

        if (OnTouchDown != null)

            OnTouchDown();

    }

    private void TouchMove()

    {

        if (!isOnArea)

            return;

        Vector3 origin = touchOrigin / scaleFactor;

        Vector3 now = Input.mousePosition / scaleFactor;

        float distance = Vector3.Distance(now, origin);

        if (distance < 0.01f)

            return;
        if (distance > 100)
        {
            JoystickManager.Ins.animator.SetInteger("PlayerAnim", (int)PlayerAnim.Run);
        }
        else
        {
            JoystickManager.Ins.animator.SetInteger("PlayerAnim", (int)PlayerAnim.Wolk);
        }
        isDragged = true;

        Vector3 direction = now - origin;

        float radians = Mathf.Atan2(direction.y, direction.x);

        //移动摇杆

        if (joystick != null)

        {

            if (distance > joystickRadius)

                distance = joystickRadius;

            float mx = Mathf.Cos(radians) * distance;

            float my = Mathf.Sin(radians) * distance;

            Vector3 uiPos = joystickDefaultLocalPos;

            uiPos.x += mx;

            uiPos.y += my;

            joystick.transform.localPosition = uiPos;

        }

        //派发事件

        if (OnTouchMove != null)

        {

            data.power = distance / joystickRadius;

            data.radians = radians;

            data.angle = radians * Mathf.Rad2Deg;

            data.angle360 = data.angle < 0 ? 360 + data.angle : data.angle;

            OnTouchMove(data);

        }
        if (OnTouchRotate != null)
        {
            OnTouchRotate(horizontal, vertical);
        }

    }

    private void TouchUp()

    {

        isOnArea = false;

        isDragged = false;

        ReplaceImmediate();

        if (OnTouchUp != null)

            OnTouchUp();

    }

    /// <summary>

    /// 重置状态

    /// </summary>

    public void Reset()

    {

        isOnArea = false;

        isDragged = false;

        ReplaceImmediate();

    }

    /// <summary>

    /// 立即复位

    /// </summary>

    public void ReplaceImmediate()

    {

        if (!locked)

            self.position = selfDefaultPosition;

        joystick.transform.localPosition = joystickDefaultLocalPos;

    }

    /// <summary>

    /// 启用开关（SetActive是彻底看不见，这个是看得见但是无法操作）

    /// </summary>

    public bool enabled

    {

        get { return m_enabled; }

        set

        {

            m_enabled = value;

            if (isStarted)

            {

                Reset();

            }

        }

    }

    public bool visible

    {

        get { return m_visible; }

        set

        {

            m_visible = value;

            if (isStarted)

            {

                self.GetComponent<Image>().enabled = m_visible;

                joystick.GetComponent<Image>().enabled = m_visible;

            }

        }

    }
    public float horizontal { get; private set; }
    public float vertical { get; private set; }
}