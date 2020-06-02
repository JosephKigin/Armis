using Armis.BusinessModels.OrderEntryModels;
using Armis.Data.DatabaseContext;
using Armis.DataLogic.ModelExtensions.OrderEntryExtensions;
using Armis.DataLogic.Services.OrderEntryServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armis.DataLogic.Services.OrderEntryServices
{
    public class CommentCodeService : ICommentCodeService
    {
        private ARMISContext Context;

        public CommentCodeService(ARMISContext aContext)
        {
            Context = aContext;
        }

        public async Task<IEnumerable<CommentCodeModel>> GetAllCommentCodes()
        {
            var entities = await Context.CommentCode.ToListAsync();

            if(entities == null || !entities.Any()) { throw new Exception("No Comment Codes were returned"); }

            return entities.ToModels();
        }
    }
}
