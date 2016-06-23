using System.Security;
using AutoMapper;
using Daisy.Core;
using Ryan.DomainModel;
using Ryan.DomainModel.Ryan;

namespace Ryan.Application.Models.Converter
{
    public class AutoMapperStartupTask: IStartupTask
    {
        public void Execute()
        {
             Mapper.Initialize(cg =>
             {
                 cg.CreateMap<BallEntity, Ball>().ForMember(d=>d.Name,s=>s.MapFrom(d=>d.Name.TrimEnd()));
                 cg.CreateMap<Ball, BallEntity>();

             });
        }

        public int Order { get; } = 1;
    }
}