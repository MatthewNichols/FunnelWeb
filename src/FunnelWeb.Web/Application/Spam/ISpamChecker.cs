using FunnelWeb.Domain.Model;

namespace FunnelWeb.Web.Application.Spam
{
    public interface ISpamChecker
    {
        void Verify(Comment comment);
        void Verify(Pingback pingback);
    }
}
