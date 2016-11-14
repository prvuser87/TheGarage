namespace TheGarage.Web.Areas.Administration.ViewModels.Users
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using TheGarage.Data.Models;
    using AutoMapper.SelfConfig;
    using Common;

    public class UsersAdministrationViewModel : AdministrationViewModel, IMapFrom<User>, IMapTo<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Image")]
        public string UserImage { get; set; }

        [Display(Name = "Has Admin Rights")]
        public bool IsCurrentlyAdmin { get; set; }

        [Display(Name = "Has Moderator Rights")]
        public bool IsCurrentlyModerator { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UsersAdministrationViewModel>()
              .ForMember(m => m.IsCurrentlyAdmin, opt => opt.MapFrom(u => u.Roles.Count() >= 3))
              .ForMember(m => m.IsCurrentlyModerator, opt => opt.MapFrom(u => u.Roles.Count() >= 2));
              //.ForMember(m => m.ContentsCreatedCount, opt => opt.MapFrom(u => u.Contents.Count()))
              //.ForMember(m => m.CommentsCreatedCount, opt => opt.MapFrom(u => u.Comments.Count()))
              //.ForMember(m => m.ContentViewsCount, opt => opt.MapFrom(u => u.Comments.Count()))
              //.ForMember(m => m.CommentViewsCount, opt => opt.MapFrom(u => u.Comments.Count()))
              //.ForMember(m => m.ContentLikesGivvenCount, opt => opt.MapFrom(u => u.ContentViews.Count(v => v.Liked == true)))
              //.ForMember(m => m.ContentHatesGivvenCount, opt => opt.MapFrom(u => u.ContentViews.Count(v => v.Liked == false)))
              //.ForMember(m => m.ContentFlagsGivvenCount, opt => opt.MapFrom(u => u.ContentViews.Count(v => v.Flagged == true)))
              //.ForMember(m => m.CommentFlagsGivvenCount, opt => opt.MapFrom(u => u.CommentViews.Count(v => v.Flagged == true)))
              //.ForMember(m => m.ContentLikesRecievedCount, opt => opt.MapFrom(u => u.Contents.Sum(c => c.ContentViews.Count(v => v.Liked == true))))
              //.ForMember(m => m.ContentHatesRecievedCount, opt => opt.MapFrom(u => u.Contents.Sum(c => c.ContentViews.Count(v => v.Liked == false))))
              //.ForMember(m => m.ContentFlagsRecievedCount, opt => opt.MapFrom(u => u.Contents.Sum(c => c.ContentViews.Count(v => v.Flagged == true))))
              //.ForMember(m => m.CommentFlagsRecievedCount, opt => opt.MapFrom(u => u.Comments.Sum(c => c.CommentViews.Count(v => v.Flagged == true))));
        }
    }
}