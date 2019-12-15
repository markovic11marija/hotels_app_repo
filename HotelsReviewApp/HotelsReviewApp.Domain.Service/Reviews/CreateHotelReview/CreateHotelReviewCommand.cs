using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Reviews.CreateHotelReview
{
    public class CreateHotelReviewCommand : IRequest<CommandResult<CommandEmptyResult>>
    {
        public int UserId { get; set; }
        public int HotelId { get; set; }
        public string Description { get; set; }
        public HotelRating HotelRating { get; set; }
    }
}
