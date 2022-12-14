using System.Collections.Generic;
using UserMicroservice.Data;

namespace UserMicroservice.Models;

public record UsersListResponseModel(List<User> Users);
