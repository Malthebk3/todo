class Todo(){
  static List<string> tasks = new List<string>();
  static List<string> completed = new List<string>();
  static bool hasLoaded = false;
  static void Main(){
    Load();
    Console.Clear();
    Console.WriteLine("Welcome to Todo!");
    if(tasks != null && tasks.Count != 0){
      for (int i = 0; i < tasks.Count; i++) 
      {
        Console.WriteLine(tasks[i]);
      }
    } else {
      Console.WriteLine("You don't have any Tasks!");
    }
    Console.WriteLine("Press M to manage tasks, C to view completed tasks, or Q to quit.");
    switch (Console.ReadKey(true).Key){
      case ConsoleKey.M:
        ManageTasks();
        break;
      case ConsoleKey.C:
        ViewCompletedTasks();
        break;
      case ConsoleKey.Q:
        Save();
        Environment.Exit(0);
        break;
    }
  }
  static void ManageTasks(){
    Console.Clear();
    if(tasks != null && tasks.Count != 0){
      Console.WriteLine("Todo:");
      for (int i = 0; i < tasks.Count; i++) 
      {
        Console.WriteLine($"{i}: {tasks[i]}");
      }
    } else {
      Console.WriteLine("You don't have any Tasks!");
    }
    if(completed != null && completed.Count != 0){
      Console.WriteLine("Completed Tasks:");
      for (int i = 0; i < completed.Count; i++) 
      {
        Console.WriteLine($"{i}: {completed[i]}");
      }
    } else {
      Console.WriteLine("You don't have any Tasks marked as complete!");
    }
    Console.WriteLine("Press A to add a task, D to delete a task, C to mark/unmark as complete, or Q to quit to main menu.");
    switch (Console.ReadKey(true).Key){
      case ConsoleKey.A:
        AddTask();
        break;
      case ConsoleKey.D:
        DeleteTask();
        break;
      case ConsoleKey.C:
        ViewCompletedTasks();
        break;
      case ConsoleKey.Q:
        Main();
        break;
    }
  }
  static void AddTask(){
    Console.Clear();
    if(tasks != null && tasks.Count != 0){
      Console.WriteLine("Todo: " + tasks.Count);
    } else {
      Console.WriteLine("You don't have any Tasks!");
    }
    tasks.Add(Console.ReadLine());
    ManageTasks();
  }
  static void DeleteTask(){
    Console.Clear();
    if(tasks != null && tasks.Count != 0){
      Console.WriteLine("Todo:");
      for (int i = 0; i < tasks.Count; i++) 
      {
        Console.WriteLine($"{i}: {tasks[i]}");
      }
    } else {
      Console.WriteLine("You don't have any Tasks!");
      Console.WriteLine("Press A to add a task, or Q to go back to task management.");
    }
    Console.WriteLine("Enter the Index of the task you want to remove:");
    int indexToRemove = Convert.ToInt32(Console.ReadLine());
    if (indexToRemove >= 0 && indexToRemove < tasks.Count)
    {
        tasks.RemoveAt(indexToRemove);
        ManageTasks();
    }
    else
    {
        Console.WriteLine("Invalid index.");
        Console.WriteLine("Press D to try again, Press Q to return to task management");
        switch (Console.ReadKey(true).Key){
          case ConsoleKey.D:
            DeleteTask();
            break;
          case ConsoleKey.Q:
            ManageTasks();
            break;
        }
    }
  }
  static void CompleteTask(){
    Console.Clear();
    if(tasks != null && tasks.Count != 0){
      Console.WriteLine("Todo:");
      for (int i = 0; i < tasks.Count; i++) 
      {
        Console.WriteLine($"{i}: {tasks[i]}");
      }
    } else {
      Console.WriteLine("You don't have any Tasks!");
      Console.WriteLine("Press A to add a task, or Q to go back to task management.");
      switch (Console.ReadKey(true).Key){
        case ConsoleKey.A:
          AddTask();
          break;
        case ConsoleKey.Q:
          ManageTasks();
          break;
      }
    }
    if(completed != null && completed.Count != 0){
    Console.WriteLine("Completed Tasks:");
    for (int i = 0; i < completed.Count; i++) 
    {
      Console.WriteLine($"{i}: {completed[i]}");
    }
    } else {
      Console.WriteLine("Completed Tasks:");
      Console.WriteLine("You don't have any completed tasks");
    }
    Console.WriteLine("Enter the Index of the task you want to mark as complete:");
    int indexToMove = Convert.ToInt32(Console.ReadLine());
    if (indexToMove >= 0 && indexToMove < tasks.Count)
    {
        string task = tasks[indexToMove];
        completed.Add(task);
        tasks.RemoveAt(indexToMove);
        ManageTasks();
    }
    else
    {
        Console.WriteLine("Invalid index.");
        Console.WriteLine("Press C to try again, Press Q to return to task management");
        switch (Console.ReadKey(true).Key){
          case ConsoleKey.C:
            CompleteTask();
            break;
          case ConsoleKey.Q:
            ManageTasks();
            break;
        }
    }
  }
  static void UnmarkComplete(){
    Console.Clear();
    if(completed != null && completed.Count != 0){
    Console.WriteLine("Completed Tasks:");
    for (int i = 0; i < completed.Count; i++) 
    {
      Console.WriteLine($"{i}: {completed[i]}");
    }
    } else {
      Console.WriteLine("Completed Tasks:");
      Console.WriteLine("You don't have any completed tasks");
    }
    Console.WriteLine("Enter the Index of the task you want to unmark as complete:");
    int indexToMove = Convert.ToInt32(Console.ReadLine());
    if (indexToMove >= 0 && indexToMove < tasks.Count)
    {
        string task = tasks[indexToMove];
        tasks.Add(task);
        completed.RemoveAt(indexToMove);
        ManageTasks();
    }
    else
    {
        Console.WriteLine("Invalid index.");
        Console.WriteLine("Press U to try again, Press Q to return to task management");
        switch (Console.ReadKey(true).Key){
          case ConsoleKey.U:
            UnmarkComplete();
            break;
          case ConsoleKey.Q:
            ManageTasks();
            break;
        }
    }
  }
  static void ViewCompletedTasks(){
    Console.Clear();
    if(tasks != null && tasks.Count != 0){
      Console.WriteLine("Todo:");
      for (int i = 0; i < tasks.Count; i++) 
      {
        Console.WriteLine($"{i}: {tasks[i]}");
      }
    } else {
      Console.WriteLine("You don't have any Tasks!");
    }
    if(completed != null && completed.Count != 0){
      Console.WriteLine("Completed Tasks:");
      for (int i = 0; i < completed.Count; i++) 
      {
        Console.WriteLine($"{i}: {completed[i]}");
      }
    } else {
      Console.WriteLine("You don't have any Tasks marked as complete!");
    }
    Console.WriteLine("Press C to mark a task as complete, U to unmark task as complete, or Q to go back to task management.");
    switch (Console.ReadKey(true).Key){
      case ConsoleKey.C:
        CompleteTask();
        break;
      case ConsoleKey.U:
        UnmarkComplete();
        break;
      case ConsoleKey.Q:
        ManageTasks();
        break;
    }
  }
  static void Save(){
    //Save Tasks
    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    string fullPath = Path.Combine(documentsPath, "TodoApp", "tasks.txt");
    Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
    File.WriteAllLines(fullPath, tasks);
    //Save Completed Tasks
    fullPath = Path.Combine(documentsPath, "TodoApp", "completed.txt");
    Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
    File.WriteAllLines(fullPath, completed);
  }
  static void Load(){
    //Load Tasks
    if (hasLoaded) return; // Prevent double loading
    hasLoaded = true;
    string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    string fullPath = Path.Combine(documentsPath, "TodoApp", "tasks.txt");
    if (File.Exists(fullPath))
    {
        tasks = new List<string>(File.ReadAllLines(fullPath));
    } else {
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
    }
    //Load Completed Tasks
    fullPath = Path.Combine(documentsPath, "TodoApp", "completed.txt");
    if (File.Exists(fullPath))
    {
        completed = new List<string>(File.ReadAllLines(fullPath));
    } else {
        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
    }
  }
}