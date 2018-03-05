using System.Text.RegularExpressions;
using SimpleJson;

namespace Exercise_2.Models
{
    public class CamelCaseSerializerStrategy : PocoJsonSerializerStrategy
    {
        protected override string MapClrMemberNameToJsonFieldName(string clrPropertyName)
        {
            return Regex.Replace(clrPropertyName, "([a-z])([A-Z])", @"$1_$2").ToLower();
        }
    }
}