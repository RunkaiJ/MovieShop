using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.DTOs;

namespace ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        CastDetailsDto GetCastDetails(int castId);
    }

}
