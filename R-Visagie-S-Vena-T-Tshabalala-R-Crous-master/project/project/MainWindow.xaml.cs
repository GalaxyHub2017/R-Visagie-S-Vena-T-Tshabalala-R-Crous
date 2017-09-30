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
        Random qng = new Random();
        int ques;
        public MainWindow()
        {
            InitializeComponent();
            
            BatMan = new Girl("BatMan", 20, 1.65, 65.0, "Student", "AstroSoc", "32B", "Currently\nstudying\nat\nRhodes\nUniversity", "Batman:\nBegins", "Brown");
            BatMan.Q1.Add(new Question("Do you believe in alien life?", "Well who can say, I've never seen anything but that doesnt disprove it", "Yeah aliens are totally real, i partied with some last night", "Hell no bitch, you cray cray","You know what , I think youre right ;)", "Ugh some guys are so immature!!","What did you just say???????!!!!!!"));
            myanus = new DispatcherTimer();
            
            myanus.Interval = TimeSpan.FromMilliseconds(100);
            myanus.IsEnabled = true;
            myanus.Tick += Myanus_Tick;
            diner.MouseDown += Diner_MouseDown;
            barimage.MouseDown += Barimage_MouseDown;
            libimage.MouseDown += Libimage_MouseDown;
         
        }

        private void Libimage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Barimage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Diner_MouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
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
            hangoutl.Content = "FAVOURITE\nHANGOUT:";
            titsl.Content = "BREAST SIZE:";
            eyecl.Content = "EYE COLOUR:";
        }
        int qw;
       
        public void stringify(int i)
        {
            Question quests = current.Q1[i];
            Random rng = new Random();
            qw = rng.Next(1, 4);
            int z = 0;
            Button a = new Button();
            Button b = new Button();
            Button c = new Button();
            a.Click += A_Click;
            b.Click += B_Click;
            c.Click += C_Click;
            List <Button> butts = new List<Button>() { a, b, c };
            foreach (Button item in butts)
            {
                playground.Children.Add(item);
                item.Height = 34;
                item.Width = 444;
                Canvas.SetLeft(item, 63);
                Canvas.SetTop(item, 162 + z);
                z += 56;
            }
            switch (qw)
            {
                case 1:
                    if (qw==1)
                    {
                        a.Content = quests.CorrectResponse;
                   
                        b.Content = quests.Incorrect1;
                        c.Content = quests.Incorrect2;
                    }break;
                case 2:
                    if (qw == 2)
                    {
                        a.Content = quests.Incorrect1;
                        b.Content = quests.CorrectResponse;
                        c.Content = quests.Incorrect2;
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        a.Content = quests.Incorrect1;
                        b.Content = quests.Incorrect2;
                        c.Content = quests.CorrectResponse;
                    }
                    break;
                default:
                    break;
            }
        }

        private void C_Click(object sender, RoutedEventArgs e)
        {

            switch (qw)
            {
                case 1:
                    if (qw == 1)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse2;
                    }
                    break;
                case 2:
                    if (qw == 2)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse3;
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse1;
                    }
                    break;
                default:
                    break;
            }

        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            switch (qw)
            {
                case 1:
                    if (qw == 1)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse2;
                    }
                    break;
                case 2:
                    if (qw == 2)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse1;
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse3;
                    }
                    break;
                default:
                    break;
            }
        }

        private void A_Click(object sender, RoutedEventArgs e)
        {
            switch (qw)
            {
                case 1:
                    if (qw == 1)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse1;
                    }
                    break;
                case 2:
                    if (qw == 2)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse2;
                    }
                    break;
                case 3:
                    if (qw == 3)
                    {
                        GirlOutput.Text = current.Q1[ques].HerResponse3;
                    }
                    break;
                default:
                    break;
            }
        }

        public enum charlie { a = 1, b, c }
        private void button3_Click(object sender, RoutedEventArgs e)
        {


            GirlOutput.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            button3.Visibility = Visibility.Hidden;
            response1.Visibility = Visibility.Visible;
            response2.Visibility = Visibility.Visible;
            response3.Visibility = Visibility.Visible;
            response1.Content = BatMan.Q1[0].Incorrect1;
            response2.Content = BatMan.Q1[0].CorrectResponse;
            response3.Content = BatMan.Q1[0].Incorrect2;
            GirlOutput.Text = Convert.ToString(BatMan);
            Name.Text = Convert.ToString(BatMan.Q1[0]);
        }

        private void response2_Click(object sender, RoutedEventArgs e)
        {
            Name.Text = $"{BatMan.Q1[0].HerResponse1}";
            response1.Visibility = Visibility.Hidden;
            response2.Visibility = Visibility.Hidden;
            response3.Visibility = Visibility.Hidden;
        }

        private void response1_Click(object sender, RoutedEventArgs e)
        {
            Name.Text = $"{BatMan.Q1[0].HerResponse2}";
            response1.Visibility = Visibility.Hidden;
            response2.Visibility = Visibility.Hidden;
            response3.Visibility = Visibility.Hidden;
        }
        
        private void response3_Click(object sender, RoutedEventArgs e)
        {
            Name.Text = $"{BatMan.Q1[0].HerResponse3}";
            response1.Visibility = Visibility.Hidden;
            response2.Visibility = Visibility.Hidden;
            response3.Visibility = Visibility.Hidden;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
