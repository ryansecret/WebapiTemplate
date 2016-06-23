using AutoMapper;
using Ryan.Model;

namespace Ryan.Application.Models.Converter
{
    public static class Converters
    {
        public static Ball ToBall(this BallEntity model)
        {
          return  Mapper.Map<Ball>(model);
        }
    }
}