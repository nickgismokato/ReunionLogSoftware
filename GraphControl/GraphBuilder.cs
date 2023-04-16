using System;
using System.Threading.Tasks;

using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using GraphQL.Query.Builder;
using ReunionLogSoftware;


namespace ReunionLogSoftware.GraphControl{
    class Actor{
        public string Name {get; set;}
        public int Id {get; set;}
    }
    public static class GraphBuilder {
        public static void Build(){
            var query = new Query<Actor>("actors")
                .AddArguments(new {type = "Player"})
                .AddField(h => h.Name)
                .AddField(h => h.Id);
            string queryString = query.Build();
            System.Console.WriteLine("{" + queryString + "}");
            System.Diagnostics.Debug.WriteLine("{" + queryString + "}");
        } 
    }
}