using Ryan.Model;

namespace Ryan.Application
{
    public class RyanApplication
    {
        private readonly IRyanRepository _ryanRepository;

        public RyanApplication(IRyanRepository ryanRepository)
        {
            _ryanRepository = ryanRepository;
        }

        public string Hello()
        {
            return _ryanRepository.Hello();
        }
    }
}