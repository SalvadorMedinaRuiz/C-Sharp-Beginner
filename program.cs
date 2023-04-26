using System;
using System.IO;
//Salvador Medina-Ruiz COSC 341

//Number 7: reads student scores from a user and displays the following: the
//average score, the minimum score, and the maximum score.
public static void scores(){
  double sumOfScores = 0; //Creates sumOfScores with 0 value
  double numOfScores = 0; //Creates numOfScores with 0 value
  double averageScore = 0; //Creates averageScore with 0 value
  string input; //Creates dummy input string just for reading user input

  double currentScore = 0; //Creates currentScore with 0 value
  double maxScore = 0; //Creates maxScore with 0 value
  double minScore; //Creates minScore
  Console.WriteLine("Please enter the score of a student, or -1 to quit: ");
  input = Console.ReadLine(); //Reads input 
  currentScore = Convert.ToDouble(input); //Converts input to double and puts it in currentScore
  if (currentScore == -1){ //Checks if imput was -1
      minScore = 0; //If yes, sets minScore to 0
  }
  else{
      minScore = currentScore; //Else, sets it to the current score
  }
  while (currentScore != -1){ //Keeps going if current score (input) is not -1
      sumOfScores += currentScore; //Adds current score to sumOfScores
      numOfScores++; //Increments numOfScores

      if (currentScore > maxScore){ //Checks if current score is bigger than maxScore
          maxScore = currentScore; //If yes, then current score is new maxScore
      }

      if (minScore > currentScore){ //Checks if the minScore is larger than the current score
          minScore = currentScore; //If yes, then current score is new minScore
      }

      Console.WriteLine("Please enter the score of a student, or -1 to quit: ");
      input = Console.ReadLine();
      currentScore = Convert.ToDouble(input);
      averageScore = sumOfScores/numOfScores; //averageScore equals sumOfScores divided by numOfScores
  }
  Console.WriteLine("The average score is: " + averageScore);
  Console.WriteLine("The minimum score is: " + minScore);
  Console.WriteLine("The maximum score is: " + maxScore);
}

//Number 8: Takes a last name and a first name as parameters and creates an id
//and a password and prints them. 
public static void createIdPassword(string last, string first){
  string lastUpper = last.ToUpper(); //Creates lastUpper with last name converted to upper case
  string firstUpper =  first.ToUpper(); //Creates firstUpper with first name converted to upper case

  string id = "" + firstUpper[0] + lastUpper; //Creates id
  string password = "" + firstUpper[0] + firstUpper[firstUpper.Length-1] + lastUpper.Substring(0, 3) + firstUpper.Length + lastUpper. Length; //Creates password

  Console.WriteLine("ID: " + id + "\nPassword: " + password); //Prints id and password
}

//Number 9: Method that reads an input file and creates a sorted output file.
public static void fileSort(string infile, string outfile){
  StreamReader fin = new StreamReader(infile); //Creates fin for reading file
  StreamWriter fout = new StreamWriter(outfile); //Creates fout for outputing to file

  string input; //Temp input variable
  string[] input2 = new string[3]; //Creates an array of strings for splitting up the original input
  
  int numOfStudents; //Creates numOfStudents
  input = fin.ReadLine(); //First line is read in input
  numOfStudents = Convert.ToInt32(input); //Converts that to an int for numOfStudents

  //Creates arrays for id, grade, and gpa
  int[] id = new int[numOfStudents];
  char[] grade = new char[numOfStudents];
  double[] gpa = new double[numOfStudents];

  //Creates temp variables for id, grade, and gpa to be used later for sorting
  int tempId;
  char tempGrade;
  double tempGpa;

  //Goes trough the whole input file and saves id, grade, and gpa to coressponding array
  for (int i = 0; i < numOfStudents; i++){
      input = fin.ReadLine();
      input2 = input.Split(); //Splits original input for input2
      id[i] = Convert.ToInt32(input2[0]); //Since input2 is an array, each index corresponds to either id, grade, or gpa
      grade[i] = Convert.ToChar(input2[1]);
      gpa[i] = Convert.ToDouble(input2[2]);
  }

  fout.WriteLine(numOfStudents); //Puts the numOfStudents back onto the first line of the output file
  //Selection sort is used here in order to properly sort the arrays into ascending order of Id
  for (int i = 0; i < numOfStudents; i++){
      for (int i2 = i + 1; i2 < numOfStudents; i2++){
          if (id[i] > id[i2]){
              tempId = id[i];
              id[i] = id[i2];
              id[i2] = tempId;

              tempGrade = grade[i];
              grade[i] = grade[i2];
              grade[i2] = tempGrade;

              tempGpa = gpa[i];
              gpa[i] = gpa[i2];
              gpa[i2] = tempGpa;
          }
      }
  }

  //Once arrays are sorted, they are printed BACK into the input file
  for (int i = 0; i < numOfStudents; i++){
    fout.WriteLine(id[i] + " " + grade[i] + " " + gpa[i]);
  }

  //Just closes the input and output files
  fout.Close();
  fin.Close();
}

//Number 10:
class Rectangle {
    private int width; //Private int width
    private int height; //Private int height

    public Rectangle(){ //No parameter constructor. Sets width and height to 0
      width = 0;
      height = 0;
    }

    public Rectangle(int size){ //Constructor takes size and sets width and height to it
      width = size;
      height = size;
    }

    public Rectangle(int width, int height){ //Constructor takes width and height and sets to it the class width and height
      this.width = width;
      this.height = height;
    }

    public void setWidth(int size){ //Takes a width and sets to class width to it
      width = size;
    }

    public void setHeight(int size){ //Takes a height and sets to class height to it
      height = size;
    }

    public int getWidth(){ //Returns width
      return width;
    }

    public int getHeight(){ //Returns height
      return height;
    }

    public int area(){ //Computes the area
      return width * height;
    }

    public void display(){ //Displays width and height
      Console.WriteLine("Width: " + getWidth() + "\nHeight: " + getHeight());
    }
}

//Number 11: Class Person and Student
class Person {
  private string name; //Private string name
  private int age; //Private int age

  public Person(string name, int age){ //Constructor takes name and age and sets it to class name and age
    this.name = name;
    this.age = age;
  }

  public void setName(string name){ //Sets name to class name
    this.name = name;
  }

  public void setAge(int age){ //Sets age to class age
    this.age = age;
  }

  public string getName(){ //Returns name
    return name;
  }

  public int getAge(){ //Returns age
    return age;
  }
}

class Student : Person{
  private int id; //Private int id
  private double gpa; //Private double gpa

  public Student(string name, int age, int id, double gpa) : base(name, age){ //Constructor sets class id and age. Name and age are passed to Person constructor
    this.id = id;
    this.gpa = gpa;
  }

  public void setId(int id){ //Sets class id
    this.id = id;
  }

  public void setGpa(double gpa){ //Sets class gpa
    this.gpa = gpa;
  }

  public int getId(){ //Returns class id
    return id;
  }

  public double getGpa(){ //Returns class gpa
    return gpa;
  }

  public void show(){ //Prints Student's name, age, id, and gpa
    Console.WriteLine("Name: " + getName() + " Age: " + getAge() + " ID: " + getId() + " GPA: " + getGpa());
  }
}