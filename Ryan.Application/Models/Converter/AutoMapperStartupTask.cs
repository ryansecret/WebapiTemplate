using System.Security;
using AutoMapper;
using Daisy.Core;
using Ryan.Model;

namespace Ryan.Application.Models.Converter
{
    public class AutoMapperStartupTask: IStartupTask
    {
        public void Execute()
        {
             Mapper.Initialize(cg =>
             {
                 cg.CreateMap<BallEntity, Ball>();
                 cg.CreateMap<Ball, BallEntity>();

             });
        }

        public int Order { get; } = 1;
    }
}