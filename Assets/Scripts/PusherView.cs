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

	void Start () {
        _cachedTrans = gameObject.transform;
        _startPos = _cachedTrans.position;
	}

    private int _direction = 1;

    void Update()
    {
        if (_cachedTrans.position.z > _startPos.z + _maxMoveDistance)
        {
            _direction = -1;
        }
        else if(_cachedTrans.position.z < _startPos.z - _maxMoveDistance)
        {
            _direction = 1;
        }

         _cachedTrans.position += _cachedTrans.forward * _moveSpeed * Time.deltaTime * _direction;
    }
}
