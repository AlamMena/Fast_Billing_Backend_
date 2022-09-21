using System.ComponentModel.DataAnnotations;
using API.DbModels.Contexts;
using API.DbModels.Users;
using API.Dtos.Users;
using API.Services.Firebase;
using FirebaseAdmin.Auth;
using Microsoft.EntityFrameworkCore;

namespace API.Services.Users
{
    public class UserManagement : IUserManagement
    {
        private readonly FirebaseInit _firebaseInit;
        private readonly FbContext _context;
        private readonly ILogger<UserManagement> _loggger;

        public UserManagement(FirebaseInit firebaseInit, FbContext context, ILogger<UserManagement> loggger)
        {
            _firebaseInit = firebaseInit;
            _context = context;
            _loggger = loggger;
        }
        public async Task<User> CreateUserAsync(UserDto userRequest)
        {
            var firebaseId = "";
            try
            {
                // init db transaction
                await _context.Database.BeginTransactionAsync();

                // creating the user in firebase
                var firebaseUser = await _firebaseInit.Auth.CreateUserAsync(new UserRecordArgs()
                {
                    Email = userRequest.Email,
                    DisplayName = userRequest.UserName,
                    Password = userRequest.Password,
                    PhotoUrl = userRequest.ImageUrl
                });

                firebaseId = firebaseUser.Uid;

                _loggger.LogTrace("Firebase user created!");

                // creating the user into the database
                var dbUser = new User()
                {
                    FirebaseId = firebaseUser.Uid,
                    UserName = userRequest.UserName,
                    Email = userRequest.Email,
                    ImageUrl = userRequest.ImageUrl,
                };

                // saving changes
                await _context.AddAsync(dbUser);
                await _context.SaveChangesAsync();

                _loggger.LogTrace("Database user created!");

                // commiting changes
                await _context.Database.CommitTransactionAsync();

                _loggger.LogTrace("'CreateUser' methdod successfully executed !");

                return dbUser;

            }
            catch (FirebaseAuthException ex)
            {
                _loggger.LogError("An error has occured with firebase");

                if (ex.ErrorCode == FirebaseAdmin.ErrorCode.AlreadyExists)
                {
                    throw new ValidationException("Email is not avaliable");
                }

                _loggger.LogError("An unhandler firebase error has ocurred");
                throw;
            }
            catch (Exception)
            {
                await _firebaseInit.Auth.DeleteUserAsync(firebaseId);
                throw;
            }
        }

        public Task<User> UpdateUserAsync(UserDto request)
        {
            throw new NotImplementedException();
        }
    }
}