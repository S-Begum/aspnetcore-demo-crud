using AutoMapper;
using Demo1CoreCRUD.Models;
using Demo1CoreCRUD.ViewModels;

namespace Demo1CoreCRUD.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateTaskVM, ToDoList>()
                .ForMember(dest => dest.Task, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.CompleteDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Rank))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.User));

            CreateMap<EditTaskVM, ToDoList>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TaskId))
                .ForMember(dest => dest.Task, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.CompleteDate))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.StatusLabel))
                .ForMember(dest => dest.Comment, opt => opt.MapFrom(src => src.Note))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.User));

            CreateMap<ToDoList, EditTaskVM>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Task))
                .ForMember(dest => dest.CompleteDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.StatusLabel, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Note, opt => opt.MapFrom(src => src.Comment))
                .ForMember(dest => dest.DateCreated, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.CreatedBy));
        }

    }
}
