using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;
using System.Windows.Threading;

namespace project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class Question
    {
        public string Quest { get; private set; }
        public string CorrectResponse { get; private set; }
        public string Incorrect1 { get; private set; }
        public string Incorrect2 { get; private set; }
        public string HerResponse1 { get; private set; }
        public string HerResponse2 { get; private set; }
        public string HerResponse3 { get; private set; }

        public Question(string q, string r, string w1, string w2, string hr1, string hr2, string hr3 )
        {
            Quest=q;
            CorrectResponse =r;
            Incorrect1 =w1;
            Incorrect2 = w2;
            HerResponse1 = hr1;
            HerResponse2 = hr2;
            HerResponse3 = hr3;
        }
        public override string ToString()
        {
            Button a = new Button();
            Button b = new Button();
            Button c = new Button();
            Canvas.SetTop(a, 100);
            Canvas.SetTop(b, 300);
            Canvas.SetTop(c, 500);
            Canvas.SetLeft(a, 100);
            Canvas.SetLeft(b, 300);
            Canvas.SetLeft(c, 500);
            a.Content = $"{Incorrect1}";
            b.Content = $"{CorrectResponse}";
            c.Content = $"{Incorrect2}";
            return $"{Quest}";
           
        }
    }
    public class Questtraits
    {
        public string Correctquest { get; private set; }
        public string IncorrectQuest1 { get; private set; }
        public string IncorrectQuest2 { get; private set; }
        public string herResponseCorrect { get; private set; }
        public string herResponseIncorrect { get; private set; }
        public Questtraits(string cq, string iq1, string iq2, string hrc, string hri)
        {
            Correctquest = cq;
            IncorrectQuest1 = iq1;
            IncorrectQuest2 = iq2;
            herResponseCorrect = hrc;
            herResponseIncorrect = hri;
        }

       
    }
    public class Girl
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
        public string Occupation { get; private set; }
        public string FavHangOut { get; private set; }
        public string BreastSize { get; private set; }
        public string Education { get; private set; }
        public string FavouriteBook { get; private set; }
        public string EyeColour { get; private set; }
        public List<Question> Q1 { get; private set; }
        public Girl(string n, int a, double h, double w, string o, string f, string b, string ed, string fb, string ec)
        {
            Q1 = new List<Question>();
            Name=n;
            Age= a;
            Height = h;
            Weight = w;
            Occupation = o;
            FavHangOut = f;
            BreastSize = b;
            Education = ed;
            FavouriteBook = fb;
            EyeColour = ec;
        }
        public override string ToString()
        {
           
            return $"{Name}";
        }
    }
    

    public partial class MainWindow : Window
    {
        Girl BatMan;
        Girl current;
        DispatcherTimer myanus;
        string selected = "batman";
        public MainWindow()
        {
            InitializeComponent();
            
            BatMan = new Girl("BatMan", 20, 1.65, 65.0, "Student", "AstroSoc", "32B", "Currently\nstudying\nat\nRhodes\nUniversity", "Batman:\nBegins", "Brown");
            BatMan.Q1.Add(new Question("Do you believe in alien life?", "Well who can say, I've never seen anything but that doesnt disprove it", "Yeah aliens are totally real, i partied with some last night", "Hell no bitch, you cray cray","You know what , I think youre right ;)", "Ugh some guys are so immature!!","What did you just say???????!!!!!!"));
            myanus = new DispatcherTimer();
            myanus.Interval = TimeSpan.FromMilliseconds(100);
            myanus.IsEnabled = true;
            myanus.Tick += Myanus_Tick;
           

        }

        private void Myanus_Tick(object sender, EventArgs e)
        {
            switch (selected)
            {
                case "batman":
                    current = BatMan;
                    break;
                default:
                    break;
            }
            Age.Content = current.Age;
            height.Content = current.Height;
            weight.Content = current.Weight;
            education.Content = current.Education;
            occupation.Content = current.Occupation;
            favbook.Content = current.FavouriteBook;
            hangout.Content = current.FavHangOut;
            breast.Content = current.BreastSize;
            eyecolor.Content = current.EyeColour;
            huniegirlname.Text = current.Name;
            agel.Content = "AGE:";
            heightl.Content = "HEIGHT:";
            weightl.Content = "WEIGHT:";
            educationl.Content = "EDUCATION:";
            occl.Content = "OCCUPATION";
            favbookl.Content = "FAVOURITE\n  BOOK:";
            hangoutl.Content = "FAVOURITE\nHANGOUTL:";
            titsl.Content = "BREAST SIZE:";
            eyecl.Content = "EYE COLOUR:";
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {


            textBox.Visibility = Visibility.Visible;
            textBox1.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Hidden;
            response1.Visibility = Visibility.Visible;
            response2.Visibility = Visibility.Visible;
            response3.Visibility = Visibility.Visible;
            response1.Content = BatMan.Q1[0].Incorrect1;
            response2.Content = BatMan.Q1[0].CorrectResponse;
            response3.Content = BatMan.Q1[0].Incorrect2;
            textBox.Text = Convert.ToString(BatMan);
            textBox1.Text = Convert.ToString(BatMan.Q1[0]);
        }

        private void response2_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = $"{BatMan.Q1[0].HerResponse1}";
            response1.Visibility = Visibility.Hidden;
            response2.Visibility = Visibility.Hidden;
            response3.Visibility = Visibility.Hidden;
        }

        private void response1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = $"{BatMan.Q1[0].HerResponse2}";
            response1.Visibility = Visibility.Hidden;
            response2.Visibility = Visibility.Hidden;
            response3.Visibility = Visibility.Hidden;
        }
        
        private void response3_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = $"{BatMan.Q1[0].HerResponse3}";
            response1.Visibility = Visibility.Hidden;
            response2.Visibility = Visibility.Hidden;
            response3.Visibility = Visibility.Hidden;
        }
    }
}
