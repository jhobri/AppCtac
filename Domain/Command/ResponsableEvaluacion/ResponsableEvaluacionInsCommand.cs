using MediatR;
using Minedu.Fw.General.Response.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Ctac.Command.ResponsableEvaluacion
{
    public class ResponsableEvaluacionInsCommand : IRequest<StatusResponse<int>>
    {
        public ResponsableEvaluacionInsRequest entity;

        public ResponsableEvaluacionInsCommand(ResponsableEvaluacionInsRequest entity)
        {
            this.entity = entity;
        }
    }
}
