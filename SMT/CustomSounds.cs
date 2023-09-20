using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace SMT
{
    public class SoundObject : INotifyPropertyChanged
    {
        private string m_soundName;
        private string m_soundPath;
        private bool m_useDefaultSound;
        private bool m_notifyAtAnyDistance;
        private int m_distanceToNotify;
        [XmlIgnore]
        public MediaPlayer mediaPlayer;

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
            try
            {
                Uri uri = new Uri(SoundPath);
                mediaPlayer = new MediaPlayer();
                mediaPlayer.Open(uri);
            }
            catch (System.UriFormatException)
            {
                mediaPlayer = null;
                SoundPath = "";
                SoundName = "Could not find Sound";
            }
            
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
