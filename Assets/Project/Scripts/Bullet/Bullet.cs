using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour {
    
    private GameBound _gameBound;
    private Vector3 _shootDir;
    private float _moveSpeed;
    public float MoveSpeed { set { _moveSpeed = value; } }

    public void Setup(Vector3 shootDir) {

        this._shootDir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));

    }

    private void Start() {
        _gameBound = FindAnyObjectByType<GameBound>();
    }
    private void Update() {
        if (IsNotInGameField(transform.position)) {
            Destroy(this.gameObject);
        }
        transform.position += _shootDir * _moveSpeed * Time.deltaTime;
    }


    bool IsNotInGameField(Vector3 position) {

        return position.x < _gameBound.GameAreaMinX - 10f || position.x > _gameBound.GameAreaMaxX + 10f || position.y < _gameBound.GameAreaMinY - 10f || position.y > _gameBound.GameAreaMaxY + 10f;

    }

    public static float GetAngleFromVectorFloat(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    public static int GetAngleFromVector(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        int angle = Mathf.RoundToInt(n);

        return angle;
    }

    public static int GetAngleFromVector180(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        int angle = Mathf.RoundToInt(n);

        return angle;
    }

    public static Vector3 ApplyRotationToVector(Vector3 vec, Vector3 vecRotation) {
        return ApplyRotationToVector(vec, GetAngleFromVectorFloat(vecRotation));
    }

    public static Vector3 ApplyRotationToVector(Vector3 vec, float angle) {
        return Quaternion.Euler(0, 0, angle) * vec;
    }

    public static Vector3 GetRandomDir() {
        return new Vector3(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }


    public static Vector3 GetVectorFromAngle(int angle) {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static Vector3 GetVectorFromAngle(float angle) {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static Vector3 GetVectorFromAngleInt(int angle) {
        // angle = 0 -> 360
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }
}
