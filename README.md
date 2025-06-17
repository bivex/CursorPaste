# CursorPaste

## Description

CursorPaste is a simple Windows Forms application that allows users to manage and quickly insert predefined text snippets or templates into any application at the current cursor position. It's designed to streamline repetitive typing tasks by providing a centralized location for storing and accessing frequently used phrases, code snippets, or boilerplate text.

## Features

*   **Snippet Management:** Add, update, and delete text snippets.
*   **Quick Insertion:** Insert snippets directly into other applications using a global hotkey (future enhancement) or by clicking a button.
*   **User-Friendly Interface:** A straightforward UI for easy management of prompts.
*   **Error Handling:** Robust error handling for file operations and data serialization.

## How to Use

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/your-username/CursorPaste.git
    ```
2.  **Open in Visual Studio:** Open the `CursorPaste.sln` file in Visual Studio.
3.  **Build the project:** Build the solution to restore NuGet packages and compile the application.
4.  **Run the application:** Run the application from Visual Studio or navigate to the `bin/Debug` (or `bin/Release`) folder and run `CursorPaste.exe`.
5.  **Manage Prompts:**
    *   Use the "Add", "Update", and "Delete" buttons to manage your prompts.
    *   Enter a "Prompt Name" and "Prompt Content" to create or modify a snippet.
6.  **Insert Snippets:**
    *   Select a prompt from the list.
    *   Click the "Insert text at cursor" button. The application will hide temporarily, and the selected text will be inserted at your current cursor position in any other open application.

## Technologies Used

*   C#
*   Windows Forms (.NET Framework)
*   Newtonsoft.Json for JSON serialization/deserialization

## Future Enhancements

*   Global hotkey support for quick insertion.
*   Search and filter functionality for prompts.
*   Import/export prompts functionality.
*   Categorization of prompts.

## Contribution

Contributions are welcome! Please feel free to open issues or submit pull requests.
