using Ryan.DomainModel;
using Ryan.DomainModel.Ryan;

namespace Ryan.Repository
{
    public class RyanRepository : IRyanRepository
    {
        public string Hello()
        {
            return "Hello from ryan";
        }
    }
}