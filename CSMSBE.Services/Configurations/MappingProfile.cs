using AutoMapper;
using CSMS.Entity.CSMS_Entity;
using CSMS.Model.DTO.District;
using CSMS.Entity.IdentityAccess;
using CSMS.Entity.LogHistory;
using CSMS.Model.DTO.ProjectDTO;
using CSMS.Model.DTO.Province;
using CSMS.Model.DTO.SomeTableDTO;
using CSMS.Model.DTO.UserDTO;
using CSMS.Model.Role;
using CSMS.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSMS.Entity.SecurityMatrix;
using CSMS.Model.SecurityMatrix;
using CSMS.Model.DTO.SecurityMatrixDTO;
using CSMS.Entity.Issues;
using CSMS.Model.DTO.IssueDTO;
using CSMS.Model.Issue;
using CSMS.Model;
using CSMS.Model.DTO.ModelDTO;
using CSMS.Model.Model;
using CSMSBE.Services.PushNotification;

namespace CSMSBE.Services.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Ví dụ ánh xạ từ Entity sang DTO
            CreateMap<SomeTable, SomeTableDTO>().ReverseMap();
            CreateMap<UpdateSomeTableDTO, SomeTable>();
            CreateMap<CreateSomeTableDTO, SomeTable>();

            //User
            CreateMap<UserDTO, UserListViewDTO>();
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.UserRoles.FirstOrDefault().Role.Id))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.UserRoles.FirstOrDefault().Role.Code));
            CreateMap<UpdateUserDTO, User>().ReverseMap();
            CreateMap<LogHistoryDTO, LogHistoryEntity>();
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<UserDTO, UserLookup>().ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            //Project/Commune/Province
            CreateMap<SomeTable, CreateSomeTableDTO>().ReverseMap();
            CreateMap<SomeTable, UpdateSomeTableDTO>().ReverseMap();

            CreateMap<Project, ProjectDTO>().ReverseMap();         
            CreateMap<Project, CreateProjectDTO>().ReverseMap();
            CreateMap<Project, UpdateProjectDTO>().ReverseMap();

            CreateMap<Commune, CommuneDTO>().ReverseMap();
            CreateMap<Province, ProvinceDTO>().ReverseMap();
            CreateMap<District, DistrictDTO>().ReverseMap();
           
            CreateMap<Province, LookupDTO>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<District, LookupDTO>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Commune, LookupDTO>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<User, LookupDTO>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<Role, LookupDTO>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            //Role
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<CreateRoleDTO, Role>().ReverseMap();
            CreateMap<UpdateRoleDTO, Role>().ReverseMap();
            CreateMap<RoleDTO, RoleLookupDTO>().ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            //Security Matrix
            CreateMap<CSMS.Entity.SecurityMatrix.Action, ActionDTO>().ReverseMap();
            CreateMap<CSMS.Entity.SecurityMatrix.Screen, ScreenDTO>().ReverseMap();
            CreateMap<SecurityMatrices, SecurityMatrixDTO>().ReverseMap();

            CreateMap<SecurityMatrices, SecurityMatrixListViewDTO>()
                .ForMember(dest => dest.Actions, opt => opt.MapFrom(src => new List<ActionLookupDTO>
                {
                    new ActionLookupDTO
                    {
                        Id = src.Action.Id,
                        Name = src.Action.Name
                    }
                }))
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.ScreenId, opt => opt.MapFrom(src => src.ScreenId))
                .ForMember(dest => dest.ScreenName, opt => opt.MapFrom(src => src.Screen.Name));

            CreateMap<CSMS.Entity.SecurityMatrix.Screen, LookupDTO>().ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<CSMS.Entity.SecurityMatrix.Action, LookupDTO>().ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            //Issue
            CreateMap<Issue, IssueDTO>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
            .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
            .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments));

            CreateMap<IssueDTO, LookupDTO>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateIssueDTO, Issue>().ReverseMap();
            CreateMap<UpdateIssueDTO, Issue>().ReverseMap();
            //Comment
            CreateMap<Comment, CommentDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();

            CreateMap<CommentDTO, LookupDTO>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Content))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

            CreateMap<CreateCommentDTO, Comment>().ReverseMap();
            CreateMap<UpdateCommentDTO, Comment>().ReverseMap();
            //Model
            CreateMap<Model, ModelDTO>().ReverseMap();
            CreateMap<ModelDTO, LookupDTO>()
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));
            CreateMap<CreateModelDTO, Model>().ReverseMap();
            CreateMap<UpdateModelDTO, Model>().ReverseMap();
            
            // PushNotification
            CreateMap<CSMS.Entity.Notification.PushNotification, PushNotificationDto>();
        }
    }
}
