using System;
using System.Threading;
using System.Threading.Tasks;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Domain.Model.Core;
using HotelsReviewApp.Infrastructure.Data;
using MediatR;

namespace HotelsReviewApp.Domain.Service.Reviews.CreateHotelReview
{
   public class CreateHotelReviewCommandHandler: IRequestHandler<CreateHotelReviewCommand, CommandResult<CommandEmptyResult>>
   {
       private readonly IRepository<Review> _reviewRepository;
       private readonly IRepository<User> _userRepository;
       private readonly IRepository<Hotel> _hotelRepository;
       private readonly IUnitOfWork _unitOfWork;

       public CreateHotelReviewCommandHandler(IRepository<Review> reviewRepository, IUnitOfWork unitOfWork, IRepository<User> userRepository, IRepository<Hotel> hotelRepository)
       {
           _reviewRepository = reviewRepository;
           _unitOfWork = unitOfWork;
           _userRepository = userRepository;
           _hotelRepository = hotelRepository;
       }

       public Task<CommandResult<CommandEmptyResult>> Handle(CreateHotelReviewCommand request, CancellationToken cancellationToken)
       {
           var user = _userRepository.FindById(request.UserId);
           var hotel = _hotelRepository.FindById(request.HotelId);
           if (user != null && hotel != null)
           {
               var review = new Review(user, hotel, request.Description, request.HotelRating);
               _reviewRepository.Add(review);
               _unitOfWork.SaveChanges();
               return Task.FromResult(CommandResult<CommandEmptyResult>.Success(new CommandEmptyResult()));
            }
            return Task.FromResult(CommandResult<CommandEmptyResult>.Fail("Fail to create review."));
        }
    }
}
