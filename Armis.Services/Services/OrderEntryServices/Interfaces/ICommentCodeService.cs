using Armis.BusinessModels.OrderEntryModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.OrderEntryServices.Interfaces
{
    public interface ICommentCodeService
    {
        Task<IEnumerable<CommentCodeModel>> GetAllCommentCodes();
    }
}
