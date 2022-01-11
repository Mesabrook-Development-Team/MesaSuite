namespace MesaSuite.SplashScreenModifiers
{
    internal interface ISplashScreenModifier
    {
        bool IsValid();

        void Modify(frmSplash splash);
    }
}
