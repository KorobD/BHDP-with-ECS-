using UnityEngine;
using Unity.Mathematics;
using Unity.Entities;

namespace PN {

    public static class Shots {

        public static void SimpleShoot(EntityManager entityManager, Entity entityPrefab, float speed, float moveDir = -90) {

            SpawnBullet(entityManager, entityPrefab, speed, moveDir);
        }

        public static void SpreadShot(EntityManager entityManager, Entity entityPrefab, int numberOfBullets, float speed, float spreadAngle, float moveDir = -90) {

            float angleStep = spreadAngle / (numberOfBullets - 1);
            float startAngle = moveDir - (spreadAngle / 2);
            for (int i = 0; i < numberOfBullets; i++) {
                float currentAngle = startAngle + (i * angleStep);
                SpawnBullet(entityManager, entityPrefab, speed, currentAngle);
            }

        }

        public static void CircleShoot(EntityManager entityManager, Entity entityPrefab, int numberOfBullets, float speed) {

            float angleStep = 360 / numberOfBullets;
            for (int i = 0; i < numberOfBullets; i++) {
                float currentAngle = i * angleStep;
                SpawnBullet(entityManager, entityPrefab, speed, currentAngle);
            }

        }

        public static void SpiralShoot(EntityManager entityManager, Entity entityPrefab, int numberOfBullets, float speed, float currentAngle) {

            float angleStep = 360f / numberOfBullets;
            for (int i = 0; i < numberOfBullets; i++) {
                float angle = currentAngle + (i * angleStep);
                SpawnBullet(entityManager, entityPrefab, speed, angle);
            }

        }

        public static float3 GetFloat3FromAngle(float angle) {
            float angleRad = angle * (Mathf.PI / 180f);
            return new float3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0);
        }

        public static float3 GetDirectionToPlayer(float3 playerPosition, float3 startPosition) {
            float3 direction = playerPosition - startPosition;
            return math.normalize(direction);
        }

        public static void SpawnBullet(EntityManager entityManager, Entity entityPrefab, float speed, float moveDir) {

            Entity bullet = entityManager.Instantiate(entityPrefab);

            entityManager.SetComponentData(bullet, new Movement {

                moveDir = math.normalize(GetFloat3FromAngle(moveDir)),
                moveSpeed = speed
            });
        }

    }

}
