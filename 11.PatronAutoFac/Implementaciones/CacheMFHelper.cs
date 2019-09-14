using System;
using _11.PatronAutoFac.Interfaces;

namespace _11.PatronAutoFac.Implementaciones
{
    public class CacheMFHelper : ICacheMFHelper
    {
        public CacheMFHelper()
        {
        }

        public bool DisponseSemaphore()
        {

            Console.WriteLine("N0rf3n - DisponseSemaphore - Begin/End ");
            return true;
            
        }

        public string GetKeyCache(string scope)
        {
            Console.WriteLine("N0rf3n - GetKeyCache - Begin");

            Console.WriteLine("N0rf3n - GetKeyCache - scope : "+ scope);

            return "Hi! N0rf3n - GetKeyCache + " + scope;
        }

        public string GetToken(string scope)
        {
            Console.WriteLine("N0rf3n - GetToken - Begin");

            Console.WriteLine("N0rf3n - GetToken - scope : " + scope);

            return "Hi! N0rf3n - GetToken + " + scope;
        }

        public bool SaveToken(string scope)
        {
            Console.WriteLine("N0rf3n - SaveToken - Begin");

            Console.WriteLine("N0rf3n - SaveToken - scope : " + scope);

            return false;
        }
    }
}
