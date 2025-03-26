using Hall_App.Dto;

namespace Hall_App.Service
{
    public interface ILoginService
    {
        bool ValidateUser(UserDto user);
    }
}