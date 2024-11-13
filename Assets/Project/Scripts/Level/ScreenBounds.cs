using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class ScreenBounds : MonoBehaviour {

    private EntityManager _entityManager;
    private Entity _screenBoundEntity;

    void Start() {
        
        _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;


        EntityQuery query = _entityManager.CreateEntityQuery(typeof(ScreenBound));
        if (query.IsEmpty) {
            _screenBoundEntity = _entityManager.CreateEntity(typeof(ScreenBound));
        } else {
            _screenBoundEntity = query.GetSingletonEntity();
        }

        UpdateScreenBounds();
    }

    void Update() {

    }

    void UpdateScreenBounds() {

        float verticalExtent = Camera.main.orthographicSize;
        float horizontalExtent = verticalExtent * Camera.main.aspect;

        float2 bounds = new float2(horizontalExtent * 2, verticalExtent * 2);

        _entityManager.SetComponentData(_screenBoundEntity, new ScreenBound { bounds = bounds });
        
    }
}


