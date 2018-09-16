using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public enum LanguageStatus
    {
        Disabled = 0,
        Enable = 1
    }
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public LanguageStatus Status { get; set; }
    }
}
