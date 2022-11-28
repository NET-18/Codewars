using System.Diagnostics;
using System.Runtime.Serialization.Json;
using System.Security.Principal;
using System.Text;

namespace TMS_Eigth_App
{
    internal class Program
    {
        public void Main(string[] args)
        {
            var type = typeof(Car);

            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                Console.WriteLine(method);
            }
        }
    }

    class Car
    {
        private void Speed()
        {
            
        }
        protected void KmMove()
        {
            
        }
        public void CarName()
        {

        } 

        public Car()
        {

        }
    }
}