using COE.Application.Abstractions.Wrappers;
using COE.Application.DTOs;
using COE.Application.Features.Commands.UserFeatures.Create;
using COE.Application.Features.Commands.UserFeatures.Delete;
using COE.Application.Features.Commands.UserFeatures.Update;
using COE.Application.Wrappers;
using COE.ClientExample;

HttpClient Client =  new();
IServiceResponse Response;

#region GetAllUser

Response = await Client.GetServiceAsync<List<UserDTO>>("https://localhost:8082/api/user");

if (Response.IsSuccess) 
{
    Console.WriteLine((Response as SuccessResponse<List<UserDTO>>).Message);
}

#endregion

#region GetUser

Guid Id = Guid.Parse("044310d7-c7d5-4ab7-871c-2180adf5e0da");

Response = await Client.GetServiceAsync<UserDTO>($"https://localhost:8082/api/user/{Id}");

if (Response.IsSuccess)
{
    Console.WriteLine((Response as SuccessResponse<UserDTO>).Message);
}

#endregion

#region CreateUser

//UserCreateCommandRequest CreateRequest = new() 
//{
//    Username = "dincersipka",
//    CreatedBy = "AdminCreate"
//};

//Response = await Client.PostServiceAsync<UserCreateCommandRequest, UserDTO>("https://localhost:8082/api/user/", CreateRequest);

//if (Response.IsSuccess)
//{
//    Console.WriteLine((Response as SuccessResponse<UserDTO>).Message);
//}

#endregion

#region UpdateUser

//UserUpdateCommandRequest UpdateRequest = new()
//{
//    Id = Guid.Parse("044310d7-c7d5-4ab7-871c-2180adf5e0da"),
//    Username = "test",
//    UpdatedBy = "AdminUpdate"
//};

//Response = await Client.PutServiceAsync<UserUpdateCommandRequest, UserDTO>("https://localhost:8082/api/user/", UpdateRequest);

//if (Response.IsSuccess)
//{
//    Console.WriteLine((Response as SuccessResponse<UserDTO>).Message);
//}

#endregion

#region DeleteUser

UserDeleteCommandRequest DeleteRequest = new()
{
    Id = Guid.Parse("044310d7-c7d5-4ab7-871c-2180adf5e0da"),
    DeletedBy = "AdminDelete"
};

Response = await Client.DeleteServiceAsync<UserDeleteCommandRequest, Guid>("https://localhost:8082/api/user/", DeleteRequest);

if (Response.IsSuccess)
{
    Console.WriteLine((Response as SuccessResponse<Guid>).Message);
}

#endregion

Console.ReadLine();