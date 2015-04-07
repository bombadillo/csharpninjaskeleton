namespace LaserAndCrmAddressAnalysis
{
    using Interfaces;

    class LaserAndCrmAddressAnalysis
    {
        static void Main(string[] args)
        {
            CompositionRoot.Wire(new ApplicationModule());

            var app = CompositionRoot.Resolve<IApp>();

            app.Run();
        }
    }
}
