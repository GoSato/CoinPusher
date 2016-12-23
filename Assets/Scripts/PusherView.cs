using UnityEngine;
using System.Collections;

public class PusherView : MonoBehaviour {

    [Header("前後の最大移動量")]
    [SerializeField]
    private float _maxMoveDistance;

    [SerializeField]
    private float _moveSpeed;

    private Transform _cachedTrans;
    private Vector3 _startPos;
    private Rigidbody _rigid;

	void Start () {
        _cachedTrans = gameObject.transform;
        _startPos = _cachedTrans.position;
        _rigid = gameObject.GetComponent<Rigidbody>();
	}

    private int _direction = 1; // 移動方向
    private Vector3 _amount = Vector3.zero;

    void FixedUpdate()
    {
        if (_cachedTrans.position.z > _startPos.z + _maxMoveDistance)
        {
            _direction = -1;
        }
        else if(_cachedTrans.position.z < _startPos.z - _maxMoveDistance)
        {
            _direction = 1;
        }

        _amount += _cachedTrans.forward * _moveSpeed * Time.deltaTime * _direction;
        _rigid.MovePosition(_startPos + _amount);
    }
}
