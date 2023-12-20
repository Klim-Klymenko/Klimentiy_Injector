﻿using System.Collections.Generic;
using UnityEngine;

namespace KlimentiyInjector
{
    public sealed class Context : MonoBehaviour
    {
        [SerializeField]
        private DependencyInstaller[] _installers;
        
        private DependencyAssembler _dependencyAssembler;
        private readonly ServiceLocator _serviceLocator = new();
        private readonly DependencyInjector _dependencyInjector = new();
        private readonly GameManager _gameManager = new();

        private void Awake()
        {
            _dependencyAssembler = new(_serviceLocator, _dependencyInjector);

            SystemInstallablesArgs args = new SystemInstallablesArgs
            {
                DependencyAssembler = _dependencyAssembler,
                GameManager = _gameManager
            };
            _serviceLocator.InstallServices(args, _installers);
            
            _gameManager.InstallListeners(_installers);
            _gameManager.OnInitialize();
        }

        private void Start()
        {
            _dependencyAssembler.Inject(_installers);
            
            _gameManager.OnStart();
        }

        private void Update() => _gameManager.OnUpdate();

        private void FixedUpdate() => _gameManager.OnFixedUpdate();

        private void LateUpdate() => _gameManager.OnLateUpdate();
        
        private void OnDestroy() => _gameManager.OnFinish();
    }
}