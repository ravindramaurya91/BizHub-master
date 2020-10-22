using System;
using System.Collections.Generic;
using System.Text;

using Ganss.XSS;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;

namespace Model {
    public class FSHtmlSanitizer {

        public static string SanitizeInput(string value) {
            var sanitizer = new HtmlSanitizer();
            string s1 = Regex.Replace(value, "<.*?>", string.Empty);
            return sanitizer.Sanitize(s1);
        }

    }
}
