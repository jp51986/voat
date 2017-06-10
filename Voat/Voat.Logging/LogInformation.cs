#region LICENSE

/*
    
    Copyright(c) Voat, Inc.

    This file is part of Voat.

    This source file is subject to version 3 of the GPL license,
    that is bundled with this package in the file LICENSE, and is
    available online at http://www.gnu.org/licenses/gpl-3.0.txt;
    you may not use this file except in compliance with the License.

    Software distributed under the License is distributed on an
    "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, either express
    or implied. See the License for the specific language governing
    rights and limitations under the License.

    All Rights Reserved.

*/

#endregion LICENSE


using System;
using System.Reflection;
using Newtonsoft.Json;

namespace Voat.Logging
{
    public class LogInformation : ILogInformation
    {
        public LogInformation()
        {

        }

        public Nullable<Guid> ActivityID { get; set; }

        [JsonProperty(Order = 50, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty(Order = 1, NullValueHandling = NullValueHandling.Ignore)]
        public string Origin { get; set; }

        [JsonProperty(Order = 2, NullValueHandling = NullValueHandling.Ignore)]
        public LogType Type { get; set; }

        [JsonProperty(Order = 4, NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }

        [JsonProperty(Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }

        //[JsonProperty(Order = 51, NullValueHandling = NullValueHandling.Ignore)]
        //public string Source { get; set; }

        [JsonProperty(Order = 40, NullValueHandling = NullValueHandling.Ignore)]
        public Exception Exception { get; set; }

        /// <summary>
        /// Any additional data that needs to be logged. This object will be serialized to JSON and stored as a string by system loggers.
        /// </summary>
        [JsonProperty(Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public object Data { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;


        /// <summary>
        /// Use only for simple debugging
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0}:{1}({2}) {3} Exception: {4}", Origin, Type.ToString(), UserName, Message, (Exception != null ? Exception.ToString() : "")) + (Data == null ? "" : ", value:" + Data.ToString());
        }


    }
}
