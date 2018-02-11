using System;
using System.Reflection;

namespace Scorponok.Adquirente.Web.UI.Api.Test.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}