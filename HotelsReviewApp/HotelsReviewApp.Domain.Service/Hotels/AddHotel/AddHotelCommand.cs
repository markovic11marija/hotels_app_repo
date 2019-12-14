using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Hotels.AddHotel
{
   public class AddHotelCommand : IRequest<CommandResult<CommandEmptyResult>>
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public Image Image { get; set; }
        public string Description { get; set; }
        public GeoLocation GeoLocation { get; set; }
    }
}
