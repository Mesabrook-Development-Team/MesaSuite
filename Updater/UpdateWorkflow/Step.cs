using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Updater.UpdateWorkflow
{
    public abstract class Step
    {
        public InstallationConfiguration InstallationConfiguration { get; set; }

        public event EventHandler PreviousAvailableChanged;
        public event EventHandler NextAvailableChanged;
        public event EventHandler CancelAvailableChanged;
        public event EventHandler BannerChanged;

        private bool _previousAvailable = true;
        public bool PreviousAvailable
        {
            get { return _previousAvailable; }
            protected set
            {
                _previousAvailable = value;
                PreviousAvailableChanged?.Invoke(this, new EventArgs());
            }
        }

        private bool _nextAvailable = true;
        public bool NextAvailable
        {
            get { return _nextAvailable; }
            protected set
            {
                _nextAvailable = value;
                NextAvailableChanged?.Invoke(this, new EventArgs());
            }
        }

        private bool _cancelAvailable = true;
        public bool CancelAvailable
        {
            get { return _cancelAvailable; }
            protected set
            {
                _cancelAvailable = value;
                CancelAvailableChanged?.Invoke(this, new EventArgs());
            }
        }

        private Bitmap _banner;
        public Bitmap Banner
        {
            get { return _banner; }
            protected set
            {
                _banner = value;
                BannerChanged?.Invoke(this, new EventArgs());
            }
        }

        public Step()
        {
            Banner = GetInitialBanner();
        }

        public virtual bool IsPreviousStop { get; } = true;

        public async virtual Task<bool> NextClicked() { return true; }
        public async virtual Task<bool> PreviousClicked() { return true; }
        public async virtual Task CancelClicked() {  }
        public async virtual Task<bool> LoadAndAutoComplete() { return false; }

        public abstract IStepUserControl StepUserControl { get; }
        protected abstract Bitmap GetInitialBanner();
    }
}
