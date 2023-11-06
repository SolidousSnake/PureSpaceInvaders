using NTC.Pool;
using UnityEngine;

namespace Code.Core.Factories
{
    public abstract class Factory<T> where T : MonoBehaviour
    {
        private readonly T _prefab;

        private readonly NightGameObjectPool _parent;

        public Factory(T prefab)
        {
            _prefab = prefab;
            _parent = NightPool.GetPoolByPrefab(_prefab.gameObject);
        }

        public T CreateObject()
        {
            T obj = NightPool.Spawn(_prefab, _parent.transform);

            return obj;
        }

        public T CreateObject(Transform spawnPoint)
        {
            T obj = NightPool.Spawn(_prefab, spawnPoint.position, spawnPoint.rotation, _parent.transform);

            return obj;
        }

        public T CreateObject(Vector3 spawnPoint)
        {
            T obj = NightPool.Spawn(_prefab, spawnPoint, Quaternion.identity);
            obj.transform.SetParent(_parent.transform);

            return obj;
        }
    }
}