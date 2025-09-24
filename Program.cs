
// Recreate Learnpoint in the terminal.

// Log in, log out.
// Students, teachers, admin.
// Admin can create a new account.
// Upload documents.
// Create schedules with events.
// Teachers can grade exams.
// Students can upload files to exams.
// Admins can create courses.
//...



using System.ComponentModel;
using System.Data;
using System.Reflection.Metadata;
using App;

List<IUser> users = new List<IUser>();
users.Add(new Student("teststudent", "t@s", "pass"));
users.Add(new Teacher("teacher", "password"));
users.Add(new Admin("Default Admin", "admin", "admin"));

Dictionary<string, SDocument> studentDocuments = new Dictionary<string, SDocument>();
Dictionary<string, Course> studentCourses = new Dictionary<string, Course>();
Dictionary<string, List<Message>> studentMessages = new Dictionary<string, List<Message>>();

IUser? active_user = null;

bool running = true;

while (running)
{
  Console.Clear();

  if (active_user == null)
  {
    Console.WriteLine("\n\nWelcome to TeachLine\n");

    Console.WriteLine("\n[1] Log in.");
    Console.WriteLine("\n[2] Retrieve password.");
    Console.WriteLine("\n[3] Quit");
    Console.Write("\n\nChoose an option [1-3]: ");

    switch (Console.ReadLine())
    {
      case "1":
        Console.Clear();
        Console.WriteLine("\n\nLog in to TeachLine.\n");

        Console.Write("\nUsername: ");
        string username = Console.ReadLine();

        Console.Write("\nPassword: ");
        string password = Console.ReadLine();

        // Console.WriteLine($"{username} {password}");

        foreach (IUser user in users)
        {
          if (user.TryLogin(username, password))
          {
            active_user = user;
            // break;
          }
        }
        if (active_user == null)
        {
          Console.Write("\nInvalid username/password. Press ENTER to continue. ");
          Console.ReadLine();
        }
        break;

      case "2":

        Console.Clear();
        Console.WriteLine("\n\nRetrieve password.\n");
        Console.WriteLine("\nWrite your username.");
        string checkUsername = Console.ReadLine();

        IUser findUsername = users.FirstOrDefault(u => u.Username.Equals(checkUsername, StringComparison.OrdinalIgnoreCase));

        if (findUsername != null)
        {
          Console.WriteLine($"\nPassword: {findUsername._password}");
          Console.Write("\nPress ENTER to continue. ");
          Console.ReadLine();
        }
        else
        {
          Console.WriteLine("\nNo user found with that username.");
          Console.Write("\nPress ENTER to continue. ");
          Console.ReadLine();
          break;
        }

        break;

      case "3":
        running = false;
        break;

      default:
        Console.Write("\nInvalid input. Press ENTER to continue. ");
        Console.ReadLine();
        break;
    }
  }
  else
  {
    Console.WriteLine("\n\n----- TeachLine -----\n");

    if (active_user is Admin a)
    {
      Console.WriteLine($"\nWelcome to your main page, {a.Name}.\n");

      Console.WriteLine("\n[1] Create a new account.");
      Console.WriteLine("\n[2] Remove an account.");
      Console.WriteLine("\n[3] Manage courses.");
      Console.WriteLine("\n[4] System overview.");
      Console.WriteLine("\n[5] Log out.");
      Console.Write("\nChoose an option [1-5]: ");

      switch (Console.ReadLine())
      {
        case "1": // Create new account
          {
            Console.Clear();
            Console.WriteLine("\n\nCreate a new account.\n");
            Console.WriteLine("\n[1] Create a new student account.");
            Console.WriteLine("\n[2] Create a new teacher account.");
            Console.WriteLine("\n[3] Create a new admin account.");
            Console.WriteLine("\n[4] Back to previous menu.");
            Console.Write("\nChoose an option [1-4]: ");

            switch (Console.ReadLine())
            {
              case "1": // Student account
                Console.Write("\n\nStudent's name: ");
                string newStudentName = Console.ReadLine();

                Console.Write("\nStudent's email: ");
                string newStudentEmail = Console.ReadLine();

                Console.Write("\nStudent's password: ");
                string newStudentPass = Console.ReadLine();

                if (string.IsNullOrEmpty(newStudentName) || string.IsNullOrEmpty(newStudentEmail) || string.IsNullOrEmpty(newStudentPass))
                {
                  Console.Write("\nStudents's data cannot be empty. Press ENTER to continue");
                  Console.ReadLine();
                }
                else
                {
                  users.Add(new Student(newStudentName, newStudentEmail, newStudentPass));
                }
                break;

              case "2": // Teacher account
                Console.Write("\nTeacher's username: ");
                string newTeacherUsername = Console.ReadLine();

                Console.Write("\nTeacher's password: ");
                string newTeacherPass = Console.ReadLine();

                if (string.IsNullOrEmpty(newTeacherUsername) || string.IsNullOrEmpty(newTeacherPass))
                {
                  Console.Write("\nTeacher's data cannot be empty. Press ENTER to continue");
                  Console.ReadLine();
                }
                else
                {
                  users.Add(new Teacher(newTeacherUsername, newTeacherPass));
                }
                break;

              case "3": // Admin account
                Console.Write("\nAdmin's name: ");
                string newAdminName = Console.ReadLine();

                Console.Write("\nAdmin's username: ");
                string newAdminUsername = Console.ReadLine();

                Console.Write("\nAdmin's password: ");
                string newAdminPass = Console.ReadLine();

                if (string.IsNullOrEmpty(newAdminName) || string.IsNullOrEmpty(newAdminUsername) || string.IsNullOrEmpty(newAdminPass))
                {
                  Console.Write("\nAdmin's data cannot be empty. Press ENTER to continue");
                  Console.ReadLine();
                }
                else
                {
                  users.Add(new Admin(newAdminName, newAdminUsername, newAdminPass));
                }
                break;

              case "4": // Back to menu
                break;

              default:
                Console.Write("\nInvalid input. Press ENTER to continue. ");
                Console.ReadLine();
                break;
            }
            break;
          }

        case "2": // Remove an account

          Console.WriteLine("\nWhich type of account do you want to remove?\n");
          Console.WriteLine("\n[1] Student.");
          Console.WriteLine("\n[2] Teacher.");
          Console.WriteLine("\n[3] Admin.");
          Console.Write("\nType [1-3]: ");

          Type selectedType = null;

          switch (Console.ReadLine())
          {
            case "1":
              selectedType = typeof(Student);
              break;

            case "2":
              selectedType = typeof(Teacher);
              break;

            case "3":
              selectedType = typeof(Admin);
              break;
            default:
              Console.Write("\nInvalid selection. Press ENTER to continue. ");
              Console.ReadLine();
              break;
          }

          var filteredUsers = users.Where(u => u.GetType() == selectedType).ToList();

          if (filteredUsers.Count == 0)
          {
            Console.WriteLine($"\nNo users of type {selectedType} where found.");
            Console.Write($"\nPress ENTER to continue. ");
            Console.ReadLine();
          }

          Console.WriteLine($"\n{selectedType.Name}s");

          foreach (var user in filteredUsers)
          {
            Console.WriteLine(user.Username);
          }

          Console.Write($"\nEnter the username of the {selectedType.Name} to remove: ");
          string selectedUser = Console.ReadLine();

          IUser removeUser = users.FirstOrDefault(u => u.Username.Equals(selectedUser, StringComparison.OrdinalIgnoreCase));

          if (removeUser != null)
          {
            users.Remove(removeUser);
            Console.WriteLine($"\nUser {selectedUser} has been removed.");
          }
          else
          {
            Console.WriteLine($"\nUser {selectedUser} not found.");
          }
          Console.Write("\nPress ENTER to continue. ");
          Console.ReadLine();
          break;

        case "3": // Manage courses

          Console.Clear();
          Console.WriteLine("\n\nManage courses.\n");

          Console.WriteLine("\n[1] Courses overview.");
          Console.WriteLine("\n[2] Add new course.");
          Console.WriteLine("\n[3] Update course.");
          Console.WriteLine("\n[4] Register or remove students from courses.");
          Console.WriteLine("\n[5] Manage status (active/inactivate).");
          Console.WriteLine("\n[6] Back to previous menu..");
          Console.Write("\nChoose an option [1-6]. ");

          switch (Console.ReadLine())
          {
            case "1": // Courses overview
              {
                Console.Clear();
                Console.WriteLine("\n\nCourses overview.\n");

                Console.Write($"\n{string.Join(" | ", studentCourses.Keys)}\n");

                Console.Write("\n\nChoose course to see details: ");
                string choosedCourse = Console.ReadLine();

                if (!string.IsNullOrEmpty(choosedCourse))
                {
                  Console.Clear();
                  Console.WriteLine($"\n\n{choosedCourse} - Overview.\n");

                  foreach ((string courseKey, Course course) in studentCourses)
                  {
                    if (choosedCourse == courseKey)
                    {
                      Console.WriteLine($"\nCourse name: {course.Name}\n"
                      + $"Course start: {course.StartDate}\n"
                      + $"Course end: {course.EndDate}\n"
                      + $"Teacher: {course.Teacher}\n"
                      + $"{course.Points} pts.\n"
                      + $"{(course.Active ? "Course is active" : "Course is inactive")}\n"
                      + $"Registered students: {(course.Students.Count > 0 ? course.Students.Count : "No students registered yet.")}");
                    }
                  }
                  Console.Write("\n\nPress ENTER to continue. ");
                  Console.ReadLine();
                  break;
                }
                else
                {
                  Console.Write("\nInvalid input. Press ENTER to continue. ");
                  Console.ReadLine();
                  break;
                }
                break;
              }
            case "2": // Add new course
              Console.Clear();
              Console.WriteLine("\n\nAdd new course.\n");

              Console.Write("\nCourse's ID: ");
              string courseID = Console.ReadLine();

              Console.Write("\nCourse's name: ");
              string courseName = Console.ReadLine();

              Console.Write("\nStart date: ");
              string courseStartDate = Console.ReadLine();

              Console.Write("\nEnd date: ");
              string courseEndDate = Console.ReadLine();

              Console.Write("\nTeacher: ");
              string courseTeacher = Console.ReadLine();

              Console.Write("\nPoints: ");
              int coursePoints = Convert.ToInt32(Console.ReadLine());

              Console.Write("\nActive? (y/n): ");
              string courseStatus = Console.ReadLine();
              if (courseStatus == "y")
              {
                studentCourses[courseID] = new Course(courseName, courseStartDate, courseEndDate, courseTeacher, coursePoints, true, new List<string>());
                Console.WriteLine("\n\nCourse successfully added!");
                Console.Write("\nPress ENTER to continue. ");
                Console.ReadLine();
              }
              else if (courseStatus == "n")
              {
                studentCourses[courseID] = new Course(courseName, courseStartDate, courseEndDate, courseTeacher, coursePoints, false, new List<string>());
                Console.WriteLine("\nCourse successfully added!");
                Console.Write("\nPress ENTER to continue. ");
                Console.ReadLine();
              }
              break;

            case "3": // Update course
              {
                Console.Clear();
                Console.WriteLine("\n\nChoose course to update.\n");

                Console.Write($"\n{string.Join(" | ", studentCourses.Keys)}\n");

                Console.Write("\n\nCourse: ");
                string choosedCourse = Console.ReadLine();

                Console.Clear();
                Console.WriteLine($"\n\n{choosedCourse} - Overview.\n");

                foreach ((string courseKey, Course course) in studentCourses)
                {
                  if (choosedCourse == courseKey)
                  {
                    Console.WriteLine($"\nCourse name: {course.Name}\n"
                    + $"Course start: {course.StartDate}\n"
                    + $"Course end: {course.EndDate}\n"
                    + $"Teacher: {course.Teacher}\n"
                    + $"{course.Points} pts.\n"
                    + $"{(course.Active ? "Course is active" : "Course is inactive")}");
                  }
                }
                Console.Write("\nChange course's ID: ");
                string curseNewID = Console.ReadLine();

                if (!string.IsNullOrEmpty(curseNewID) && studentCourses.ContainsKey(choosedCourse))
                {
                  Course courseRename = studentCourses[choosedCourse];
                  studentCourses[curseNewID] = courseRename;
                  studentCourses.Remove(choosedCourse);
                }

                Console.Write("\nChange course's name: ");
                string newCourseName = Console.ReadLine();

                if (!string.IsNullOrEmpty(newCourseName))
                {
                  studentCourses[choosedCourse].Name = newCourseName;
                }

                Console.Write("\nChange course's start date: ");
                string newCourseSD = Console.ReadLine();

                if (!string.IsNullOrEmpty(newCourseSD))
                {
                  studentCourses[choosedCourse].StartDate = newCourseSD;
                }

                Console.Write("\nChange course's end date: ");
                string newCourseED = Console.ReadLine();

                if (!string.IsNullOrEmpty(newCourseED))
                {
                  studentCourses[choosedCourse].EndDate = newCourseED;
                }

                Console.Write("\nChange course's teacher: ");
                string newCourseTeacher = Console.ReadLine();

                if (!string.IsNullOrEmpty(newCourseTeacher))
                {
                  studentCourses[choosedCourse].Teacher = newCourseTeacher;
                }

                Console.Write("\nChange course's points: ");
                string newCP = Console.ReadLine();

                if (!string.IsNullOrEmpty(newCP))
                {
                  int newCoursePoints = 0;
                  if (int.TryParse(newCP, out newCoursePoints))
                  {
                    studentCourses[choosedCourse].Points = newCoursePoints;
                  }
                }

                Console.Write("\n\nPress ENTER to continue. ");
                Console.ReadLine();

                break;
              }
            case "4": // Register/remove student
              {
                Console.Clear();
                Console.WriteLine("\n\nRegister or remove a student from a course.");
                Console.WriteLine("\nCourses:");
                Console.WriteLine($"\n{string.Join(" | ", studentCourses.Keys)}");
                Console.Write("\nChoose course: ");
                string choosedCourse = Console.ReadLine();

                Console.Clear();
                Console.WriteLine($"\n\nStudents registered in {choosedCourse}:\n");

                foreach ((string courseKey, Course course) in studentCourses)
                {
                  if (choosedCourse == courseKey)
                  {
                    if (course.Students.Count > 0)
                    {
                      Console.WriteLine(string.Join("\n", course.Students));
                    }
                    else
                    {
                      Console.WriteLine($"\nThis course ({choosedCourse}) has no students registered yet.");
                      break;
                    }
                  }
                  else
                  {
                    Console.Write("\nInvalid input. Press ENTER to continue. ");
                    Console.ReadLine();
                    break;
                  }
                }

                Console.WriteLine("\n\nStudents in the system:");
                Console.WriteLine("Write a student name to register or remove from the course\n");

                foreach (IUser user in users)
                {
                  if (user is Student student)
                  {
                    Console.WriteLine(student.Username);
                  }
                }

                foreach (IUser user in users)
                {
                  if (user is Student student)
                  {
                    Console.Write("\nStudent name: ");
                    string regStudent = Console.ReadLine();
                    bool studentFound = users.Any(u => u.Username.Equals(regStudent, StringComparison.OrdinalIgnoreCase));


                    if (!string.IsNullOrEmpty(regStudent) && studentFound)
                    {
                      foreach ((string courseKey, Course course) in studentCourses)
                      {
                        if (course.Students.Contains(regStudent))
                        {
                          course.Students.Remove(regStudent);
                          Console.WriteLine($"\n\n{regStudent} has been successfully REMOVED from {choosedCourse}.\n");
                        }
                        else
                        {
                          course.Students.Add(regStudent);
                          Console.WriteLine($"\n\n{regStudent} has been successfully REGISTERED to {choosedCourse}.\n");
                        }
                        Console.Write("\nPress ENTER to continue. ");
                        Console.ReadLine();
                        break;
                      }
                    }
                    else
                    {
                      Console.Write("\nInvalid input. Press ENTER to continue. ");
                      Console.ReadLine();
                      break;
                    }
                  }
                  break;
                }
              }
              break;

            case "5": // Manage status
              {
                Console.Clear();
                Console.WriteLine("\n\nChoose course to activate/inactivate.\n");

                Console.Write($"\n{string.Join(" | ", studentCourses.Keys)}\n");

                Console.Write("\n\nCourse: ");
                string choosedCourse = Console.ReadLine();

                foreach ((string courseKey, Course course) in studentCourses)
                {
                  if (choosedCourse == courseKey)
                  {
                    course.Active = !course.Active;
                  }
                  Console.WriteLine($"\n{courseKey} ({course.Name}) is now {(course.Active ? "active." : "inactive.")}");
                }

                Console.Write("\nPress ENTER to continue. ");
                Console.ReadLine();
                break;
              }
            case "6": // Back
              break;

            default:
              Console.Write("\nInvalid input. Press ENTER to continue. ");
              Console.ReadLine();
              break;

          }

          break;

        case "4": // System overview

          break;

        case "5": // Log out
          active_user = null;
          break;

        default:
          Console.Write("\nInvalid input. Press ENTER to continue. ");
          Console.ReadLine();
          break;
      }
    }
    if (active_user is Teacher t)
    {
      Console.WriteLine("\nWelcome to your main page, " + t.Username);
      Console.WriteLine("\n[1] Write a message.");
      Console.WriteLine("\n[2] Grade documents.");
      Console.WriteLine("\n[3] Logout.\n");
      Console.WriteLine("\nChoose an option [1-3]");

      switch (Console.ReadLine())
      {
        case "1":
          Console.Clear();
          Console.Write("\n\nWrite a message. \n");
          Console.WriteLine("\nWho do you want to message?\n");
          Console.WriteLine("\n[1] A student.");
          Console.WriteLine("\n[2] A Teacher.");
          Console.WriteLine("\n[3] An admin.");
          Console.Write("\nType [1-3]: ");

          Type selectedType = null;

          switch (Console.ReadLine())
          {
            case "1":
              selectedType = typeof(Student);
              break;

            case "2":
              selectedType = typeof(Teacher);
              break;

            case "3":
              selectedType = typeof(Admin);
              break;
            default:
              Console.Write("\nInvalid selection. Press ENTER to continue. ");
              Console.ReadLine();
              break;
          }

          var filteredUsers = users.Where(u => u.GetType() == selectedType).ToList();

          if (filteredUsers.Count == 0)
          {
            Console.WriteLine($"\nNo users of type {selectedType} where found.");
            Console.Write($"\nPress ENTER to continue. ");
            Console.ReadLine();
          }

          Console.Clear();
          Console.WriteLine($"\n\n{selectedType.Name}s\n");

          foreach (var user in filteredUsers)
          {
            Console.WriteLine(user.Username);
          }

          Console.WriteLine($"\nSelect a {selectedType} to send a message");
          string selectedUser = Console.ReadLine();

          foreach (var user in filteredUsers)
          {
            if (user.Username == selectedUser)
            {
              string newMessage = Console.ReadLine();

              if (!string.IsNullOrEmpty(newMessage))
              {
                if (!studentMessages.ContainsKey(t.Username))
                {
                  studentMessages[t.Username] = new List<Message>();
                }
                studentMessages[t.Username].Add(new Message(user.Username, newMessage, t.Username, false));
              }
              else
              {
                Console.WriteLine("\nMessage can't be empty. Press ENTER to continue.");
                Console.ReadLine();
              }
              break;
            }
          }
          break;

        case "2":

          Console.WriteLine("\nChoose an student to see their documents.");
          Console.WriteLine($"\n{string.Join(", ", studentDocuments.Keys)}.\n");

          string searchStudent = Console.ReadLine();

          if (!string.IsNullOrEmpty(searchStudent))
          {
            if (studentDocuments.ContainsKey(searchStudent))
              Console.WriteLine($"\nDocuments uploaded by {searchStudent}:\n");
            {
              foreach ((string docKey, SDocument document) in studentDocuments)
              {
                if (document.Grade == "")
                {
                  Console.WriteLine($"'{document.Name}' - Not graded yet.");
                }
                else
                {
                  Console.WriteLine($"'{document.Name}' - Grade: {document.Grade}.");
                }
              }
            }
            Console.WriteLine($"\nSelect document to grade:");
            string selectedDocument = Console.ReadLine();

            foreach ((string docKey, SDocument document) in studentDocuments)
            {
              if (!string.IsNullOrEmpty(selectedDocument) && document.Name == selectedDocument)
              {
                Console.Write($"\nGrade the document (IG/ V/ VG): '{selectedDocument}': ");
                string newGrade = Console.ReadLine();
                if (newGrade == "IG" || newGrade == "G" || newGrade == "VG")
                {
                  document.Grade = newGrade;
                  document.Signed = t.Username;
                  Console.WriteLine($"\nDocument {document.Name} has been graded with {newGrade}");
                  Console.WriteLine("\nDo you want to add feedback? Leave empty if not.");
                  document.Feedback = Console.ReadLine();
                }
                else
                {
                  Console.WriteLine("\nDocuments can only be graded with 'IG', 'G' or 'VG'.");
                  Console.Write("\nPress ENTER to continue. ");
                  Console.ReadLine();
                }
                Console.Write("\nPress ENTER to continue.");
                Console.ReadLine();
                break;
              }
              else
              {
                Console.Write("\nInvalid input. Press ENTER to continue. ");
                Console.ReadLine();
              }
            }
          }
          else
          {
            Console.Write("\nInvalid input. Press ENTER to continue. ");
            Console.ReadLine();
          }
          break;

        case "3":
          active_user = null;
          break;

        default:
          Console.Write("\nInvalid input. Press ENTER to continue. ");
          Console.ReadLine();
          break;
      }
    }

    if (active_user is Student s)
    {
      Console.WriteLine("\nWelcome to your main page, " + s.Username);
      int newMessage = 0;

      foreach ((string msgKey, List<Message> msgList) in studentMessages)
      {
        foreach (Message msg in msgList)
        {
          if (msg.Read == false)
          {
            newMessage++;
          }
        }
      }

      Console.WriteLine($"\nYou have {newMessage} message/s.");


      Console.WriteLine("\n[1] See your messages.");
      Console.WriteLine("\n[2] Load a new document.");
      Console.WriteLine("\n[3] See your documents.");
      Console.WriteLine("\n[4] Logout.\n");
      Console.WriteLine("\nChoose an option [1-4]");

      switch (Console.ReadLine())
      {
        case "1":
          if (message != "")
          {
            Console.WriteLine($"\n{message} - from {teacherName}");
          }
          else
          {
            Console.WriteLine("\nYou have no messages.");
          }
          break;

        case "2":
          {
            Console.Write("\nDocument's name: ");
            string newDocument = Console.ReadLine();

            Console.Write("\nCourse: ");
            string documentCourse = Console.ReadLine();

            if (!string.IsNullOrEmpty(newDocument))
            {
              studentDocuments.Add(s.Username, new SDocument(s.Username, newDocument, documentCourse, "", "", ""));
            }
            break;

          }
        case "3":

          Console.WriteLine("\nYour documents:\n");

          foreach ((string docKey, SDocument document) in studentDocuments)
          {
            if (s.Username == document.Author)
            {
              if (document.Grade == "")
              {
                Console.WriteLine($"'{document.Name}' - Not graded yet.");
              }
              else
              {
                Console.WriteLine($"'{document.Name}' - grade: {document.Grade}. Graded by {document.Signed}");
                if (document.Feedback != "")
                {
                  Console.WriteLine($"\nFeedback from {document.Signed}: {document.Feedback}");
                }
              }

            }
          }
          Console.Write("\nPress ENTER to continue. ");
          Console.ReadLine();
          break;

        case "4":
          active_user = null;
          break;

        default:
          Console.Write("\nInvalid input. Press ENTER to continue. ");
          Console.ReadLine();
          break;
      }
    }
  }
  // Console.WriteLine($"\nLogged in? {active_user != null}");

  // Console.Write("\nPress ENTER to continue.");
  // Console.ReadLine();
}
