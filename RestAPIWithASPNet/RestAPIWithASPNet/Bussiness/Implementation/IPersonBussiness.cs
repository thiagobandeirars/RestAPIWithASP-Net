using System.Collections.Generic;
using RestAPIWithASPNet.Model;

namespace RestAPIWithASPNet.Bussiness.Implementation
{
    public interface IPersonBussiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long ig);
    }
}
