using DapperExtensions;

namespace Ryan.Repository.Utility
{
    public static class Extension
    {
        public static void AddPredicate(this PredicateGroup predicateGroup, bool conditon, IPredicate predicate)
        {
            if (conditon)
            {
                predicateGroup.Predicates.Add(predicate);
            }
        }
    }
}