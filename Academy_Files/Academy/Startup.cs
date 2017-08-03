using Academy.Core;
using System.Globalization;

namespace Academy
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            // Singleton design pattern
            // Ensures that there is only one instance of Engine in existance
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            var engine = Engine.Instance;
            engine.Start();
        }
    }
}
