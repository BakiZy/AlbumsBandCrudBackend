using AutoMapper;
using ZavrsniTest.Models.DTO;

namespace ZavrsniTest.Models
{
    public class AlbumProfile : Profile
    {

        public AlbumProfile()
        {
            CreateMap<Album, AlbumDTO>();
        }
    }
}
