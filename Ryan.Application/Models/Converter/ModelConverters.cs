using AutoMapper;
using Ryan.DomainModel;
using Ryan.DomainModel.Ryan;

namespace Ryan.Application.Models.Converter
{
    public static class ModelConverters
    {
        public static Ball ToBall(this BallEntity model)
        {
          return  Mapper.Map<Ball>(model);
        }
    }
}