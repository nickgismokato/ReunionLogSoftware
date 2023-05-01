using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace ReunionLogSoftware.QueryString{
    public class QueryString{
        public string QString = null;
        public MasterType mainType;

        public QueryString(MasterType masterType){
            mainType = masterType;
            QString = "{query($code: String)}";
        }

        public void AddField(String fieldString){
            int strLen = QString.Length;
            QString.Insert(strLen-4, fieldString);
        }

        public string QueryCreator(){
            return "";
        }
    }
}