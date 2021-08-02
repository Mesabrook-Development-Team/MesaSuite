using CompanyStudio.Models;
using Newtonsoft.Json.Linq;
using System;
using WeifenLuo.WinFormsUI.Docking;

namespace CompanyStudio
{
    public class BaseCompanyStudioContent : DockContent
    {
        public event EventHandler OnCompanyChange;
        public event EventHandler<ThemeBase> OnThemeChange;
        public event EventHandler OnStudioChange;
        public event EventHandler OnIsDirtyChange;

        protected StudioFormExtender studioFormExtender;

        private Company _company;
        public Company Company
        {
            get { return _company; }
            set { _company = value; OnCompanyChange?.Invoke(this, new EventArgs()); }
        }

        private ThemeBase _theme;
        public ThemeBase Theme 
        {
            protected get { return _theme; }
            set 
            {
                _theme = value;
                studioFormExtender.ApplyStyle(this, value); 
                OnThemeChange?.Invoke(this, value);
            } 
        }

        private frmStudio _frmStudio;
        public frmStudio Studio
        {
            get { return _frmStudio; }
            set { _frmStudio = value; OnStudioChange?.Invoke(this, new EventArgs()); }
        }

        private bool _isDirty;
        public bool IsDirty
        {
            get { return _isDirty; }
            protected set
            {
                _isDirty = value;

                if (IsDirty && !Text.StartsWith("*"))
                {
                    Text = $"*{Text}";
                }
                else if (!IsDirty && Text.StartsWith("*"))
                {
                    Text = Text.Substring(1);
                }

                OnIsDirtyChange?.Invoke(this, new EventArgs());
            }
        }

        public BaseCompanyStudioContent()
        {
            studioFormExtender = new StudioFormExtender();
        }

        protected sealed override string GetPersistString()
        {
            JObject persistObject = new JObject();
            persistObject.Add("type", GetType().ToString());

            if (Company != null)
            {
                persistObject.Add("company", JObject.FromObject(Company));
            }

            JObject customPersistObject = GetPersistObject();
            if (customPersistObject != null)
            {
                persistObject.Add("custom", customPersistObject);
            }

            return persistObject.ToString();
        }

        public void HandlePersistString(string persistString)
        {
            JObject persistObject = JObject.Parse(persistString);
            Company = persistObject.GetValue("company")?.Value<JObject>().ToObject<Company>();
            JObject customPersistObject = persistObject.GetValue("custom")?.Value<JObject>();

            if (customPersistObject != null)
            {
                HandlePersistObject(persistObject);
            }
        }

        protected virtual JObject GetPersistObject()
        {
            return null;
        }

        protected virtual void HandlePersistObject(JObject value) { }
    }
}
