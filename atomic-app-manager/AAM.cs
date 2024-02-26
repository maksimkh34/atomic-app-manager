namespace atomic_app_manager
{
    internal class AAM
    {
        public static void InitRelease()
        {
            var Window = new CreateHomeDirStartup();
            Window.ShowDialog();
        }
    }
}
