using AutoMapper;
using MyList.Application.Common.Dto;
using MyList.Data.API;
using MyList.Domain.Common.Models;
using MyList.Domain.Common.Models.ContentModels;
using MyList.Domain.Common.Models.Tags;
using TMDbLib.Objects.Search;

namespace MyList.Web.Services
{
    public class AppMappingProfile : Profile
    {
        private const string imagePath = "https://image.tmdb.org/t/p/w500";

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


            CreateMap<volumeInfo, Book>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.title))
               .ForMember(dest => dest.Authors, opt => opt.Ignore())
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.description))
               .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => src.imageLinks.thumbnail))
               .ForMember(dest => dest.BookSeries, opt => opt.MapFrom(src => src.subtitle));

            CreateMap<AnimeAttribute, Anime>()
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.synopsis))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.titles.en))
               .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => src.coverImage.original))
               .ForMember(dest => dest.CountEpisodes, opt => opt.MapFrom(src => src.episodeCount));

            CreateMap<SearchMovie, Film>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Title))
              .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Overview))
              .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => imagePath + src.PosterPath));

            CreateMap<SearchTv, Serial>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Overview))
             .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => imagePath + src.PosterPath));
        }
    }
}
