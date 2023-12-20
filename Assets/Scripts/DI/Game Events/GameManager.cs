using System.Collections.Generic;

namespace KlimentiyInjector
{
    public sealed class GameManager
    {
        private readonly List<IInitializeGameListener> _initializeListeners = new();
        private readonly List<IStartGameListener> _startListeners = new();
        private readonly List<IUpdateGameListener> _updateListeners = new();
        private readonly List<IFixedUpdateGameListener> _fixedUpdateListeners = new();
        private readonly List<ILateUpdateGameListener> _lateUpdateListeners = new();
        private readonly List<IResumeGameListener> _resumeListeners = new();
        private readonly List<IPauseGameListener> _pauseListeners = new();
        private readonly List<IFinishGameListener> _finishListeners = new();

        private GameState GameState { get; set; }

        public void InstallListeners(IEnumerable<DependencyInstaller> dependencyInstallers)
        {
            foreach (var installer in dependencyInstallers)
                AddGameListeners(installer.ProvideGameListeners());
        }
        
        public void OnInitialize()
        {
            if (GameState != GameState.None) return;
            
            for (int i = 0; i < _initializeListeners.Count; i++) 
                _initializeListeners[i].OnInitialize();

            GameState = GameState.Initialized;
        }
        
        public void OnStart()
        {
            if (GameState != GameState.Initialized) return;
            
            for (int i = 0; i < _startListeners.Count; i++) 
                _startListeners[i].OnStart();

            GameState = GameState.Active;
        }

        public void OnUpdate()
        {
            if (GameState != GameState.Active) return;
            
            for (int i = 0; i < _updateListeners.Count; i++) 
                _updateListeners[i].OnUpdate();
        }

        public void OnFixedUpdate()
        {
            if (GameState != GameState.Active) return;
            
            for (int i = 0; i < _fixedUpdateListeners.Count; i++) 
                _fixedUpdateListeners[i].OnFixedUpdate();
        }

        public void OnLateUpdate()
        {
            if (GameState != GameState.Active) return;
            
            for (int i = 0; i < _lateUpdateListeners.Count; i++) 
                _lateUpdateListeners[i].OnLateUpdate();
        }
        
        public void OnResume()
        {
            if (GameState != GameState.Paused) return;
            
            for (int i = 0; i < _resumeListeners.Count; i++) 
                _resumeListeners[i].OnResume();

            GameState = GameState.Active;
        }

        public void OnPause()
        {
            if (GameState != GameState.Active) return;
            
            for (int i = 0; i < _pauseListeners.Count; i++) 
                _pauseListeners[i].OnPause();

            GameState = GameState.Paused;
        }
        
        public void OnFinish()
        {
            if (GameState == GameState.Finished) return;
            
            for (int i = 0; i < _finishListeners.Count; i++) 
                _finishListeners[i].OnFinish();

            GameState = GameState.Finished;
        }
        
        public void AddGameListeners(IEnumerable<IGameListener> listeners)
        {
            foreach (var listener in listeners)
                AddGameListener(listener);
        }
        
        public void RemoveGameListeners(IEnumerable<IGameListener> listeners)
        {
            foreach (var listener in listeners)
                RemoveGameListener(listener);
        }
        
        public void AddGameListener(IGameListener listener)
        {
            if (listener is IInitializeGameListener initializeGameListener)
                if (!_initializeListeners.Contains(initializeGameListener))
                    _initializeListeners.Add(initializeGameListener);
            
            if (listener is IStartGameListener startGameListener)
                if (!_startListeners.Contains(startGameListener))
                    _startListeners.Add(startGameListener);
            
            if (listener is IUpdateGameListener updateListener)
                if (!_updateListeners.Contains(updateListener))
                    _updateListeners.Add(updateListener);
            
            if (listener is IFixedUpdateGameListener fixedUpdateListener)
                if (!_fixedUpdateListeners.Contains(fixedUpdateListener))
                    _fixedUpdateListeners.Add(fixedUpdateListener);
            
            if (listener is ILateUpdateGameListener lateUpdateListener)
                if (!_lateUpdateListeners.Contains(lateUpdateListener))
                    _lateUpdateListeners.Add(lateUpdateListener);
            
            if (listener is IPauseGameListener pauseListener)
                if (!_pauseListeners.Contains(pauseListener))
                    _pauseListeners.Add(pauseListener);
            
            if (listener is IResumeGameListener resumeListener)
                if (!_resumeListeners.Contains(resumeListener))
                    _resumeListeners.Add(resumeListener);
            
            if (listener is IFinishGameListener finishListener)
                if (!_finishListeners.Contains(finishListener))
                    _finishListeners.Add(finishListener);
        }
        
        public void RemoveGameListener(IGameListener listener)
        {
            if (listener is IInitializeGameListener initializeGameListener)
                if (_initializeListeners.Contains(initializeGameListener))
                    _initializeListeners.Remove(initializeGameListener);
            
            if (listener is IStartGameListener startGameListener)
                if (_startListeners.Contains(startGameListener))
                    _startListeners.Remove(startGameListener);
            
            if (listener is IUpdateGameListener updateListener)
                if (_updateListeners.Contains(updateListener))
                    _updateListeners.Remove(updateListener);
            
            if (listener is IFixedUpdateGameListener fixedUpdateListener)
                if (_fixedUpdateListeners.Contains(fixedUpdateListener))
                    _fixedUpdateListeners.Remove(fixedUpdateListener);
            
            if (listener is ILateUpdateGameListener lateUpdateListener)
                if (_lateUpdateListeners.Contains(lateUpdateListener))
                    _lateUpdateListeners.Remove(lateUpdateListener);
            
            if (listener is IPauseGameListener pauseListener)
                if (_pauseListeners.Contains(pauseListener))
                    _pauseListeners.Remove(pauseListener);
            
            if (listener is IResumeGameListener resumeListener)
                if (_resumeListeners.Contains(resumeListener))
                    _resumeListeners.Remove(resumeListener);
            
            if (listener is IFinishGameListener finishListener)
                if (_finishListeners.Contains(finishListener))
                    _finishListeners.Remove(finishListener);
        }
    }
}