using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerSpawnPostion;
        [SerializeField] private GameObject _playerPrefab;
        
        public override void InstallBindings()
        {

        }
    }
}