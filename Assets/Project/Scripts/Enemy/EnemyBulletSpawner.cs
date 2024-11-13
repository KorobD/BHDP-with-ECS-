using UnityEngine;
using Unity.Transforms;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Entities;
using Unity.Burst;
using PN;
using NUnit.Framework.Internal;


[BurstCompile]
public class EnemyBulletSpawner : MonoBehaviour {
    
    public GameObject bulletPrefab0;
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;
    public GameObject bulletPrefab3;
    public GameObject bulletPrefab4;
    public GameObject bulletPrefab5;
    public GameObject bulletPrefab6;

    [SerializeField] private Transform _weapon;
    private float _timer;

    private EntityManager _entityManager;
    private Entity _bulletEntityPrefab0;
    private Entity _bulletEntityPrefab1;
    private Entity _bulletEntityPrefab2;
    private Entity _bulletEntityPrefab3;
    private Entity _bulletEntityPrefab4;
    private Entity _bulletEntityPrefab5;
    private Entity _bulletEntityPrefab6;

    private void Start() {

        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityQuery query = new EntityQueryBuilder(Allocator.Temp).WithAll<Directory>().Build(_entityManager);
        if (query.HasSingleton<Directory>()) {
            _bulletEntityPrefab0 = query.GetSingleton<Directory>().bulletPrefab0;
            _bulletEntityPrefab1 = query.GetSingleton<Directory>().bulletPrefab1;
            _bulletEntityPrefab2 = query.GetSingleton<Directory>().bulletPrefab2;
            _bulletEntityPrefab3 = query.GetSingleton<Directory>().bulletPrefab3;
            _bulletEntityPrefab4 = query.GetSingleton<Directory>().bulletPrefab4;
            _bulletEntityPrefab5 = query.GetSingleton<Directory>().bulletPrefab5;
            _bulletEntityPrefab6 = query.GetSingleton<Directory>().bulletPrefab6;
        }
    }

    public void Update() {

        Shot(0.1f);
    }

    [BurstCompile]
    private void Shot(float fireRate) {

        _timer += Time.deltaTime;

        if (_timer > fireRate) {

            //      ---Shot functions---

            //test
            float currentAngle1 = Time.time * 20f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab0, 20, 20f, currentAngle1);
            float currentAngle2 = Time.time * 25f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab1, 25, 25f, currentAngle2 * -1);
            float currentAngle3 = Time.time * 30f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab2, 30, 30f, currentAngle3);
            float currentAngle4 = Time.time * 35f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab3, 35, 35f, currentAngle4 * -1);
            float currentAngle5 = Time.time * 40f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab4, 40, 40f, currentAngle5);
            float currentAngle6 = Time.time * 45f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab5, 45, 45f, currentAngle6 * -1);
            float currentAngle7 = Time.time * 50f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab6, 50, 50f, currentAngle7);
            float currentAngle8 = Time.time * 55f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab0, 55, 55f, currentAngle8 * -1);
            float currentAngle9 = Time.time * 60f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab1, 60, 60f, currentAngle9);
            float currentAngle10 = Time.time * 65f;
            PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab2, 65, 65f, currentAngle10 * -1);
            //---

            //PN.Shots.SimpleShoot(_entityManager,_bulletEntityPrefab, 5f);
            //PN.Shots.SpreadShot(_entityManager, _bulletEntityPrefab, 5, 8f, 30f);
            //PN.Shots.CircleShoot(_entityManager, _bulletEntityPrefab, 36, 5f);

            //float currentAngle = Time.time * 20f;
            //PN.Shots.SpiralShoot(_entityManager, _bulletEntityPrefab, 20, 20f, currentAngle);
            //      --------------------

            _timer = 0f;
        }
    }
}
