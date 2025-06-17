using System;

namespace CursorPaste
{
    public class Prompt
    {
        public string Name { get; set; }
        public string Content { get; set; }

        public Prompt()
        {
            // Default constructor for deserialization
        }

        public Prompt(string name, string content)
        {
            Name = name;
            Content = content;
        }
    }
} 