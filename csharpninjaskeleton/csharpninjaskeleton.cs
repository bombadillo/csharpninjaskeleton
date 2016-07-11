namespace CsharpNinjaSkeleton
{
    using Interfaces;

    class Csharpninjaskeleton
    {
        static void Main(string[] args)
        {
            CompositionRoot.Wire(new ApplicationModule());

            var app = CompositionRoot.Resolve<IApp>();

            app.Run();
        }
    }
}
