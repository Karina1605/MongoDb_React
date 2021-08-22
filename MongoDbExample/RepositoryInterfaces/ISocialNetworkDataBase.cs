﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDbExample.Models;

namespace MongoDbExample.RepositoryInterfaces
{
    public interface ISocialNetworkDataBase
    {
        ICrudOperationFull<User> Users { get; }
        ICrudOperation<Post> Posts {get; set;}
    }
}
