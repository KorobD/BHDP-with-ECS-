using UnityEngine;
using PN;


public class WeaponEnemy : MonoBehaviour {

    [SerializeField] private GameObject _bullet0;
    [SerializeField] private GameObject _bullet1;
    [SerializeField] private GameObject _bullet2;
    [SerializeField] private GameObject _bullet3;
    [SerializeField] private GameObject _bullet4;
    [SerializeField] private GameObject _bullet5;
    [SerializeField] private GameObject _bullet6;

    [SerializeField] private Transform _weaponPos;

    private GameObject _player;
    private float _timer;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update() {

        Shot(0.3f);

    }


    private void Shot(float fireRate) {

        _timer += Time.deltaTime;
        if (_timer > fireRate) {


            //      ---Shot functions---

            //float currentAngle = Time.time * 20;
            //PN.Shots.SpiralShoot(_bullet0, _weaponPos.position, 20, 20f, currentAngle);

            //float currentAngle1 = Time.time * 25;
            //PN.Shots.SpiralShoot(_bullet1, _weaponPos.position, 25, 25f, currentAngle1 * -1);

            //float currentAngle2 = Time.time * 30;
            //PN.Shots.SpiralShoot(_bullet2, _weaponPos.position, 30, 30f, currentAngle2);

            //float currentAngle3 = Time.time * 35;
            //PN.Shots.SpiralShoot(_bullet3, _weaponPos.position, 35, 35f, currentAngle3 * -1);

            //float currentAngle4 = Time.time * 40;
            //PN.Shots.SpiralShoot(_bullet4, _weaponPos.position, 40, 40f, currentAngle4);

            //float currentAngle5 = Time.time * 45;
            //PN.Shots.SpiralShoot(_bullet5, _weaponPos.position, 45, 45f, currentAngle5 * -1);

            //float currentAngle6 = Time.time * 50;
            //PN.Shots.SpiralShoot(_bullet6, _weaponPos.position, 50, 50f, currentAngle6);

            //PN.Shots.SimpleShoot(_bullet, _weaponPos.position, 20f);

            //PN.Shots.CircleShoot(_bullet4, _weaponPos.position, 36, 5f);

            //PN.Shots.SpreadShot(_bullet, _weaponPos.position, 5, 8f, 30f);

            //      --------------------


            _timer = 0f;
        }

    }

}
