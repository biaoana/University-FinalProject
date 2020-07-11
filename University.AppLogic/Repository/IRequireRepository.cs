using System;
using System.Collections.Generic;
using System.Text;
using University.AppLogic.Models;

namespace University.AppLogic.Repository
{
    public interface IRequireRepository: IRepository<Require>
    {
        Require GetByID(string Id);
        IEnumerable<Require> AcceptedRequest(string userId);
    }
}
