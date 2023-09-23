using MediatR;
using Minedu.Fw.General.Response.Status;

namespace Back.Ctac.Command.CierreAnual.Ins;

public class CierreGradoInsCommand : IRequest<StatusResponse<int>>
{
    public CierreGradoInsRequest entity;

    public CierreGradoInsCommand(CierreGradoInsRequest request)
    {
        entity = request;
    }
}