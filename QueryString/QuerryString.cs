using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace ReunionLogSoftware.QueryString{
    public class QueryString{
        public string QString = null;
        public MasterType mainType = null;

        public QueryString(MasterType masterType){
            mainType = masterType;
            QString = "{query($code: String)}";
        }

        public string AddField(String fieldString){
            return "";
        }

        public string QueryCreator(){
            return "";
        }
    }
}