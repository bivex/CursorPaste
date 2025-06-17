using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace CursorPaste
{
    public class PromptManager
    {
        private const string PromptsFileName = "prompts.json";
        private readonly List<Prompt> _prompts;

        public IEnumerable<Prompt> Prompts => _prompts.AsReadOnly();

        public PromptManager()
        {
            _prompts = LoadPrompts();
        }

        private static List<Prompt> LoadPrompts()
        {
            if (File.Exists(PromptsFileName))
            {
                try
                {
                    string jsonString = File.ReadAllText(PromptsFileName);
                    return JsonConvert.DeserializeObject<List<Prompt>>(jsonString) ?? new List<Prompt>();
                }
                catch (Newtonsoft.Json.JsonSerializationException ex)
                {
                    throw new IOException($"Error deserializing prompts from {PromptsFileName}: {ex.Message}", ex);
                }
                catch (IOException ex)
                {
                    throw new IOException($"Error reading prompts from {PromptsFileName}: {ex.Message}", ex);
                }
            }
            return new List<Prompt>();
        }

        public void SavePrompts()
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(_prompts, Formatting.Indented);
                File.WriteAllText(PromptsFileName, jsonString);
            }
            catch (Newtonsoft.Json.JsonSerializationException ex)
            {
                throw new IOException($"Error serializing prompts to {PromptsFileName}: {ex.Message}", ex);
            }
            catch (IOException ex)
            {
                throw new IOException($"Error writing prompts to {PromptsFileName}: {ex.Message}", ex);
            }
        }

        public void AddPrompt(Prompt newPrompt)
        {
            if (newPrompt == null) throw new ArgumentNullException(nameof(newPrompt));
            if (_prompts.Any(p => p.Name.Equals(newPrompt.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"A prompt with the name '{newPrompt.Name}' already exists.");
            }
            _prompts.Add(newPrompt);
            SavePrompts();
        }

        public void UpdatePrompt(string originalName, Prompt updatedPrompt)
        {
            if (updatedPrompt == null) throw new ArgumentNullException(nameof(updatedPrompt));

            var existingPrompt = _prompts.FirstOrDefault(p => p.Name.Equals(originalName, StringComparison.OrdinalIgnoreCase));
            if (existingPrompt == null)
            {
                throw new KeyNotFoundException($"Prompt with name '{originalName}' not found.");
            }

            // Check if the name has changed to an existing name (and it's not the same prompt)
            if (!originalName.Equals(updatedPrompt.Name, StringComparison.OrdinalIgnoreCase) &&
                _prompts.Any(p => p.Name.Equals(updatedPrompt.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"A prompt with the name '{updatedPrompt.Name}' already exists.");
            }

            existingPrompt.Name = updatedPrompt.Name;
            existingPrompt.Content = updatedPrompt.Content;
            SavePrompts();
        }

        public void DeletePrompt(string promptName)
        {
            var promptToRemove = _prompts.FirstOrDefault(p => p.Name.Equals(promptName, StringComparison.OrdinalIgnoreCase));
            if (promptToRemove != null)
            {
                _prompts.Remove(promptToRemove);
                SavePrompts();
            }
            else
            {
                throw new KeyNotFoundException($"Prompt with name '{promptName}' not found.");
            }
        }

        public Prompt GetPromptByName(string name)
        {
            return _prompts.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }
    }
} 