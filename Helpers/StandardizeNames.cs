using System;
using System.Collections.Generic;
using System.Linq;

namespace TenderTummiesAPI.Helpers
{
    public class StandardizeNames
    {
        public StandardizeNames(){
        }

        public string ToTitlecase(string Name){
            return SplitNameIntoStrings(Name);
        }
        
        public string SplitNameIntoStrings(string Name){
            string[] stringArray = Name.Split(null);
            List<string> stringGroup = new List<string>();
            foreach (String thing in stringArray){
                stringGroup.Add(FirstLetterToUpper(thing));
            }
            return string.Join(" ", stringGroup);
        }

        public string FirstLetterToUpper(string str)
        {
            if (str == null){
                return null;
            }
            if (str.Length > 1){
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return str.ToUpper();
        }

    }
}