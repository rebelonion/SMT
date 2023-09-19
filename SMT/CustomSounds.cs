using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SMT
{
    public class SoundObject : INotifyPropertyChanged
    {
        private string m_soundName;
        private string m_soundPath;
        private bool m_isEnabled;
        private bool m_useDefaultSound;
        private bool m_notifyAtAnyDistance;
        private int m_distanceToNotify;

        private MediaPlayer mediaPlayer;

        public string SoundName
        {
            get => m_soundName;
            set
            {
                if (m_soundName != value)
                {
                    m_soundName = value;
                    OnPropertyChanged(nameof(SoundName));
                }
            }
        }
        public string SoundPath
        {
            get => m_soundPath;
            set
            {
                if (m_soundPath != value)
                {
                    m_soundPath = value;
                    OpenSound();
                    OnPropertyChanged(nameof(SoundPath));
                }
            }
        }
        public bool IsEnabled
        {
            get => m_isEnabled;
            set
            {
                if (m_isEnabled != value)
                {
                    m_isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }
        public bool UseDefaultSound
        {
            get => m_useDefaultSound;
            set
            {
                m_useDefaultSound = value;
                OnPropertyChanged(nameof(UseDefaultSound));
            }
        }
        public bool NotifyAtAnyDistance
        { 
            get => m_notifyAtAnyDistance;
            set
            {
                m_notifyAtAnyDistance = value;
                OnPropertyChanged(nameof(NotifyAtAnyDistance));
            }
        }
        public int DistanceToNotify
        {
            get => m_distanceToNotify;
            set
            {
                if (m_distanceToNotify != value)
                {
                    m_distanceToNotify = value;
                    OnPropertyChanged(nameof(DistanceToNotify));
                }
            }
        }

        private void OpenSound()
        {
            Uri uri = new Uri(SoundPath);
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(uri);
            mediaPlayer.Play();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
