using System.Reflection;

namespace TMS_Nineth_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConcatStringMembers(new Car()));
        }

        public static string ConcatStringMembers(object TestObject)
        {
            if(TestObject == null)
            {
                return string.Empty;
            }

            var type = TestObject.GetType();
            var flags = BindingFlags.Public
                | BindingFlags.Instance
                | BindingFlags.NonPublic
                | BindingFlags.DeclaredOnly;

            var methods = type.GetMethods(flags);
            var fields = type.GetFields(flags);
            var properties = type.GetProperties(flags);

            var superRes = new List<string>();

            foreach (var field in fields) 
            {
                if (field.FieldType != typeof(string))
                {
                    continue;
                }
                superRes.Add(field.GetValue(TestObject)?.ToString() ?? string.Empty);
            }
            
            foreach (var property in properties)
            {
                if (property.PropertyType != typeof(string))
                {
                    continue;
                }
                superRes.Add(property.GetValue(TestObject)?.ToString() ?? string.Empty);
            }

            foreach (var method in methods)
            {
                if (method.ReturnType != typeof(string) || method.GetParameters().Length != 0)
                {
                    continue;
                }
                superRes.Add(method.Invoke(TestObject, new object[0])?.ToString() ?? string.Empty);
            }

            superRes = superRes.OrderByDescending(r => r.Length).ThenBy(r => r).ToList();
            var res = string.Join(string.Empty, superRes);

            return res;
        }
    }
    class Car
    {
        public string name = "LCREQPSN ICAYLXJO PPGCKMMC LQLUOFB UTWBPOF UEVWNJK PSAVXJ MH2";
        public string name1 = "LCREQPSN ICAYsadasfagfsdagsgdasgsadgdgdasgSAVXJ MH2";
        public int age = 10;

        private void Move()
        {

        }
        public void NextStep()
        {

        }
    }
}