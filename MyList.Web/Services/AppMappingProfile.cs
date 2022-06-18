using AutoMapper;
using MyList.Application.Common.Dto;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;

namespace MyList.Web.Services
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<GameTag, TagDto>().ReverseMap();
            CreateMap<AnimeTag, TagDto>().ReverseMap();
            CreateMap<BookTag, TagDto>().ReverseMap();
            CreateMap<SerialTag, TagDto>().ReverseMap();
            CreateMap<FilmTag, TagDto>().ReverseMap();

            CreateMap<Game, ItemDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
                .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => $"{src.PictureURL}"))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.GameID}"))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => $"{src.GlobalScore.ToString()}"));

            CreateMap<Film, ItemDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
                .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => $"{src.PictureURL}"))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.FilmID}"))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => $"{src.GlobalScore.ToString()}"));

            CreateMap<Anime, ItemDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
                .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => $"{src.PictureURL}"))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.AnimeID}"))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => $"{src.GlobalScore.ToString()}"));


            CreateMap<Serial, ItemDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
                .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => $"{src.PictureURL}"))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.SerialID}"))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => $"{src.GlobalScore.ToString()}"));


            CreateMap<Book, ItemDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name}"))
                .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => $"{src.PictureURL}"))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => $"{src.BookID}"))
                .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => $"{src.GlobalScore.ToString()}"));

        }
    }
}
