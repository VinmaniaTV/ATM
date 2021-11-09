using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public interface IClientDataAccess
    {
        void GetAll() { }
        void CreateClient(Guid _id, int _pin, string _FirstName, string _LastName, float _ammount, List<string> currency, List<float> currency_ammount, string maincurrency) { }
        void GetClient(Guid guid) { }
        void UpdateClientString(Guid guid, string nom_attribut, string i) { }
        void UpdateClientInt(Guid guid, string nom_attribut, int i) { }
        void UpdateClientFloat(Guid g, string nom_attribut, float i) { }
        void UpdateCurrencyString(Guid c, string nom_attribut, string nom_attribut_id, string i) { }
        void UpdateCurrencyFloat(Guid c, string nom_attribut, string nom_attribut_id, float i) { }
        void DeleteClient(Guid guid) { }  
    }
}
