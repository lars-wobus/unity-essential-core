using System;
using Essential.Core.Event.Interfaces;
using UnityEngine;

namespace Essential.Core.Scripts.Event.ActionTransmitter
{
    public class DownloadActionTransmitter : MonoBehaviour, IDownloadHandler
    {
        public Action<float> ProgressChanged;
        public Action DownloadComplete;
        
        public void OnProgressChanged(float value)
        {
            ProgressChanged?.Invoke(value);
        }

        public void OnComplete()
        {
            DownloadComplete?.Invoke();
        }
    }
}
