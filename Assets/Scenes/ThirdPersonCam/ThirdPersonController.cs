using UnityEngine;
/*プレイヤーキャラにこれをアタッチすること*/
[RequireComponent(typeof(Rigidbody),typeof(CharacterController),typeof(CapsuleCollider))]
public class ThirdPersonController : MonoBehaviour
{
    /// <summary>プレイヤーを追跡するカメラ</summary>
    [SerializeField, Header("プレイヤーカメラ")] GameObject _playerCamera;
    /// <summary>デバイス入力の値を保持しているクラス</summary>
    [SerializeField, Header("デバイス入力の値を保持しているクラス")] PlayerInputModule _deviceInput;
    /// <summary>カメラとプレイヤー間の距離</summary>
    [SerializeField, Range(2f, 5f), Header("カメラとプレイヤー間の距離")] float _cameraDistance;
    /// <summary>Y軸のカメラオフセット</summary>
    [SerializeField, Range(-5f, 5f), Header("カメラとプレイヤー間の距離")] float _cameraOffsetY;
    /// <summary>移動ベクトル</summary>
    Vector2 _moveInput = Vector2.zero;
    /// <summary>視点移動ベクトル</summary>
    Vector2 _lookInput = Vector2.zero;
    /// <summary>発射フラグ</summary>
    bool _isFired = false;
    /// <summary>照準フラグ</summary>
    bool _isAimed = false;
    /// <summary>ジャンプフラグ</summary>
    bool _isJumped = false;
    void Start()
    {
        
    }
    private void Update()
    {
        GetInputsVal();
        Vector3 playerForward = this.gameObject.transform.forward;
        playerForward = playerForward.normalized;
        playerForward.y = this.gameObject.transform.position.y + this._cameraOffsetY;
        playerForward.z = -(this.gameObject.transform.position.z + this._cameraDistance);
        this._playerCamera.transform.position = playerForward;
    }
    void FixedUpdate()
    {
        //入力値に応じて移動、カメラの向いている方向が正面でカメラはフリールック
    }
    private void GetInputsVal()
    {
        /*それぞれの入力値の代入*/
        this._moveInput = this._deviceInput.GetMoveInput();
        this._lookInput = this._deviceInput.GetLookInput();
        this._isFired = this._deviceInput.GetFiring();
        this._isAimed = this._deviceInput.GetAiming();
        this._isJumped = this._deviceInput.GetJumping();
        print($"M,L,F,A,J => {this._moveInput},{this._lookInput},{this._isFired},{this._isAimed},{this._isJumped}");
    }
}
