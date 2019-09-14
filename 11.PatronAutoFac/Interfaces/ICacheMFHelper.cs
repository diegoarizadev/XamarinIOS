using System;
namespace _11.PatronAutoFac.Interfaces
{

    //interface para implementar
    public interface ICacheMFHelper
    {

        string GetToken(string scope);
        bool SaveToken(string scope);
        string GetKeyCache(string scope);
        bool DisponseSemaphore();

    }
}
