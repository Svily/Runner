using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = System.Diagnostics.Debug;

public class PlayerController : MonoBehaviour
{
    //初始移动速度
    public float MoveSpeed = 8f;
    //横向移动距离
    public float HSpeed = 2.5f;
    //跳跃高度
    public float JumpHeight = 2f;
    //角色控制器
    public CharacterController Cc;
    //移动增量
    public Vector3 MoveIncrements;
    //
    public float time = 0f;
    //
    public float timer;
    //动画状态机
    public Animator Animator;
    //动画运作状态机
    public RuntimeAnimatorController RAC;
    //是否正在跳跃
    public bool IsJump = false;
    //是否能移动
    public bool CanMove = true;
    //是否处于冲刺状态
    public bool Endure = false;
    //冲刺计时器
    public float EndureTime = 0f;
    //跳跃所花时间
    public float JumpTime = 0.60f;


    void Start()
    {

        //初始化组件
        InitCompoent();


    }


    void Update()
    {
        //检测人物是否可以移动
        if (CanMove)
        {
            PlayerMove();
        }

        //检测人物是否死亡
        PlayerDropDead();
        //检测人物是否为冲刺状态
        IsEndure();

    }

    /// <summary>
    /// 初始化组件
    /// </summary>
    void InitCompoent()
    {
        Cc = this.transform.GetComponent<CharacterController>();

        Animator = this.transform.GetComponent<Animator>();

        RAC = Animator.runtimeAnimatorController;
    }

    /// <summary>
    /// 人物移动控制
    /// </summary>
    void PlayerMove()
    {
        
        //限制速度上限，每帧增加速度
        if (MoveSpeed <= 45f)
        {
            MoveSpeed += Time.deltaTime * 0.1f;
        }


        //前进方向移动增量
        MoveIncrements = transform.forward * MoveSpeed * Time.deltaTime;

        //PC端操作

        //水平位移
        float moveDir = Input.GetAxis("Horizontal");
        //水平以及跳跃
        MoveIncrements += transform.right * HSpeed * Time.deltaTime * moveDir;

        //S键触发跳跃
        if (Input.GetKeyDown(KeyCode.S) && Cc.isGrounded)
        {

            Animator.SetBool("Jump", true);
            IsJump = true;
            Invoke("JumpEnd", 0.35f);


        }

        //PC端跳跃
        /*if (IsJump)
        {

            MoveIncrements.y = JumpHeight * Time.deltaTime;

        }
        else
        {

            MoveIncrements.y += Cc.isGrounded ? 0f : -5.0f * Time.deltaTime * 1f;

        }*/


        //人物移动
        Cc.Move(MoveIncrements);





    }

    /// <summary>
    /// 跳跃开始
    /// </summary>
    public void Jump()
    {
        //切换动画
        Animator.SetBool("Jump", true);
        IsJump = true;
        //结束动画
        Invoke("JumpEnd",JumpTime);
    }

    /// <summary>
    /// 跳跃结束
    /// </summary>
    void JumpEnd()
    {
        Animator.SetBool("Jump", false);
        IsJump = false;
    }

    /// <summary>
    /// 检测人物是否因掉落死亡
    /// </summary>
    void PlayerDropDead()
    {
        if (this.transform.position.y < -1)
        {
            CanMove = false;
            Animator.SetBool("Dead", true);
            Invoke("GameOver", 2f);
        }
    }

    /// <summary>
    /// 检测人物是否撞死
    /// </summary>
    void PlayerColliderDead()
    {
        CanMove = false;
        GameObject.Find ("Controller").active = false;
        Animator.SetBool("Dead", true);
        Invoke("GameOver",2f);
    }

    /// <summary>
    /// 监听碰撞事件
    /// </summary>
    /// <param name="hit"></param>
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //撞到不可破坏障碍物 人物死亡
        if (hit.gameObject.tag == "Bar")
        {

            PlayerColliderDead();

        }

        //撞到可破坏障碍物
        if (hit.gameObject.tag == "CanDestroyBars")
        {
            //是否处于冲刺状态
            if (Endure)
            {
                //破坏障碍物
                hit.transform.SendMessage("Hit");
            }
            else
            {
                //人物死亡
                PlayerColliderDead();
            }
        }
    }



    //加速
    void AccelateSpeed()
    {

        MoveSpeed += 2f;

    }

    //减速
    void DecelateSpeed()
    {

        if (MoveSpeed > 5f)
        {
            MoveSpeed -= 2f;
        }

        if (MoveSpeed < 5f)
        {
            MoveSpeed = 5f;
        }


    }

    /// <summary>
    /// 是否处于冲刺状态
    /// </summary>
    void IsEndure()
    {

        EndureTime -= Time.deltaTime;

        if (EndureTime<=0f)
        {
            CantDestroyBars();
        }

    }

    /// <summary>
    /// 开启可破坏障碍物
    /// </summary>
    void CanDestroyBars()
    {
        this.Endure = true;

        EndureTime = 10f;
    }

    /// <summary>
    /// 关闭可破坏障碍物
    /// </summary>
    void CantDestroyBars()
    {
        this.Endure = false;
    }

    /// <summary>
    /// 人物死亡，跳转场景
    /// </summary>
    void GameOver()
    {
        SceneManager.LoadScene("Over");
    }
}
