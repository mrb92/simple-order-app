namespace SimpleOrderApp.Infrastructure.General
{
    public class InfrastructureConstants
    {
        public static class SwaggerDocGroupName
        {
            public const string Orders = "orders";
        }

        public readonly static List<(string DocName, string DocTitle)> SwaggerDocsInfo = new()
        {
            (SwaggerDocGroupName.Orders, "Orders")
        };
    }
}
