using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections;

using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using GraphQL.Query.Builder;
using ReunionLogSoftware;

using GraphQL.Client.Abstractions;

using HotChocolate.Language;

using ReunionLogSoftware.WarcraftLogAPI;

/*
Death Event:

{query($code: String){reportData{report(code: $code){events(dataType: Deaths, endTime: 9999999999, wipeCutoff: 3){data}}}}}

query($code: String){
    reportData{
        report(code: $code){
            events(dataType: Deaths, endTime: 9999999999, wipeCutoff: 3){
                data
            }
        }
    }
}
*/

namespace ReunionLogSoftware.GraphControl{
    class Human{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Planet HomePlanet { get; set; }
    }
    class Planet{
        public string Name { get; set; }
    }

    public static class GraphBuilder {
        public static async void Build(string code){
            var client_id = "Insert Id";
            var client_secret = "Insert Secret";
            var api = new WarcraftLogsApi(client_id, client_secret);
            var accessToken = await api.GetAccessToken();

            var reportCode = "KqkXJwvdn6NT2tLZ";
            var reportData = await api.GetReportData(reportCode);
            System.Console.WriteLine(reportData);
        } 
    }
}